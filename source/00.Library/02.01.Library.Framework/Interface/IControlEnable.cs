using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Framework.Interface
{
    public interface IControlEnable
    {
        bool Enabled { get; set; }
        
        bool EnableFind { get; set; }
        bool EnableNew { get; set; }
        bool EnableEdit { get; set; }
    }
}
