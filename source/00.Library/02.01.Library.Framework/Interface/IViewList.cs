using System;
using Library.Framework.Layers;
using Library.Framework.MVP;
using System.Collections.Generic;

namespace Library.Framework.Interface
{
    public interface IViewList
    {
        Enumerate Enumerate { get; set; }

        void Initialize();
        void LoadTable(int paramMaxDepth = 0, string paramTableName = null, bool paramClear = true,
            Dictionary<string, object> paramAdapterParameterValues = null,
            int paramRowFrom = 0, int paramRowTo = 0);
    }
}
