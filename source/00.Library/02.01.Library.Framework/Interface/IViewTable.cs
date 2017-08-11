using System;
using Library.Framework.Layers;
using Library.Framework.MVP;
using System.Collections.Generic;

namespace Library.Framework.Interface
{
    public interface IViewTable
    {
        Enumerate Enumerate { get; set; }

        bool ValueChanged { get; set; }
        event EventHandler eValueChanged;

        void Initialize();
        void LoadTable(int paramMaxDepth = 0, string paramTableName = null, bool paramClear = true,
            Dictionary<string, object> paramAdapterParameterValues = null,
            int paramRowFrom = 0, int paramRowTo = 0);

        bool ValidateSave(ref string paramMessage);
        bool Save(bool paramResult);
        bool VerifySave();
    }
}
