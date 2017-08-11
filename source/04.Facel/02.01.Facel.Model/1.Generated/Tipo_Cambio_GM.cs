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
    public partial class Tipo_Cambio_DE : EntityId
    {
        protected internal Nullable<System.DateTime> _Fecha;
        public virtual Nullable<System.DateTime> Fecha
    	{
    	    get { return _Fecha; }
    	    set { if (value != _Fecha) { _Fecha = value; OnPropertyChanged("Fecha"); } }
        }	
        protected internal Nullable<decimal> _Compra;
        public virtual Nullable<decimal> Compra
    	{
    	    get { return _Compra; }
    	    set { if (value != _Compra) { _Compra = value; OnPropertyChanged("Compra"); } }
        }	
        protected internal Nullable<decimal> _Venta;
        public virtual Nullable<decimal> Venta
    	{
    	    get { return _Venta; }
    	    set { if (value != _Venta) { _Venta = value; OnPropertyChanged("Venta"); } }
        }	
    
    	protected internal Nullable<int> _IdMonedaOrigen;
    	public virtual Nullable<int> IdMonedaOrigen
    	{
    		get
    		{
    			return _IdMonedaOrigen;
    		}
    		set
    		{
                if (value != _IdMonedaOrigen) 
    			{
    				_IdMonedaOrigen = value;	
    				
    				MonedaOrigen.Id = _IdMonedaOrigen;						
    	            
    				OnPropertyChanged("IdMonedaOrigen");
    			}		
    		}
    	}	
    	protected internal Nullable<int> _IdMonedaDestino;
    	public virtual Nullable<int> IdMonedaDestino
    	{
    		get
    		{
    			return _IdMonedaDestino;
    		}
    		set
    		{
                if (value != _IdMonedaDestino) 
    			{
    				_IdMonedaDestino = value;	
    				
    				MonedaDestino.Id = _IdMonedaDestino;						
    	            
    				OnPropertyChanged("IdMonedaDestino");
    			}		
    		}
    	}	
    
    	protected internal Moneda_BE _MonedaOrigen;
        public virtual Moneda_BE MonedaOrigen
    	{
            get 
            {
    			if (_MonedaOrigen == null) _MonedaOrigen = new Moneda_BE();
    			
    			if (!_MonedaOrigen.Loaded && IdMonedaOrigen != null)
    			{	
    				_MonedaOrigen.Id = IdMonedaOrigen;
     
                    new Moneda_BL().Load(_MonedaOrigen);
    			}
    				
                return _MonedaOrigen;
            } 
    		set
    		{
                if (value != _MonedaOrigen) 
    			{
    				_MonedaOrigen = value;
    				
    				IdMonedaOrigen = _MonedaOrigen.Id;
                
    				OnPropertyChanged("MonedaOrigen");
    			}
    		}
    	}
    	protected internal Moneda_BE _MonedaDestino;
        public virtual Moneda_BE MonedaDestino
    	{
            get 
            {
    			if (_MonedaDestino == null) _MonedaDestino = new Moneda_BE();
    			
    			if (!_MonedaDestino.Loaded && IdMonedaDestino != null)
    			{	
    				_MonedaDestino.Id = IdMonedaDestino;
     
                    new Moneda_BL().Load(_MonedaDestino);
    			}
    				
                return _MonedaDestino;
            } 
    		set
    		{
                if (value != _MonedaDestino) 
    			{
    				_MonedaDestino = value;
    				
    				IdMonedaDestino = _MonedaDestino.Id;
                
    				OnPropertyChanged("MonedaDestino");
    			}
    		}
    	}
    
    }
}

namespace Facel.Business.Entities
{
    [Serializable]
    public partial class Tipo_Cambio_BE : Tipo_Cambio_DE
    {
    }
}

//DataAccess
namespace Facel.Data.Accesses
{
    [Serializable]
    public partial class Tipo_Cambio_DA : AccessEntityId
    {
    	public  Tipo_Cambio_DA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    
        protected override Entity GetDE()
        {
            return new Tipo_Cambio_DE();
        }
    
        public override List<Field> GetFieldsData(Entity paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Tipo_Cambio_DE be = (Tipo_Cambio_DE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<int>>(fields, "id_moneda_origen", System.Data.DbType.Int32, be.IdMonedaOrigen, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<int>>(fields, "id_moneda_destino", System.Data.DbType.Int32, be.IdMonedaDestino, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<System.DateTime>>(fields, "fecha", System.Data.DbType.DateTime, be.Fecha, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<decimal>>(fields, "compra", System.Data.DbType.Decimal, be.Compra, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<decimal>>(fields, "venta", System.Data.DbType.Decimal, be.Venta, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    
        protected override Entity LoadDataReader(DbDataReader paramReader, Entity paramDE)
    	{
            Tipo_Cambio_DE be = (Tipo_Cambio_DE)paramDE;
    
    		be._IdMonedaOrigen = Conversion.To<Nullable<int>>(paramReader[TableColumn("id_moneda_origen")]);
    		be._IdMonedaDestino = Conversion.To<Nullable<int>>(paramReader[TableColumn("id_moneda_destino")]);
    		be._Fecha = Conversion.To<Nullable<System.DateTime>>(paramReader[TableColumn("fecha")]);
    		be._Compra = Conversion.To<Nullable<decimal>>(paramReader[TableColumn("compra")]);
    		be._Venta = Conversion.To<Nullable<decimal>>(paramReader[TableColumn("venta")]);
      
            return be;
    	}
        protected override Entity LoadDataRow(DataRow paramRow, Entity paramDE)
    	{
            Tipo_Cambio_DE be = (Tipo_Cambio_DE)paramDE;
    
    		be._IdMonedaOrigen = Conversion.To<Nullable<int>>(paramRow[TableColumn("id_moneda_origen")]);
    		be._IdMonedaDestino = Conversion.To<Nullable<int>>(paramRow[TableColumn("id_moneda_destino")]);
    		be._Fecha = Conversion.To<Nullable<System.DateTime>>(paramRow[TableColumn("fecha")]);
    		be._Compra = Conversion.To<Nullable<decimal>>(paramRow[TableColumn("compra")]);
    		be._Venta = Conversion.To<Nullable<decimal>>(paramRow[TableColumn("venta")]);
      
            return be;
    	}
        protected override Entity LoadDataParameters(DbParameterCollection paramParameters, Entity paramDE)
    	{
            Tipo_Cambio_DE be = (Tipo_Cambio_DE)paramDE;
    
    		be._IdMonedaOrigen = Conversion.To<Nullable<int>>(paramParameters[TableParameter("id_moneda_origen")].Value);
    		be._IdMonedaDestino = Conversion.To<Nullable<int>>(paramParameters[TableParameter("id_moneda_destino")].Value);
    		be._Fecha = Conversion.To<Nullable<System.DateTime>>(paramParameters[TableParameter("fecha")].Value);
    		be._Compra = Conversion.To<Nullable<decimal>>(paramParameters[TableParameter("compra")].Value);
    		be._Venta = Conversion.To<Nullable<decimal>>(paramParameters[TableParameter("venta")].Value);
      
            return be;
    	}
    
        protected override Entity ClearData(Entity paramDE)
        {
            Tipo_Cambio_DE be = (Tipo_Cambio_DE)paramDE;
    
    		be._IdMonedaOrigen = null;
    		be._IdMonedaDestino = null;
    		be._Fecha = null;
    		be._Compra = null;
    		be._Venta = null;
      
    		be._MonedaOrigen = null;
    		be._MonedaDestino = null;
    
            return be;
        }
    
    }
}

namespace Facel.Business.Accesses
{
    [Serializable]
    public partial class Tipo_Cambio_BA : Tipo_Cambio_DA
    {
    	public  Tipo_Cambio_BA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Tipo_Cambio_BE();
        }
    }
}

//DataLogic
namespace Facel.Data.Logics
{
    [Serializable]
    public partial class Tipo_Cambio_DL : LogicEntity
    {
        protected override Access GetDA()
        {
            return new Tipo_Cambio_DA(TableName, ConnectionStringName);
        }
    	
    	protected override bool ValidateInsertModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            Tipo_Cambio_BE be = (Tipo_Cambio_BE)paramDE;
    
    		
            if (be.IdMonedaOrigen == null)
            {
                paramField = "IdMonedaOrigen";
    			paramMessage = LibraryFramework.V0005_FieldEmpty;
    
                return false;
            }								
    		
            if (be.IdMonedaDestino == null)
            {
                paramField = "IdMonedaDestino";
    			paramMessage = LibraryFramework.V0005_FieldEmpty;
    
                return false;
            }								
      
    		return base.ValidateInsertModel(paramDE, ref paramField, ref paramMessage);
        }
    	protected override bool ValidateDeleteModel(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            Tipo_Cambio_BE be = (Tipo_Cambio_BE)paramDE;
    
            if (paramValidateCascadeIntegrity)
            {
            }
    			     
            return base.ValidateDeleteModel(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);
        }
    	
    	public override byte EraseModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            byte ret = 1;
    
    		Tipo_Cambio_BE be = (Tipo_Cambio_BE)paramDE;
    
    		foreach (Tipo_Cambio_BE e in new Tipo_Cambio_FL().LoadConvert(new Tipo_Cambio_FL().Convert(be), 1))
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
    public partial class Tipo_Cambio_BL : Tipo_Cambio_DL
    {
        protected override Access GetDA()
        {
            return new Tipo_Cambio_BA(TableName, ConnectionStringName);
        }	
    }
    
}

//JoinEntities
namespace Facel.Join.Entities
{
    [Serializable]
    public partial class Tipo_Cambio_JE : EnumerateId
    {
        public virtual Filter<Nullable<int>> IdMonedaOrigen { get; set; }
        public virtual Filter<Nullable<int>> IdMonedaDestino { get; set; }
        public virtual Filter<Nullable<System.DateTime>> Fecha { get; set; }
        public virtual Filter<Nullable<decimal>> Compra { get; set; }
        public virtual Filter<Nullable<decimal>> Venta { get; set; }
    
    	protected Moneda_FE _MonedaOrigen;
        public Moneda_FE MonedaOrigen
    	{
            get 
            {
                _MonedaOrigen = _MonedaOrigen ?? new Moneda_FE();
                return _MonedaOrigen;
            } 
    		set
    		{
    			_MonedaOrigen = value;
    		}
    	}
    	protected Moneda_FE _MonedaDestino;
        public Moneda_FE MonedaDestino
    	{
            get 
            {
                _MonedaDestino = _MonedaDestino ?? new Moneda_FE();
                return _MonedaDestino;
            } 
    		set
    		{
    			_MonedaDestino = value;
    		}
    	}
    }
}

namespace Facel.Filter.Entities
{
    [Serializable]
    public partial class Tipo_Cambio_FE : Tipo_Cambio_JE
    {
    }
}


//JoinAccess
namespace Facel.Join.Accesses
{
    [Serializable]
    public partial class Tipo_Cambio_JA : AccessEnumerateId
    {	
    	public  Tipo_Cambio_JA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Tipo_Cambio_DE();
        }
    	protected override Access GetDA()
        {
            return new Tipo_Cambio_DA(TableName, ConnectionStringName);
        }
    	
    	public override List<Field> GetFieldsData(Enumerate paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Tipo_Cambio_JE be = (Tipo_Cambio_JE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<int>>(fields, "id_moneda_origen", System.Data.DbType.Int32, be.IdMonedaOrigen, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<int>>(fields, "id_moneda_destino", System.Data.DbType.Int32, be.IdMonedaDestino, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<System.DateTime>>(fields, "fecha", System.Data.DbType.DateTime, be.Fecha, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<decimal>>(fields, "compra", System.Data.DbType.Decimal, be.Compra, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<decimal>>(fields, "venta", System.Data.DbType.Decimal, be.Venta, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    	
    	protected override List<Field> GetFieldsJoin(List<Field> paramFields, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Tipo_Cambio_FE be = (Tipo_Cambio_FE)paramDE;
    		
    		foreach (Field f in new Moneda_FL().GetFieldsJoin(be.MonedaOrigen, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias + "__moneda_origen"))
        		paramFields.Add(f);
    		foreach (Field f in new Moneda_FL().GetFieldsJoin(be.MonedaDestino, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias + "__moneda_destino"))
        		paramFields.Add(f);
            
    		return paramFields;
    	}
    	protected override string GetTablesJoin(string paramTables, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "",
    		Dictionary<string, string> paramFieldsJoin = null)
        {
    		Tipo_Cambio_FE be = (Tipo_Cambio_FE)paramDE;	
    	
    		paramTables += new Moneda_FL().GetTablesJoin(be.MonedaOrigen, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias, paramTableAlias + "__moneda_origen", new Dictionary<string, string>() { { "id_moneda_origen", "id" } });	
    		paramTables += new Moneda_FL().GetTablesJoin(be.MonedaDestino, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias, paramTableAlias + "__moneda_destino", new Dictionary<string, string>() { { "id_moneda_destino", "id" } });
    
    		return paramTables;
    	}	
    		
    }
}

namespace Facel.Filter.Accesses
{
    [Serializable]
    public partial class Tipo_Cambio_FA : Tipo_Cambio_JA
    {	
    	public  Tipo_Cambio_FA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Tipo_Cambio_BE();
        }
    	protected override Access GetDA()
        {
            return new Tipo_Cambio_BA(TableName, ConnectionStringName);
        }
    }
}


//JoinLogic
namespace Facel.Join.Logics
{
    [Serializable]
    public partial class Tipo_Cambio_JL : LogicEnumerate
    {
    	protected override Access GetDA()
        {
            return new Tipo_Cambio_JA(TableName, ConnectionStringName);
        }
    	
    	public ObservableCollection<Tipo_Cambio_BE> LoadConvert(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
                int paramTop = 0,
    			int paramRowFrom = 0, int paramRowTo = 0)
        {
        	return new ObservableCollection<Tipo_Cambio_BE>(Load(paramDE, paramMaxDepth, paramTypeLoad, paramIsSourceColumn,
                    paramTop,
    				paramRowFrom, paramRowTo).ConvertAll(x => x as Tipo_Cambio_BE));
        }
    	public Tipo_Cambio_FE Convert(Tipo_Cambio_BE paramDE)
        {
            Tipo_Cambio_FE be = new Tipo_Cambio_FE();
    
    		be.Id = new Filter<Nullable<int>>(paramDE.Id);
    		be.IdMonedaOrigen = new Filter<Nullable<int>>(paramDE.IdMonedaOrigen);
    		be.IdMonedaDestino = new Filter<Nullable<int>>(paramDE.IdMonedaDestino);
    		be.Fecha = new Filter<Nullable<System.DateTime>>(paramDE.Fecha);
    		be.Compra = new Filter<Nullable<decimal>>(paramDE.Compra);
    		be.Venta = new Filter<Nullable<decimal>>(paramDE.Venta);
      
            return be;
        }	
    }
}

namespace Facel.Filter.Logics
{
    [Serializable]
    public partial class Tipo_Cambio_FL : Tipo_Cambio_JL
    {
    	protected override Access GetDA()
        {
            return new Tipo_Cambio_FA(TableName, ConnectionStringName);
        }
    }
}
