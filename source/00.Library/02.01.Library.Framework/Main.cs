using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Framework
{
    [Serializable]
    public enum EnumMantenStatus { eFound = 0, eFind = 1, eNew = 2, eEdit = 3 };
    public enum EnumMantenView { eLocate = 0, eFind = 1, eNew = 2, eEdit = 3, eDelete = 4, ePrint = 5 };
    public enum eForeign
    {
        None = 0,
        Parent = 1,
        Key = 2,
        Data = 3
    }
    
    static public class LibraryFramework
    {
        public const string V0001_IdEmpty = "Debe ingresar el Id";
        public const string V0002_IdExists = "El Id ya existe";
        public const string V0003_CodeEmpty = "Debe ingresar el Codigo";
        public const string V0004_CodeExists = "El Codigo ya existe";
        public const string V0005_FieldEmpty = "Debe ingresar {0}";
        public const string V0006_TableDependencies = "{0} tiene {1} dependientes";
    }

}
