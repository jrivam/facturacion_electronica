//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Collections.ObjectModel;
using Library.Common.Data;
using Library.Framework;
using Library.Framework.Layers;
using Library.Framework.Data;

using Facel.Data.Entities;
using Facel.Data.Accesses;
using Facel.Data.Logics;
using Facel.Business.Entities;
using Facel.Business.Accesses;
using Facel.Business.Logics;
using Facel.Join.Entities;
using Facel.Join.Accesses;
using Facel.Join.Logics;
using Facel.Filter.Entities;
using Facel.Filter.Accesses;
using Facel.Filter.Logics;
using Facel.Main;


//DataEntity
namespace Facel.Data.Entities
{
    [Serializable]
    public partial class Igv_Vigente_DE : EntityId
    {
        protected internal Nullable<decimal> _Porcentaje;
        public virtual Nullable<decimal> Porcentaje
    	{
    	    get { return _Porcentaje; }
    	    set { if (value != _Porcentaje) { _Porcentaje = value; OnPropertyChanged("Porcentaje"); } }
        }	
        protected internal Nullable<System.DateTime> _FechaRegistro;
        public virtual Nullable<System.DateTime> FechaRegistro
    	{
    	    get { return _FechaRegistro; }
    	    set { if (value != _FechaRegistro) { _FechaRegistro = value; OnPropertyChanged("FechaRegistro"); } }
        }	
        protected internal Nullable<bool> _EsDefault;
        public virtual Nullable<bool> EsDefault
    	{
    	    get { return _EsDefault; }
    	    set { if (value != _EsDefault) { _EsDefault = value; OnPropertyChanged("EsDefault"); } }
        }	
    
    
    
    }
}

namespace Facel.Business.Entities
{
    [Serializable]
    public partial class Igv_Vigente_BE : Igv_Vigente_DE
    {
    }
}

//DataAccess
namespace Facel.Data.Accesses
{
    [Serializable]
    public partial class Igv_Vigente_DA : AccessEntityId
    {
    	public  Igv_Vigente_DA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    
        protected override Entity GetDE()
        {
            return new Igv_Vigente_DE();
        }
    
        public override List<Field> GetFieldsData(Entity paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Igv_Vigente_DE be = (Igv_Vigente_DE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<decimal>>(fields, "porcentaje", System.Data.DbType.Decimal, be.Porcentaje, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<System.DateTime>>(fields, "fecha_registro", System.Data.DbType.DateTime, be.FechaRegistro, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_default", System.Data.DbType.Boolean, be.EsDefault, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    
        protected override Entity LoadDataReader(DbDataReader paramReader, Entity paramDE)
    	{
            Igv_Vigente_DE be = (Igv_Vigente_DE)paramDE;
    
    		be._Porcentaje = Conversion.To<Nullable<decimal>>(paramReader[TableColumn("porcentaje")]);
    		be._FechaRegistro = Conversion.To<Nullable<System.DateTime>>(paramReader[TableColumn("fecha_registro")]);
    		be._EsDefault = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_default")]);
      
            return be;
    	}
        protected override Entity LoadDataRow(DataRow paramRow, Entity paramDE)
    	{
            Igv_Vigente_DE be = (Igv_Vigente_DE)paramDE;
    
    		be._Porcentaje = Conversion.To<Nullable<decimal>>(paramRow[TableColumn("porcentaje")]);
    		be._FechaRegistro = Conversion.To<Nullable<System.DateTime>>(paramRow[TableColumn("fecha_registro")]);
    		be._EsDefault = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_default")]);
      
            return be;
    	}
        protected override Entity LoadDataParameters(DbParameterCollection paramParameters, Entity paramDE)
    	{
            Igv_Vigente_DE be = (Igv_Vigente_DE)paramDE;
    
    		be._Porcentaje = Conversion.To<Nullable<decimal>>(paramParameters[TableParameter("porcentaje")].Value);
    		be._FechaRegistro = Conversion.To<Nullable<System.DateTime>>(paramParameters[TableParameter("fecha_registro")].Value);
    		be._EsDefault = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_default")].Value);
      
            return be;
    	}
    
        protected override Entity ClearData(Entity paramDE)
        {
            Igv_Vigente_DE be = (Igv_Vigente_DE)paramDE;
    
    		be._Porcentaje = null;
    		be._FechaRegistro = null;
    		be._EsDefault = null;
      
    
            return be;
        }
    
    }
}

namespace Facel.Business.Accesses
{
    [Serializable]
    public partial class Igv_Vigente_BA : Igv_Vigente_DA
    {
    	public  Igv_Vigente_BA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Igv_Vigente_BE();
        }
    }
}

//DataLogic
namespace Facel.Data.Logics
{
    [Serializable]
    public partial class Igv_Vigente_DL : LogicEntity
    {
        protected override Access GetDA()
        {
            return new Igv_Vigente_DA(TableName, ConnectionStringName);
        }
    	
    	protected override bool ValidateInsertModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            Igv_Vigente_BE be = (Igv_Vigente_BE)paramDE;
    
      
    		return base.ValidateInsertModel(paramDE, ref paramField, ref paramMessage);
        }
    	protected override bool ValidateDeleteModel(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            Igv_Vigente_BE be = (Igv_Vigente_BE)paramDE;
    
            if (paramValidateCascadeIntegrity)
            {
            }
    			     
            return base.ValidateDeleteModel(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);
        }
    	
    	public override byte EraseModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            byte ret = 1;
    
    		Igv_Vigente_BE be = (Igv_Vigente_BE)paramDE;
    
    		foreach (Igv_Vigente_BE e in new Igv_Vigente_FL().LoadConvert(new Igv_Vigente_FL().Convert(be), 1))
    		{
     		}
    		
    		if (ret == 1)
                ret = base.EraseModel(paramDE, paramCheckKeyEmpty, paramIsSourceColumn);
            
    		return ret;
        }	
    }
}

namespace Facel.Business.Logics
{
    [Serializable]
    public partial class Igv_Vigente_BL : Igv_Vigente_DL
    {
        protected override Access GetDA()
        {
            return new Igv_Vigente_BA(TableName, ConnectionStringName);
        }	
    }
    
}

//JoinEntities
namespace Facel.Join.Entities
{
    [Serializable]
    public partial class Igv_Vigente_JE : EnumerateId
    {
        public virtual Filter<Nullable<decimal>> Porcentaje { get; set; }
        public virtual Filter<Nullable<System.DateTime>> FechaRegistro { get; set; }
        public virtual Filter<Nullable<bool>> EsDefault { get; set; }
    
    }
}

namespace Facel.Filter.Entities
{
    [Serializable]
    public partial class Igv_Vigente_FE : Igv_Vigente_JE
    {
    }
}


//JoinAccess
namespace Facel.Join.Accesses
{
    [Serializable]
    public partial class Igv_Vigente_JA : AccessEnumerateId
    {	
    	public  Igv_Vigente_JA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Igv_Vigente_DE();
        }
    	protected override Access GetDA()
        {
            return new Igv_Vigente_DA(TableName, ConnectionStringName);
        }
    	
    	public override List<Field> GetFieldsData(Enumerate paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Igv_Vigente_JE be = (Igv_Vigente_JE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<decimal>>(fields, "porcentaje", System.Data.DbType.Decimal, be.Porcentaje, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<System.DateTime>>(fields, "fecha_registro", System.Data.DbType.DateTime, be.FechaRegistro, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_default", System.Data.DbType.Boolean, be.EsDefault, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    	
    	protected override List<Field> GetFieldsJoin(List<Field> paramFields, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Igv_Vigente_FE be = (Igv_Vigente_FE)paramDE;
    		
            
    		return paramFields;
    	}
    	protected override string GetTablesJoin(string paramTables, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "",
    		Dictionary<string, string> paramFieldsJoin = null)
        {
    		Igv_Vigente_FE be = (Igv_Vigente_FE)paramDE;	
    
    
    		return paramTables;
    	}	
    		
    }
}

namespace Facel.Filter.Accesses
{
    [Serializable]
    public partial class Igv_Vigente_FA : Igv_Vigente_JA
    {	
    	public  Igv_Vigente_FA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Igv_Vigente_BE();
        }
    	protected override Access GetDA()
        {
            return new Igv_Vigente_BA(TableName, ConnectionStringName);
        }
    }
}


//JoinLogic
namespace Facel.Join.Logics
{
    [Serializable]
    public partial class Igv_Vigente_JL : LogicEnumerate
    {
    	protected override Access GetDA()
        {
            return new Igv_Vigente_JA(TableName, ConnectionStringName);
        }
    	
    	public ObservableCollection<Igv_Vigente_BE> LoadConvert(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
                int paramTop = 0,
    			int paramRowFrom = 0, int paramRowTo = 0)
        {
        	return new ObservableCollection<Igv_Vigente_BE>(Load(paramDE, paramMaxDepth, paramTypeLoad, paramIsSourceColumn,
                    paramTop,
    				paramRowFrom, paramRowTo).ConvertAll(x => x as Igv_Vigente_BE));
        }
    	public Igv_Vigente_FE Convert(Igv_Vigente_BE paramDE)
        {
            Igv_Vigente_FE be = new Igv_Vigente_FE();
    
    		be.Id = new Filter<Nullable<int>>(paramDE.Id);
    		be.Porcentaje = new Filter<Nullable<decimal>>(paramDE.Porcentaje);
    		be.FechaRegistro = new Filter<Nullable<System.DateTime>>(paramDE.FechaRegistro);
    		be.EsDefault = new Filter<Nullable<bool>>(paramDE.EsDefault);
      
            return be;
        }	
    }
}

namespace Facel.Filter.Logics
{
    [Serializable]
    public partial class Igv_Vigente_FL : Igv_Vigente_JL
    {
    	protected override Access GetDA()
        {
            return new Igv_Vigente_FA(TableName, ConnectionStringName);
        }
    }
}
