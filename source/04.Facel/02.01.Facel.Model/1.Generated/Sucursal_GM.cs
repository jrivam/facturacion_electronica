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
    public partial class Sucursal_DE : EntityId
    {
        protected internal Nullable<int> _IdEmpresa;
        public virtual Nullable<int> IdEmpresa
    	{
    	    get { return _IdEmpresa; }
    	    set { if (value != _IdEmpresa) { _IdEmpresa = value; OnPropertyChanged("IdEmpresa"); } }
        }	
        protected internal string _Nombre;
        public virtual string Nombre
    	{
    	    get { return _Nombre; }
    	    set { if (value != _Nombre) { _Nombre = value; OnPropertyChanged("Nombre"); } }
        }	
        protected internal string _Direccion;
        public virtual string Direccion
    	{
    	    get { return _Direccion; }
    	    set { if (value != _Direccion) { _Direccion = value; OnPropertyChanged("Direccion"); } }
        }	
        protected internal string _Ubigeo;
        public virtual string Ubigeo
    	{
    	    get { return _Ubigeo; }
    	    set { if (value != _Ubigeo) { _Ubigeo = value; OnPropertyChanged("Ubigeo"); } }
        }	
        protected internal Nullable<bool> _Activo;
        public virtual Nullable<bool> Activo
    	{
    	    get { return _Activo; }
    	    set { if (value != _Activo) { _Activo = value; OnPropertyChanged("Activo"); } }
        }	
    
    
    	protected internal Empresa_BE _Empresa;
        public virtual Empresa_BE Empresa
    	{
            get 
            {
    			if (_Empresa == null) _Empresa = new Empresa_BE();
    			
    			if (!_Empresa.Loaded && Id != null)
    			{	
    				_Empresa.Id = Id;
     
                    new Empresa_BL().Load(_Empresa);
    			}
    				
                return _Empresa;
            } 
    		set
    		{
                if (value != _Empresa) 
    			{
    				_Empresa = value;
    				
    				Id = _Empresa.Id;
                
    				OnPropertyChanged("Empresa");
    			}
    		}
    	}
    
    }
}

namespace Facel.Business.Entities
{
    [Serializable]
    public partial class Sucursal_BE : Sucursal_DE
    {
    }
}

//DataAccess
namespace Facel.Data.Accesses
{
    [Serializable]
    public partial class Sucursal_DA : AccessEntityId
    {
    	public  Sucursal_DA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    
        protected override Entity GetDE()
        {
            return new Sucursal_DE();
        }
    
        public override List<Field> GetFieldsData(Entity paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Sucursal_DE be = (Sucursal_DE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<int>>(fields, "id_empresa", System.Data.DbType.Int32, be.IdEmpresa, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "nombre", System.Data.DbType.String, be.Nombre, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "direccion", System.Data.DbType.String, be.Direccion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ubigeo", System.Data.DbType.String, be.Ubigeo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "activo", System.Data.DbType.Boolean, be.Activo, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    
        protected override Entity LoadDataReader(DbDataReader paramReader, Entity paramDE)
    	{
            Sucursal_DE be = (Sucursal_DE)paramDE;
    
    		be._IdEmpresa = Conversion.To<Nullable<int>>(paramReader[TableColumn("id_empresa")]);
    		be._Nombre = Conversion.To<string>(paramReader[TableColumn("nombre")]);
    		be._Direccion = Conversion.To<string>(paramReader[TableColumn("direccion")]);
    		be._Ubigeo = Conversion.To<string>(paramReader[TableColumn("ubigeo")]);
    		be._Activo = Conversion.To<Nullable<bool>>(paramReader[TableColumn("activo")]);
      
            return be;
    	}
        protected override Entity LoadDataRow(DataRow paramRow, Entity paramDE)
    	{
            Sucursal_DE be = (Sucursal_DE)paramDE;
    
    		be._IdEmpresa = Conversion.To<Nullable<int>>(paramRow[TableColumn("id_empresa")]);
    		be._Nombre = Conversion.To<string>(paramRow[TableColumn("nombre")]);
    		be._Direccion = Conversion.To<string>(paramRow[TableColumn("direccion")]);
    		be._Ubigeo = Conversion.To<string>(paramRow[TableColumn("ubigeo")]);
    		be._Activo = Conversion.To<Nullable<bool>>(paramRow[TableColumn("activo")]);
      
            return be;
    	}
        protected override Entity LoadDataParameters(DbParameterCollection paramParameters, Entity paramDE)
    	{
            Sucursal_DE be = (Sucursal_DE)paramDE;
    
    		be._IdEmpresa = Conversion.To<Nullable<int>>(paramParameters[TableParameter("id_empresa")].Value);
    		be._Nombre = Conversion.To<string>(paramParameters[TableParameter("nombre")].Value);
    		be._Direccion = Conversion.To<string>(paramParameters[TableParameter("direccion")].Value);
    		be._Ubigeo = Conversion.To<string>(paramParameters[TableParameter("ubigeo")].Value);
    		be._Activo = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("activo")].Value);
      
            return be;
    	}
    
        protected override Entity ClearData(Entity paramDE)
        {
            Sucursal_DE be = (Sucursal_DE)paramDE;
    
    		be._IdEmpresa = null;
    		be._Nombre = null;
    		be._Direccion = null;
    		be._Ubigeo = null;
    		be._Activo = null;
      
    		be._Empresa = null;
    
            return be;
        }
    
    }
}

namespace Facel.Business.Accesses
{
    [Serializable]
    public partial class Sucursal_BA : Sucursal_DA
    {
    	public  Sucursal_BA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Sucursal_BE();
        }
    }
}

//DataLogic
namespace Facel.Data.Logics
{
    [Serializable]
    public partial class Sucursal_DL : LogicEntity
    {
        protected override Access GetDA()
        {
            return new Sucursal_DA(TableName, ConnectionStringName);
        }
    	
    	protected override bool ValidateInsertModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            Sucursal_BE be = (Sucursal_BE)paramDE;
    
      
    		return base.ValidateInsertModel(paramDE, ref paramField, ref paramMessage);
        }
    	protected override bool ValidateDeleteModel(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            Sucursal_BE be = (Sucursal_BE)paramDE;
    
            if (paramValidateCascadeIntegrity)
            {
            }
    			     
            return base.ValidateDeleteModel(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);
        }
    	
    	public override byte EraseModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            byte ret = 1;
    
    		Sucursal_BE be = (Sucursal_BE)paramDE;
    
    		foreach (Sucursal_BE e in new Sucursal_FL().LoadConvert(new Sucursal_FL().Convert(be), 1))
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
    public partial class Sucursal_BL : Sucursal_DL
    {
        protected override Access GetDA()
        {
            return new Sucursal_BA(TableName, ConnectionStringName);
        }	
    }
    
}

//JoinEntities
namespace Facel.Join.Entities
{
    [Serializable]
    public partial class Sucursal_JE : EnumerateId
    {
        public virtual Filter<Nullable<int>> IdEmpresa { get; set; }
        public virtual Filter<string> Nombre { get; set; }
        public virtual Filter<string> Direccion { get; set; }
        public virtual Filter<string> Ubigeo { get; set; }
        public virtual Filter<Nullable<bool>> Activo { get; set; }
    
    	protected Empresa_FE _Empresa;
        public Empresa_FE Empresa
    	{
            get 
            {
                _Empresa = _Empresa ?? new Empresa_FE();
                return _Empresa;
            } 
    		set
    		{
    			_Empresa = value;
    		}
    	}
    }
}

namespace Facel.Filter.Entities
{
    [Serializable]
    public partial class Sucursal_FE : Sucursal_JE
    {
    }
}


//JoinAccess
namespace Facel.Join.Accesses
{
    [Serializable]
    public partial class Sucursal_JA : AccessEnumerateId
    {	
    	public  Sucursal_JA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Sucursal_DE();
        }
    	protected override Access GetDA()
        {
            return new Sucursal_DA(TableName, ConnectionStringName);
        }
    	
    	public override List<Field> GetFieldsData(Enumerate paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Sucursal_JE be = (Sucursal_JE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<int>>(fields, "id_empresa", System.Data.DbType.Int32, be.IdEmpresa, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "nombre", System.Data.DbType.String, be.Nombre, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "direccion", System.Data.DbType.String, be.Direccion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ubigeo", System.Data.DbType.String, be.Ubigeo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "activo", System.Data.DbType.Boolean, be.Activo, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    	
    	protected override List<Field> GetFieldsJoin(List<Field> paramFields, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Sucursal_FE be = (Sucursal_FE)paramDE;
    		
    		foreach (Field f in new Empresa_FL().GetFieldsJoin(be.Empresa, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias + "__empresa"))
        		paramFields.Add(f);
            
    		return paramFields;
    	}
    	protected override string GetTablesJoin(string paramTables, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "",
    		Dictionary<string, string> paramFieldsJoin = null)
        {
    		Sucursal_FE be = (Sucursal_FE)paramDE;	
    	
    		paramTables += new Empresa_FL().GetTablesJoin(be.Empresa, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias, paramTableAlias + "__empresa", new Dictionary<string, string>() { { "id", "id" } });
    
    		return paramTables;
    	}	
    		
    }
}

namespace Facel.Filter.Accesses
{
    [Serializable]
    public partial class Sucursal_FA : Sucursal_JA
    {	
    	public  Sucursal_FA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Sucursal_BE();
        }
    	protected override Access GetDA()
        {
            return new Sucursal_BA(TableName, ConnectionStringName);
        }
    }
}


//JoinLogic
namespace Facel.Join.Logics
{
    [Serializable]
    public partial class Sucursal_JL : LogicEnumerate
    {
    	protected override Access GetDA()
        {
            return new Sucursal_JA(TableName, ConnectionStringName);
        }
    	
    	public ObservableCollection<Sucursal_BE> LoadConvert(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
                int paramTop = 0,
    			int paramRowFrom = 0, int paramRowTo = 0)
        {
        	return new ObservableCollection<Sucursal_BE>(Load(paramDE, paramMaxDepth, paramTypeLoad, paramIsSourceColumn,
                    paramTop,
    				paramRowFrom, paramRowTo).ConvertAll(x => x as Sucursal_BE));
        }
    	public Sucursal_FE Convert(Sucursal_BE paramDE)
        {
            Sucursal_FE be = new Sucursal_FE();
    
    		be.IdEmpresa = new Filter<Nullable<int>>(paramDE.IdEmpresa);
    		be.Nombre = new Filter<string>(paramDE.Nombre);
    		be.Direccion = new Filter<string>(paramDE.Direccion);
    		be.Ubigeo = new Filter<string>(paramDE.Ubigeo);
    		be.Activo = new Filter<Nullable<bool>>(paramDE.Activo);
    		be.Id = new Filter<Nullable<int>>(paramDE.Id);
      
            return be;
        }	
    }
}

namespace Facel.Filter.Logics
{
    [Serializable]
    public partial class Sucursal_FL : Sucursal_JL
    {
    	protected override Access GetDA()
        {
            return new Sucursal_FA(TableName, ConnectionStringName);
        }
    }
}

