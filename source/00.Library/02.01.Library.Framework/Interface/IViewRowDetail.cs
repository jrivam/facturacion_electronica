using System;
using Library.Framework.Layers;
using Library.Framework.MVP;

namespace Library.Framework.Interface
{
    public interface IViewRowDetail
    {
        Entity Entity { get; set; }

        EnumMantenStatus MantenStatus { get; set; }
        
        bool ValueChanged { get; set; }
        event EventHandler eValueChanged;

        void Initialize();
        void LoadView(EnumMantenStatus paramMantenStatus);
        void ValueView(EnumMantenStatus paramMantenStatus);
        void EnableView(EnumMantenStatus paramMantenStatus);

        bool ValidateSave(ref string paramField, ref string paramMessage);
        bool Save(bool paramResult);
        bool VerifySave();

        void SaveResult(bool paramResult, string paramField, string paramMessage);

        bool ValidateErase(ref string paramField, ref string paramMessage);
        bool Erase(bool paramResult);
        bool VerifyErase();

        void EraseResult(bool paramResult, string paramField, string paramMessage);
    }
}
