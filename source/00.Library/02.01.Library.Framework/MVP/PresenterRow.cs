using System;
using System.Transactions;
using Library.Common.Data;
using Library.Framework.Interface;
using Library.Framework.Layers;
using System.Collections.Generic;

namespace Library.Framework.MVP
{
    [Serializable]
    public class MantenRow
    {
        public IViewEntity View;
        
        public MantenRow(IViewEntity paramView)
        {
            View = paramView;
        }

        public virtual void DefaultValues(EnumMantenStatus paramMantenStatus)
        {
        }

        public virtual void SetViewKeyValues(EnumMantenStatus paramMantenStatus, Entity paramEntity)
        {
            if (View is IViewEntityId && paramEntity is EntityId)
                ((IViewEntityId)View)._Id = Conversion.To<string>(((EntityId)paramEntity).Id);
        }
        public virtual void SetViewDataValues(EnumMantenStatus paramMantenStatus, Entity paramEntity)
        {

        }

        public virtual void SetEntityKeyValues(EnumMantenStatus paramMantenStatus, Entity paramEntity)
        {
            if (View is IViewEntityId && paramEntity is EntityId)
                ((EntityId)paramEntity).Id = Conversion.To<int?>(((IViewEntityId)View)._Id);
        }
        public virtual void SetEntityDataValues(EnumMantenStatus paramMantenStatus, Entity paramEntity)
        {

        }
    }

    [Serializable]
    public class PresenterRow
    {
        public LogicEntity Logic { get; set; }

        public MantenRow Manten;
        public IViewRow View;

        public IResultMessage ResultMessage;

        public PresenterRow(LogicEntity paramDL,
            MantenRow paramManten, 
            IViewRow paramView, IResultMessage paramResultMessage)
        {
            Logic = paramDL; 
            
            Manten = paramManten;
            View = paramView;

            ResultMessage = paramResultMessage;
        }

        public bool Find()
        {
            if (Manten != null)
            {
                Clear();

                View.MantenStatus = EnumMantenStatus.eFind;
                View.FillingValues = true;

                View.LoadView(View.MantenStatus);
                SetViewValues();
                Manten.DefaultValues(View.MantenStatus);
                View.ValueView(View.MantenStatus);

                View.ValueChanged = false;
                View.EnableView(View.MantenStatus);

                View.FillingValues = false;

                ResultMessage.ClearMessage();
            }

            return true;
        }
        public bool New()
        {
            if (Manten != null)
            {                
                View.MantenStatus = EnumMantenStatus.eNew;
                View.FillingValues = true;

                Clear();

                View.LoadView(View.MantenStatus);
                SetViewValues();
                Manten.DefaultValues(View.MantenStatus);
                View.ValueView(View.MantenStatus);

                View.ValueChanged = false;
                View.EnableView(View.MantenStatus);

                View.FillingValues = false;

                ResultMessage.ClearMessage();
            }

            return true;
        }
        public bool Edit()
        {
            if (Manten != null)
            {
                SetEntityValues();
                if (Load() != 1)
                    return Find();

                View.MantenStatus = EnumMantenStatus.eEdit;
                View.FillingValues = true;

                View.LoadView(View.MantenStatus);
                SetViewValues();
                Manten.DefaultValues(View.MantenStatus);
                View.ValueView(View.MantenStatus);

                View.ValueChanged = false;
                View.EnableView(View.MantenStatus);

                View.FillingValues = false;

                ResultMessage.ClearMessage();
            }

            return true;
        }

        public bool Undo()
        {
            if (View.Entity.Loaded)
                return Locate(false);

            return Find();
        }

        public bool Refresh(bool paramWithData = false)
        {
            if (Manten != null)
            {
                Clear();
                SetEntityValues(paramWithData);
                byte ret = Load();

                if (ret == 0)
                    return Find();

                SetViewValues();
            }

            return true;
        }
        public bool Locate(bool paramWithData = true)
        {
            if (Manten != null)
            {
                SetEntityValues(paramWithData);
                byte ret = Load();

                if (ret == 0)
                {
                    Clear();
                    SetViewValues();
                }
                if (ret != 1)
                    return false;

                View.MantenStatus = EnumMantenStatus.eFound;
                View.FillingValues = true;

                View.LoadView(View.MantenStatus);
                SetViewValues();
                Manten.DefaultValues(View.MantenStatus);
                View.ValueView(View.MantenStatus);

                View.ValueChanged = false;
                View.EnableView(View.MantenStatus);

                View.FillingValues = false;
            }

            return true;
        }

        public byte Load()
        {
            if (Logic != null)
                return Logic.Load(View.Entity);
            
            return 0;
        }
        public void Clear()
        {
            if (Logic != null)
                Logic.Clear(View.Entity);
        }

        public void SetEntityValues(bool paramData = true, bool paramKey = true)
        {
            if (paramKey)
                Manten.SetEntityKeyValues(View.MantenStatus, View.Entity);
            if (paramData)
                Manten.SetEntityDataValues(View.MantenStatus, View.Entity);
        }
        public void SetViewValues(bool paramData = true, bool paramKey = true)
        {
            if (paramKey)
                Manten.SetViewKeyValues(View.MantenStatus, View.Entity);
            if (paramData)
                Manten.SetViewDataValues(View.MantenStatus, View.Entity);
        }

        public bool Save(bool paramViewInput = true)
        {
            bool bOk = true;

            string Field = string.Empty;
            string Message = string.Empty;

            if (paramViewInput)
                if (bOk)
                    bOk = View.ValidateSave(ref Field, ref Message);

            if (bOk)
            {
                SetEntityValues();
                bOk = Logic.ValidateSave(View.Entity, ref Field, ref Message);
            }

            if (bOk)
            {
                try
                {
                    if (bOk)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (bOk)
                                bOk = View.SaveMaster(bOk);
                            if (Logic != null)
                                if (bOk)
                                    bOk = (Logic.Save(View.Entity) == 1);
                            if (bOk)
                                bOk = View.SaveDetail(bOk);

                            if (bOk)
                                scope.Complete();
                        }

                        if (Logic != null)
                            if (bOk)
                                bOk = Logic.VerifySave(View.Entity);
                    }

                    if (paramViewInput)
                    {
                        if (bOk)
                            bOk = View.VerifySave();

                        if (bOk)
                            ResultMessage.ShowInformation(@"Se GRABO el registro.", "Aviso");
                        else
                            ResultMessage.ShowError(String.Format(@"No se grabo el registro.{0}{1}", System.Environment.NewLine, Message), "Error");
                    }
                }
                catch (Exception ex)
                {
                    bOk = false;

                    if (paramViewInput)
                        ResultMessage.ShowError(String.Format(@"No se grabo el registro.{0}{1}", System.Environment.NewLine, ex.Message), "Error");
                }

                View.SaveResult(bOk, Field, Message);
            }

            if (bOk)
            {
                SetViewValues(false);
                Clear();

                if (paramViewInput)
                    Locate(false);
                else
                    Refresh();
            }
            else
            {
                if (paramViewInput)
                    if (!string.IsNullOrWhiteSpace(Message))
                        ResultMessage.ShowError(String.Format(@"{0}", Message), "Error");
            }

            return bOk;
        }
        public bool Erase(bool paramValidateCascadeIntegrity = true, bool paramViewInput = true)
        {
            bool bOk = true;

            string Field = string.Empty;
            string Message = string.Empty;

            if (paramViewInput)
                if (bOk)
                    bOk = View.ValidateErase(ref Field, ref Message);

            if (bOk)
                bOk = Logic.ValidateErase(View.Entity, ref Field, ref Message, paramValidateCascadeIntegrity);

            if (bOk)
            {
                try
                {
                    if (bOk)
                    {

                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (bOk)
                                bOk = View.EraseMaster(bOk);
                            if (Logic != null)
                                if (bOk)
                                    bOk = (Logic.Erase(View.Entity) == 1);
                            if (bOk)
                                bOk = View.EraseDetail(bOk);

                            if (bOk)
                                scope.Complete();
                        }

                        if (Logic != null)
                            if (bOk)
                                bOk = Logic.VerifyErase(View.Entity);

                    }

                    if (paramViewInput)
                    {
                        if (bOk)
                            bOk = View.VerifyErase();

                        if (bOk)
                            ResultMessage.ShowInformation(@"Se ELIMINO el registro.", "Aviso");
                        else
                            ResultMessage.ShowError(String.Format(@"No se elimino el registro.{0}{1}", System.Environment.NewLine, Message), "Error");
                    }

                }
                catch (Exception ex)
                {
                    bOk = false;

                    if (paramViewInput)
                        ResultMessage.ShowError(String.Format(@"No se elimino el registro.{0}{1}", System.Environment.NewLine, ex.Message), "Error");
                }

                View.EraseResult(bOk, Field, Message);
            }

            if (bOk)
                return Find();
            else
            {
                if (paramViewInput)
                    if (!string.IsNullOrWhiteSpace(Message))
                        ResultMessage.ShowError(String.Format(@"{0}", Message), "Error");
            }

            return false;
        }
    }
}
