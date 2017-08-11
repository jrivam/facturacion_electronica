using Library.Framework.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Framework.Interface
{
    public interface IReport
    {
        List<Raw> GetLines(List<Raw> paramLines);
    }
}
