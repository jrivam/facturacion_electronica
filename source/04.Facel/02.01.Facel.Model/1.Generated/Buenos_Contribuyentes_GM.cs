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
    public partial class Buenos_Contribuyentes_DE : EntityId
    {
        protected internal string _Ruc;
        public virtual string Ruc
    	{
    	    get { return _Ruc; }
    	    set { if (value != _Ruc) { _Ruc = value; OnPropertyChanged("Ruc"); } }
        }	
        protected internal string _RazonSocial;
        public virtual string RazonSocial
    	{
    	    get { return _RazonSocial; }
    	    set { if (value != _RazonSocial) { _RazonSocial = value; OnPropertyChanged("RazonSocial"); } }
        }	
    
    
    
    }
}

namespace Facel.Business.Entities
{
    [Serializable]
    public partial class Buenos_Contribuyentes_BE : Buenos_Contribuyentes_DE
    {
    }
}

//DataAccess
namespace Facel.Data.Accesses
{
    [Serializable]
    public partial class Buenos_Contribuyentes_DA : AccessEntityId
    {
    	public  Buenos_Contribuyentes_DA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    
        protected override Entity GetDE()
        {
            return new Buenos_Contribuyentes_DE();
        }
    
        public override List<Field> GetFieldsData(Entity paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Buenos_Contribuyentes_DE be = (Buenos_Contribuyentes_DE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<string>(fields, "ruc", System.Data.DbType.String, be.Ruc, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "razon_social", System.Data.DbType.String, be.RazonSocial, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    
        protected override Entity LoadDataReader(DbDataReader paramReader, Entity paramDE)
    	{
            Buenos_Contribuyentes_DE be = (Buenos_Contribuyentes_DE)paramDE;
    
    		be._Ruc = Conversion.To<string>(paramReader[TableColumn("ruc")]);
    		be._RazonSocial = Conversion.To<string>(paramReader[TableColumn("razon_social")]);
      
            return be;
    	}
        protected override Entity LoadDataRow(DataRow paramRow, Entity paramDE)
    	{
            Buenos_Contribuyentes_DE be = (Buenos_Contribuyentes_DE)paramDE;
    
    		be._Ruc = Conversion.To<string>(paramRow[TableColumn("ruc")]);
    		be._RazonSocial = Conversion.To<string>(paramRow[TableColumn("razon_social")]);
      
            return be;
    	}
        protected override Entity LoadDataParameters(DbParameterCollection paramParameters, Entity paramDE)
    	{
            Buenos_Contribuyentes_DE be = (Buenos_Contribuyentes_DE)paramDE;
    
    		be._Ruc = Conversion.To<string>(paramParameters[TableParameter("ruc")].Value);
    		be._RazonSocial = Conversion.To<string>(paramParameters[TableParameter("razon_social")].Value);
      
            return be;
    	}
    
        protected override Entity ClearData(Entity paramDE)
        {
            Buenos_Contribuyentes_DE be = (Buenos_Contribuyentes_DE)paramDE;
    
    		be._Ruc = null;
    		be._RazonSocial = null;
      
    
            return be;
        }
    
    }
}

namespace Facel.Business.Accesses
{
    [Serializable]
    public partial class Buenos_Contribuyentes_BA : Buenos_Contribuyentes_DA
    {
    	public  Buenos_Contribuyentes_BA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Buenos_Contribuyentes_BE();
        }
    }
}

//DataLogic
namespace Facel.Data.Logics
{
    [Serializable]
    public partial class Buenos_Contribuyentes_DL : LogicEntity
    {
        protected override Access GetDA()
        {
            return new Buenos_Contribuyentes_DA(TableName, ConnectionStringName);
        }
    	
    	protected override bool ValidateInsertModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            Buenos_Contribuyentes_BE be = (Buenos_Contribuyentes_BE)paramDE;
    
      
    		return base.ValidateInsertModel(paramDE, ref paramField, ref paramMessage);
        }
    	protected override bool ValidateDeleteModel(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            Buenos_Contribuyentes_BE be = (Buenos_Contribuyentes_BE)paramDE;
    
            if (paramValidateCascadeIntegrity)
            {
            }
    			     
            return base.ValidateDeleteModel(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);
        }
    	
    	public override byte EraseModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            byte ret = 1;
    
    		Buenos_Contribuyentes_BE be = (Buenos_Contribuyentes_BE)paramDE;
    
    		foreach (Buenos_Contribuyentes_BE e in new Buenos_Contribuyentes_FL().LoadConvert(new Buenos_Contribuyentes_FL().Convert(be), 1))
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
    public partial class Buenos_Contribuyentes_BL : Buenos_Contribuyentes_DL
    {
        protected override Access GetDA()
        {
            return new Buenos_Contribuyentes_BA(TableName, ConnectionStringName);
        }	
    }
    
}

//JoinEntities
namespace Facel.Join.Entities
{
    [Serializable]
    public partial class Buenos_Contribuyentes_JE : EnumerateId
    {
        public virtual Filter<string> Ruc { get; set; }
        public virtual Filter<string> RazonSocial { get; set; }
    
    }
}

namespace Facel.Filter.Entities
{
    [Serializable]
    public partial class Buenos_Contribuyentes_FE : Buenos_Contribuyentes_JE
    {
    }
}


//JoinAccess
namespace Facel.Join.Accesses
{
    [Serializable]
    public partial class Buenos_Contribuyentes_JA : AccessEnumerateId
    {	
    	public  Buenos_Contribuyentes_JA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Buenos_Contribuyentes_DE();
        }
    	protected override Access GetDA()
        {
            return new Buenos_Contribuyentes_DA(TableName, ConnectionStringName);
        }
    	
    	public override List<Field> GetFieldsData(Enumerate paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Buenos_Contribuyentes_JE be = (Buenos_Contribuyentes_JE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<string>(fields, "ruc", System.Data.DbType.String, be.Ruc, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "razon_social", System.Data.DbType.String, be.RazonSocial, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    	
    	protected override List<Field> GetFieldsJoin(List<Field> paramFields, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Buenos_Contribuyentes_FE be = (Buenos_Contribuyentes_FE)paramDE;
    		
            
    		return paramFields;
    	}
    	protected override string GetTablesJoin(string paramTables, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "",
    		Dictionary<string, string> paramFieldsJoin = null)
        {
    		Buenos_Contribuyentes_FE be = (Buenos_Contribuyentes_FE)paramDE;	
    
    
    		return paramTables;
    	}	
    		
    }
}

namespace Facel.Filter.Accesses
{
    [Serializable]
    public partial class Buenos_Contribuyentes_FA : Buenos_Contribuyentes_JA
    {	
    	public  Buenos_Contribuyentes_FA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Buenos_Contribuyentes_BE();
        }
    	protected override Access GetDA()
        {
            return new Buenos_Contribuyentes_BA(TableName, ConnectionStringName);
        }
    }
}


//JoinLogic
namespace Facel.Join.Logics
{
    [Serializable]
    public partial class Buenos_Contribuyentes_JL : LogicEnumerate
    {
    	protected override Access GetDA()
        {
            return new Buenos_Contribuyentes_JA(TableName, ConnectionStringName);
        }
    	
    	public ObservableCollection<Buenos_Contribuyentes_BE> LoadConvert(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
                int paramTop = 0,
    			int paramRowFrom = 0, int paramRowTo = 0)
        {
        	return new ObservableCollection<Buenos_Contribuyentes_BE>(Load(paramDE, paramMaxDepth, paramTypeLoad, paramIsSourceColumn,
                    paramTop,
    				paramRowFrom, paramRowTo).ConvertAll(x => x as Buenos_Contribuyentes_BE));
        }
    	public Buenos_Contribuyentes_FE Convert(Buenos_Contribuyentes_BE paramDE)
        {
            Buenos_Contribuyentes_FE be = new Buenos_Contribuyentes_FE();
    
    		be.Id = new Filter<Nullable<int>>(paramDE.Id);
    		be.Ruc = new Filter<string>(paramDE.Ruc);
    		be.RazonSocial = new Filter<string>(paramDE.RazonSocial);
      
            return be;
        }	
    }
}

namespace Facel.Filter.Logics
{
    [Serializable]
    public partial class Buenos_Contribuyentes_FL : Buenos_Contribuyentes_JL
    {
    	protected override Access GetDA()
        {
            return new Buenos_Contribuyentes_FA(TableName, ConnectionStringName);
        }
    }
}
