using System;
using Library.Framework.Layers;
using Library.Framework.MVP;
using System.Collections.Generic;

namespace Library.Framework.Interface
{
    public interface IViewQuery
    {
        Enumerate Enumerate { get; set; }

        void Initialize();
        
        bool ShowFilter();

        void LoadTable(int paramMaxDepth = 0, string paramTableName = null, bool paramClear = true,
            Dictionary<string, object> paramAdapterParameterValues = null,
            int paramRowFrom = 0, int paramRowTo = 0);
        void PrintTable();
    }
}
