using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Framework.Interface
{
    public interface IColumnEnable
    {
        bool Enabled { get; set; }
        
        bool EnableNew { get; set; }
        bool EnableEdit { get; set; }
    }
}
