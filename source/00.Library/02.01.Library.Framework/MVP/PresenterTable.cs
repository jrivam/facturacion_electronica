using System;
using System.Transactions;
using Library.Framework.Interface;
using Library.Framework.Layers;

namespace Library.Framework.MVP
{ 
    [Serializable]
    public class PresenterTable
    {
        public LogicEnumerate Logic { get; set; }

        public IViewTable View;
        public IResultMessage ResultMessage;

        public PresenterTable(LogicEnumerate paramDL, 
            IViewTable paramView, IResultMessage paramResultMessage)
        {
            Logic = paramDL; 
            
            View = paramView;

            ResultMessage = paramResultMessage;
        }

        public bool Refresh()
        {
            View.LoadTable();
            View.ValueChanged = false;

            return true;
        }

        public bool Undo()
        {
            Refresh();

            return true;
        }
        public bool Save()
        {
            bool bOk = true;

            string Message = string.Empty;

            if (bOk)
                bOk = View.ValidateSave(ref Message);

            if (bOk)
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (bOk)
                            bOk = View.Save(bOk);

                        if (bOk)
                            scope.Complete();
                    }

                    if (bOk)
                        bOk = View.VerifySave();

                    if (bOk)
                        Message = @"Se GRABO la tabla.";
                    else
                        Message = @"No se grabo la tabla.";
                }
                catch (Exception ex)
                {
                    bOk = false;
                    Message = String.Format(@"Se produjo un error. No se grabo la tabla.{0}{1}", System.Environment.NewLine, ex.Message);
                }
            }

            if (bOk)
            {
                Refresh();
            }

            if (Message != "")
            {
                if (bOk)
                    ResultMessage.ShowInformation(Message, "Aviso");
                else
                    ResultMessage.ShowError(Message, "Error");
            }

            return bOk;
        }
    }
}
