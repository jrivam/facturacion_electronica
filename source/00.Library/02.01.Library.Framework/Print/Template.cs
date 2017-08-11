using Library.Common.Data;
using Library.Framework.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Framework.Print
{
    public interface IPrintTemplate
    {
        string Name {get; set;}
        List<Raw> GetLines(List<Raw> paramLines);
    }
}
