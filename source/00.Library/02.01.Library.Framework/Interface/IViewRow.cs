using System;
using Library.Framework.Layers;
using Library.Framework.MVP;

namespace Library.Framework.Interface
{
    public interface IViewRow
    {
        Entity Entity { get; set; }

        EnumMantenStatus MantenStatus { get; set; }

        bool ValueChanged { get; set; }
        bool FillingValues { get; set; }
        event EventHandler eValueChanged;

        void Initialize();
        void LoadView(EnumMantenStatus paramMantenStatus);
        void ValueView(EnumMantenStatus paramMantenStatus);
        void EnableView(EnumMantenStatus paramMantenStatus);

        bool Abandon(); 
        
        bool ValidateSave(ref string paramField, ref string paramMessage);
        bool SaveMaster(bool paramResult);
        bool SaveDetail(bool paramResult);
        bool VerifySave();

        void SaveResult(bool paramResult, string paramField, string paramMessage);

        bool ValidateErase(ref string paramField, ref string paramMessage);
        bool EraseMaster(bool paramResult);
        bool EraseDetail(bool paramResult);
        bool VerifyErase();

        void EraseResult(bool paramResult, string paramField, string paramMessage);
    }
}
