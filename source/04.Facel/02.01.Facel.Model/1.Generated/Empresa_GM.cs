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
    public partial class Empresa_DE : EntityId
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
        protected internal string _Direccion;
        public virtual string Direccion
    	{
    	    get { return _Direccion; }
    	    set { if (value != _Direccion) { _Direccion = value; OnPropertyChanged("Direccion"); } }
        }	
        protected internal string _DireccionFiscal;
        public virtual string DireccionFiscal
    	{
    	    get { return _DireccionFiscal; }
    	    set { if (value != _DireccionFiscal) { _DireccionFiscal = value; OnPropertyChanged("DireccionFiscal"); } }
        }	
        protected internal string _Telefono;
        public virtual string Telefono
    	{
    	    get { return _Telefono; }
    	    set { if (value != _Telefono) { _Telefono = value; OnPropertyChanged("Telefono"); } }
        }	
        protected internal string _Email;
        public virtual string Email
    	{
    	    get { return _Email; }
    	    set { if (value != _Email) { _Email = value; OnPropertyChanged("Email"); } }
        }	
        protected internal string _Website;
        public virtual string Website
    	{
    	    get { return _Website; }
    	    set { if (value != _Website) { _Website = value; OnPropertyChanged("Website"); } }
        }	
        protected internal Nullable<bool> _Activo;
        public virtual Nullable<bool> Activo
    	{
    	    get { return _Activo; }
    	    set { if (value != _Activo) { _Activo = value; OnPropertyChanged("Activo"); } }
        }	
        protected internal Nullable<bool> _EsEmisorElectronico;
        public virtual Nullable<bool> EsEmisorElectronico
    	{
    	    get { return _EsEmisorElectronico; }
    	    set { if (value != _EsEmisorElectronico) { _EsEmisorElectronico = value; OnPropertyChanged("EsEmisorElectronico"); } }
        }	
        protected internal string _UsuarioSunat;
        public virtual string UsuarioSunat
    	{
    	    get { return _UsuarioSunat; }
    	    set { if (value != _UsuarioSunat) { _UsuarioSunat = value; OnPropertyChanged("UsuarioSunat"); } }
        }	
        protected internal string _ClaveSunat;
        public virtual string ClaveSunat
    	{
    	    get { return _ClaveSunat; }
    	    set { if (value != _ClaveSunat) { _ClaveSunat = value; OnPropertyChanged("ClaveSunat"); } }
        }	
        protected internal string _RutaFirmaDigital;
        public virtual string RutaFirmaDigital
    	{
    	    get { return _RutaFirmaDigital; }
    	    set { if (value != _RutaFirmaDigital) { _RutaFirmaDigital = value; OnPropertyChanged("RutaFirmaDigital"); } }
        }	
        protected internal string _EmailEnvio;
        public virtual string EmailEnvio
    	{
    	    get { return _EmailEnvio; }
    	    set { if (value != _EmailEnvio) { _EmailEnvio = value; OnPropertyChanged("EmailEnvio"); } }
        }	
        protected internal string _ClaveEmail;
        public virtual string ClaveEmail
    	{
    	    get { return _ClaveEmail; }
    	    set { if (value != _ClaveEmail) { _ClaveEmail = value; OnPropertyChanged("ClaveEmail"); } }
        }	
        protected internal string _SmtpEmail;
        public virtual string SmtpEmail
    	{
    	    get { return _SmtpEmail; }
    	    set { if (value != _SmtpEmail) { _SmtpEmail = value; OnPropertyChanged("SmtpEmail"); } }
        }	
        protected internal Nullable<int> _PuertoEmail;
        public virtual Nullable<int> PuertoEmail
    	{
    	    get { return _PuertoEmail; }
    	    set { if (value != _PuertoEmail) { _PuertoEmail = value; OnPropertyChanged("PuertoEmail"); } }
        }	
        protected internal Nullable<bool> _EsCorporativo;
        public virtual Nullable<bool> EsCorporativo
    	{
    	    get { return _EsCorporativo; }
    	    set { if (value != _EsCorporativo) { _EsCorporativo = value; OnPropertyChanged("EsCorporativo"); } }
        }	
        protected internal string _UbigeoDistrito;
        public virtual string UbigeoDistrito
    	{
    	    get { return _UbigeoDistrito; }
    	    set { if (value != _UbigeoDistrito) { _UbigeoDistrito = value; OnPropertyChanged("UbigeoDistrito"); } }
        }	
        protected internal Nullable<bool> _EsAgentePercepcion;
        public virtual Nullable<bool> EsAgentePercepcion
    	{
    	    get { return _EsAgentePercepcion; }
    	    set { if (value != _EsAgentePercepcion) { _EsAgentePercepcion = value; OnPropertyChanged("EsAgentePercepcion"); } }
        }	
        protected internal Nullable<bool> _EsAgenteRetencion;
        public virtual Nullable<bool> EsAgenteRetencion
    	{
    	    get { return _EsAgenteRetencion; }
    	    set { if (value != _EsAgenteRetencion) { _EsAgenteRetencion = value; OnPropertyChanged("EsAgenteRetencion"); } }
        }	
        protected internal Nullable<bool> _EsBuenContribuyente;
        public virtual Nullable<bool> EsBuenContribuyente
    	{
    	    get { return _EsBuenContribuyente; }
    	    set { if (value != _EsBuenContribuyente) { _EsBuenContribuyente = value; OnPropertyChanged("EsBuenContribuyente"); } }
        }	
        protected internal Nullable<bool> _Homologado;
        public virtual Nullable<bool> Homologado
    	{
    	    get { return _Homologado; }
    	    set { if (value != _Homologado) { _Homologado = value; OnPropertyChanged("Homologado"); } }
        }	
        protected internal Nullable<bool> _EnPruebas;
        public virtual Nullable<bool> EnPruebas
    	{
    	    get { return _EnPruebas; }
    	    set { if (value != _EnPruebas) { _EnPruebas = value; OnPropertyChanged("EnPruebas"); } }
        }	
        protected internal Nullable<bool> _EnProduccion;
        public virtual Nullable<bool> EnProduccion
    	{
    	    get { return _EnProduccion; }
    	    set { if (value != _EnProduccion) { _EnProduccion = value; OnPropertyChanged("EnProduccion"); } }
        }	
        protected internal byte[] _Logo;
        public virtual byte[] Logo
    	{
    	    get { return _Logo; }
    	    set { if (value != _Logo) { _Logo = value; OnPropertyChanged("Logo"); } }
        }	
        protected internal Nullable<bool> _EsSsl;
        public virtual Nullable<bool> EsSsl
    	{
    	    get { return _EsSsl; }
    	    set { if (value != _EsSsl) { _EsSsl = value; OnPropertyChanged("EsSsl"); } }
        }	
    
    	protected internal Nullable<int> _IdEmpresaPadre;
    	public virtual Nullable<int> IdEmpresaPadre
    	{
    		get
    		{
    			return _IdEmpresaPadre;
    		}
    		set
    		{
                if (value != _IdEmpresaPadre) 
    			{
    				_IdEmpresaPadre = value;	
    				
    				Empresa.Id = _IdEmpresaPadre;						
    	            
    				OnPropertyChanged("IdEmpresaPadre");
    			}		
    		}
    	}	
    
    	protected internal Empresa_BE _Empresa;
        public virtual Empresa_BE Empresa
    	{
            get 
            {
    			if (_Empresa == null) _Empresa = new Empresa_BE();
    			
    			if (!_Empresa.Loaded && IdEmpresaPadre != null)
    			{	
    				_Empresa.Id = IdEmpresaPadre;
     
                    new Empresa_BL().Load(_Empresa);
    			}
    				
                return _Empresa;
            } 
    		set
    		{
                if (value != _Empresa) 
    			{
    				_Empresa = value;
    				
    				IdEmpresaPadre = _Empresa.Id;
                
    				OnPropertyChanged("Empresa");
    			}
    		}
    	}
    
        public virtual ObservableCollection<Sucursal_BE> SucursalesGet(int paramMaxDepth = 1)
    	{
    		if (this.Id != null)
                return new ObservableCollection<Sucursal_BE>(new Sucursal_FL().LoadConvert(new Sucursal_FE() { Id = new Filter<Nullable<int>>(this.Id) }, paramMaxDepth));	
    
            return new ObservableCollection<Sucursal_BE>();
    	}
        public virtual ObservableCollection<Sucursal_BE> SucursalesLoad(int paramMaxDepth = 1)
    	{
    		return Sucursales = SucursalesGet(paramMaxDepth);
    	}	
        public virtual ObservableCollection<Sucursal_BE> Sucursales { get; set; }
        public virtual ObservableCollection<Empresa_BE> EmpresaHijosGet(int paramMaxDepth = 1)
    	{
    		if (this.Id != null)
                return new ObservableCollection<Empresa_BE>(new Empresa_FL().LoadConvert(new Empresa_FE() { IdEmpresaPadre = new Filter<Nullable<int>>(this.Id) }, paramMaxDepth));	
    
            return new ObservableCollection<Empresa_BE>();
    	}
        public virtual ObservableCollection<Empresa_BE> EmpresaHijosLoad(int paramMaxDepth = 1)
    	{
    		return EmpresaHijos = EmpresaHijosGet(paramMaxDepth);
    	}	
        public virtual ObservableCollection<Empresa_BE> EmpresaHijos { get; set; }
    }
}

namespace Facel.Business.Entities
{
    [Serializable]
    public partial class Empresa_BE : Empresa_DE
    {
    }
}

//DataAccess
namespace Facel.Data.Accesses
{
    [Serializable]
    public partial class Empresa_DA : AccessEntityId
    {
    	public  Empresa_DA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    
        protected override Entity GetDE()
        {
            return new Empresa_DE();
        }
    
        public override List<Field> GetFieldsData(Entity paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Empresa_DE be = (Empresa_DE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<int>>(fields, "id_empresa_padre", System.Data.DbType.Int32, be.IdEmpresaPadre, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ruc", System.Data.DbType.String, be.Ruc, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "razon_social", System.Data.DbType.String, be.RazonSocial, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "direccion", System.Data.DbType.String, be.Direccion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "direccion_fiscal", System.Data.DbType.String, be.DireccionFiscal, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "telefono", System.Data.DbType.String, be.Telefono, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "email", System.Data.DbType.String, be.Email, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "website", System.Data.DbType.String, be.Website, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "activo", System.Data.DbType.Boolean, be.Activo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_emisor_electronico", System.Data.DbType.Boolean, be.EsEmisorElectronico, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "usuario_sunat", System.Data.DbType.String, be.UsuarioSunat, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "clave_sunat", System.Data.DbType.String, be.ClaveSunat, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ruta_firma_digital", System.Data.DbType.String, be.RutaFirmaDigital, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "email_envio", System.Data.DbType.String, be.EmailEnvio, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "clave_email", System.Data.DbType.String, be.ClaveEmail, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "smtp_email", System.Data.DbType.String, be.SmtpEmail, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<int>>(fields, "puerto_email", System.Data.DbType.Int32, be.PuertoEmail, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_corporativo", System.Data.DbType.Boolean, be.EsCorporativo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ubigeo_distrito", System.Data.DbType.String, be.UbigeoDistrito, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_agente_percepcion", System.Data.DbType.Boolean, be.EsAgentePercepcion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_agente_retencion", System.Data.DbType.Boolean, be.EsAgenteRetencion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_buen_contribuyente", System.Data.DbType.Boolean, be.EsBuenContribuyente, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "homologado", System.Data.DbType.Boolean, be.Homologado, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "en_pruebas", System.Data.DbType.Boolean, be.EnPruebas, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "en_produccion", System.Data.DbType.Boolean, be.EnProduccion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<byte[]>(fields, "logo", System.Data.DbType.Binary, be.Logo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_ssl", System.Data.DbType.Boolean, be.EsSsl, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    
        protected override Entity LoadDataReader(DbDataReader paramReader, Entity paramDE)
    	{
            Empresa_DE be = (Empresa_DE)paramDE;
    
    		be._IdEmpresaPadre = Conversion.To<Nullable<int>>(paramReader[TableColumn("id_empresa_padre")]);
    		be._Ruc = Conversion.To<string>(paramReader[TableColumn("ruc")]);
    		be._RazonSocial = Conversion.To<string>(paramReader[TableColumn("razon_social")]);
    		be._Direccion = Conversion.To<string>(paramReader[TableColumn("direccion")]);
    		be._DireccionFiscal = Conversion.To<string>(paramReader[TableColumn("direccion_fiscal")]);
    		be._Telefono = Conversion.To<string>(paramReader[TableColumn("telefono")]);
    		be._Email = Conversion.To<string>(paramReader[TableColumn("email")]);
    		be._Website = Conversion.To<string>(paramReader[TableColumn("website")]);
    		be._Activo = Conversion.To<Nullable<bool>>(paramReader[TableColumn("activo")]);
    		be._EsEmisorElectronico = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_emisor_electronico")]);
    		be._UsuarioSunat = Conversion.To<string>(paramReader[TableColumn("usuario_sunat")]);
    		be._ClaveSunat = Conversion.To<string>(paramReader[TableColumn("clave_sunat")]);
    		be._RutaFirmaDigital = Conversion.To<string>(paramReader[TableColumn("ruta_firma_digital")]);
    		be._EmailEnvio = Conversion.To<string>(paramReader[TableColumn("email_envio")]);
    		be._ClaveEmail = Conversion.To<string>(paramReader[TableColumn("clave_email")]);
    		be._SmtpEmail = Conversion.To<string>(paramReader[TableColumn("smtp_email")]);
    		be._PuertoEmail = Conversion.To<Nullable<int>>(paramReader[TableColumn("puerto_email")]);
    		be._EsCorporativo = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_corporativo")]);
    		be._UbigeoDistrito = Conversion.To<string>(paramReader[TableColumn("ubigeo_distrito")]);
    		be._EsAgentePercepcion = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_agente_percepcion")]);
    		be._EsAgenteRetencion = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_agente_retencion")]);
    		be._EsBuenContribuyente = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_buen_contribuyente")]);
    		be._Homologado = Conversion.To<Nullable<bool>>(paramReader[TableColumn("homologado")]);
    		be._EnPruebas = Conversion.To<Nullable<bool>>(paramReader[TableColumn("en_pruebas")]);
    		be._EnProduccion = Conversion.To<Nullable<bool>>(paramReader[TableColumn("en_produccion")]);
    		be._Logo = Conversion.To<byte[]>(paramReader[TableColumn("logo")]);
    		be._EsSsl = Conversion.To<Nullable<bool>>(paramReader[TableColumn("es_ssl")]);
      
            return be;
    	}
        protected override Entity LoadDataRow(DataRow paramRow, Entity paramDE)
    	{
            Empresa_DE be = (Empresa_DE)paramDE;
    
    		be._IdEmpresaPadre = Conversion.To<Nullable<int>>(paramRow[TableColumn("id_empresa_padre")]);
    		be._Ruc = Conversion.To<string>(paramRow[TableColumn("ruc")]);
    		be._RazonSocial = Conversion.To<string>(paramRow[TableColumn("razon_social")]);
    		be._Direccion = Conversion.To<string>(paramRow[TableColumn("direccion")]);
    		be._DireccionFiscal = Conversion.To<string>(paramRow[TableColumn("direccion_fiscal")]);
    		be._Telefono = Conversion.To<string>(paramRow[TableColumn("telefono")]);
    		be._Email = Conversion.To<string>(paramRow[TableColumn("email")]);
    		be._Website = Conversion.To<string>(paramRow[TableColumn("website")]);
    		be._Activo = Conversion.To<Nullable<bool>>(paramRow[TableColumn("activo")]);
    		be._EsEmisorElectronico = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_emisor_electronico")]);
    		be._UsuarioSunat = Conversion.To<string>(paramRow[TableColumn("usuario_sunat")]);
    		be._ClaveSunat = Conversion.To<string>(paramRow[TableColumn("clave_sunat")]);
    		be._RutaFirmaDigital = Conversion.To<string>(paramRow[TableColumn("ruta_firma_digital")]);
    		be._EmailEnvio = Conversion.To<string>(paramRow[TableColumn("email_envio")]);
    		be._ClaveEmail = Conversion.To<string>(paramRow[TableColumn("clave_email")]);
    		be._SmtpEmail = Conversion.To<string>(paramRow[TableColumn("smtp_email")]);
    		be._PuertoEmail = Conversion.To<Nullable<int>>(paramRow[TableColumn("puerto_email")]);
    		be._EsCorporativo = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_corporativo")]);
    		be._UbigeoDistrito = Conversion.To<string>(paramRow[TableColumn("ubigeo_distrito")]);
    		be._EsAgentePercepcion = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_agente_percepcion")]);
    		be._EsAgenteRetencion = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_agente_retencion")]);
    		be._EsBuenContribuyente = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_buen_contribuyente")]);
    		be._Homologado = Conversion.To<Nullable<bool>>(paramRow[TableColumn("homologado")]);
    		be._EnPruebas = Conversion.To<Nullable<bool>>(paramRow[TableColumn("en_pruebas")]);
    		be._EnProduccion = Conversion.To<Nullable<bool>>(paramRow[TableColumn("en_produccion")]);
    		be._Logo = Conversion.To<byte[]>(paramRow[TableColumn("logo")]);
    		be._EsSsl = Conversion.To<Nullable<bool>>(paramRow[TableColumn("es_ssl")]);
      
            return be;
    	}
        protected override Entity LoadDataParameters(DbParameterCollection paramParameters, Entity paramDE)
    	{
            Empresa_DE be = (Empresa_DE)paramDE;
    
    		be._IdEmpresaPadre = Conversion.To<Nullable<int>>(paramParameters[TableParameter("id_empresa_padre")].Value);
    		be._Ruc = Conversion.To<string>(paramParameters[TableParameter("ruc")].Value);
    		be._RazonSocial = Conversion.To<string>(paramParameters[TableParameter("razon_social")].Value);
    		be._Direccion = Conversion.To<string>(paramParameters[TableParameter("direccion")].Value);
    		be._DireccionFiscal = Conversion.To<string>(paramParameters[TableParameter("direccion_fiscal")].Value);
    		be._Telefono = Conversion.To<string>(paramParameters[TableParameter("telefono")].Value);
    		be._Email = Conversion.To<string>(paramParameters[TableParameter("email")].Value);
    		be._Website = Conversion.To<string>(paramParameters[TableParameter("website")].Value);
    		be._Activo = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("activo")].Value);
    		be._EsEmisorElectronico = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_emisor_electronico")].Value);
    		be._UsuarioSunat = Conversion.To<string>(paramParameters[TableParameter("usuario_sunat")].Value);
    		be._ClaveSunat = Conversion.To<string>(paramParameters[TableParameter("clave_sunat")].Value);
    		be._RutaFirmaDigital = Conversion.To<string>(paramParameters[TableParameter("ruta_firma_digital")].Value);
    		be._EmailEnvio = Conversion.To<string>(paramParameters[TableParameter("email_envio")].Value);
    		be._ClaveEmail = Conversion.To<string>(paramParameters[TableParameter("clave_email")].Value);
    		be._SmtpEmail = Conversion.To<string>(paramParameters[TableParameter("smtp_email")].Value);
    		be._PuertoEmail = Conversion.To<Nullable<int>>(paramParameters[TableParameter("puerto_email")].Value);
    		be._EsCorporativo = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_corporativo")].Value);
    		be._UbigeoDistrito = Conversion.To<string>(paramParameters[TableParameter("ubigeo_distrito")].Value);
    		be._EsAgentePercepcion = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_agente_percepcion")].Value);
    		be._EsAgenteRetencion = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_agente_retencion")].Value);
    		be._EsBuenContribuyente = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_buen_contribuyente")].Value);
    		be._Homologado = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("homologado")].Value);
    		be._EnPruebas = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("en_pruebas")].Value);
    		be._EnProduccion = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("en_produccion")].Value);
    		be._Logo = Conversion.To<byte[]>(paramParameters[TableParameter("logo")].Value);
    		be._EsSsl = Conversion.To<Nullable<bool>>(paramParameters[TableParameter("es_ssl")].Value);
      
            return be;
    	}
    
        protected override Entity ClearData(Entity paramDE)
        {
            Empresa_DE be = (Empresa_DE)paramDE;
    
    		be._IdEmpresaPadre = null;
    		be._Ruc = null;
    		be._RazonSocial = null;
    		be._Direccion = null;
    		be._DireccionFiscal = null;
    		be._Telefono = null;
    		be._Email = null;
    		be._Website = null;
    		be._Activo = null;
    		be._EsEmisorElectronico = null;
    		be._UsuarioSunat = null;
    		be._ClaveSunat = null;
    		be._RutaFirmaDigital = null;
    		be._EmailEnvio = null;
    		be._ClaveEmail = null;
    		be._SmtpEmail = null;
    		be._PuertoEmail = null;
    		be._EsCorporativo = null;
    		be._UbigeoDistrito = null;
    		be._EsAgentePercepcion = null;
    		be._EsAgenteRetencion = null;
    		be._EsBuenContribuyente = null;
    		be._Homologado = null;
    		be._EnPruebas = null;
    		be._EnProduccion = null;
    		be._Logo = null;
    		be._EsSsl = null;
      
    		be._Empresa = null;
    
            return be;
        }
    
    }
}

namespace Facel.Business.Accesses
{
    [Serializable]
    public partial class Empresa_BA : Empresa_DA
    {
    	public  Empresa_BA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Empresa_BE();
        }
    }
}

//DataLogic
namespace Facel.Data.Logics
{
    [Serializable]
    public partial class Empresa_DL : LogicEntity
    {
        protected override Access GetDA()
        {
            return new Empresa_DA(TableName, ConnectionStringName);
        }
    	
    	protected override bool ValidateInsertModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            Empresa_BE be = (Empresa_BE)paramDE;
    
      
    		return base.ValidateInsertModel(paramDE, ref paramField, ref paramMessage);
        }
    	protected override bool ValidateDeleteModel(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            Empresa_BE be = (Empresa_BE)paramDE;
    
            if (paramValidateCascadeIntegrity)
            {
                if (new Sucursal_BL().Count(new Sucursal_BE() { Id = be.Id }) > 0)
                {
                    paramField = "Sucursal";
    				paramMessage = LibraryFramework.V0006_TableDependencies;
    
                    return false;
                }
                if (new Empresa_BL().Count(new Empresa_BE() { IdEmpresaPadre = be.Id }) > 0)
                {
                    paramField = "Empresa";
    				paramMessage = LibraryFramework.V0006_TableDependencies;
    
                    return false;
                }
            }
    			     
            return base.ValidateDeleteModel(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);
        }
    	
    	public override byte EraseModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            byte ret = 1;
    
    		Empresa_BE be = (Empresa_BE)paramDE;
    
    		foreach (Empresa_BE e in new Empresa_FL().LoadConvert(new Empresa_FL().Convert(be), 1))
    		{
    			if (ret == 1)
    	            ret = new Sucursal_BL().Erase(new Sucursal_BE() { Id = e.Id }, false, paramIsSourceColumn); 
    			if (ret == 1)
    	            ret = new Empresa_BL().Erase(new Empresa_BE() { IdEmpresaPadre = e.Id }, false, paramIsSourceColumn); 
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
    public partial class Empresa_BL : Empresa_DL
    {
        protected override Access GetDA()
        {
            return new Empresa_BA(TableName, ConnectionStringName);
        }	
    }
    
}

//JoinEntities
namespace Facel.Join.Entities
{
    [Serializable]
    public partial class Empresa_JE : EnumerateId
    {
        public virtual Filter<Nullable<int>> IdEmpresaPadre { get; set; }
        public virtual Filter<string> Ruc { get; set; }
        public virtual Filter<string> RazonSocial { get; set; }
        public virtual Filter<string> Direccion { get; set; }
        public virtual Filter<string> DireccionFiscal { get; set; }
        public virtual Filter<string> Telefono { get; set; }
        public virtual Filter<string> Email { get; set; }
        public virtual Filter<string> Website { get; set; }
        public virtual Filter<Nullable<bool>> Activo { get; set; }
        public virtual Filter<Nullable<bool>> EsEmisorElectronico { get; set; }
        public virtual Filter<string> UsuarioSunat { get; set; }
        public virtual Filter<string> ClaveSunat { get; set; }
        public virtual Filter<string> RutaFirmaDigital { get; set; }
        public virtual Filter<string> EmailEnvio { get; set; }
        public virtual Filter<string> ClaveEmail { get; set; }
        public virtual Filter<string> SmtpEmail { get; set; }
        public virtual Filter<Nullable<int>> PuertoEmail { get; set; }
        public virtual Filter<Nullable<bool>> EsCorporativo { get; set; }
        public virtual Filter<string> UbigeoDistrito { get; set; }
        public virtual Filter<Nullable<bool>> EsAgentePercepcion { get; set; }
        public virtual Filter<Nullable<bool>> EsAgenteRetencion { get; set; }
        public virtual Filter<Nullable<bool>> EsBuenContribuyente { get; set; }
        public virtual Filter<Nullable<bool>> Homologado { get; set; }
        public virtual Filter<Nullable<bool>> EnPruebas { get; set; }
        public virtual Filter<Nullable<bool>> EnProduccion { get; set; }
        public virtual Filter<byte[]> Logo { get; set; }
        public virtual Filter<Nullable<bool>> EsSsl { get; set; }
    
    	protected Empresa_FE _EmpresaPadre;
        public Empresa_FE EmpresaPadre
    	{
            get 
            {
                _EmpresaPadre = _EmpresaPadre ?? new Empresa_FE();
                return _EmpresaPadre;
            } 
    		set
    		{
    			_EmpresaPadre = value;
    		}
    	}
    }
}

namespace Facel.Filter.Entities
{
    [Serializable]
    public partial class Empresa_FE : Empresa_JE
    {
    }
}


//JoinAccess
namespace Facel.Join.Accesses
{
    [Serializable]
    public partial class Empresa_JA : AccessEnumerateId
    {	
    	public  Empresa_JA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Empresa_DE();
        }
    	protected override Access GetDA()
        {
            return new Empresa_DA(TableName, ConnectionStringName);
        }
    	
    	public override List<Field> GetFieldsData(Enumerate paramDE, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Empresa_JE be = (Empresa_JE)paramDE;
    
            List<Field> fields = new List<Field>();
    
            fields = AddField<Nullable<int>>(fields, "id_empresa_padre", System.Data.DbType.Int32, be.IdEmpresaPadre, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ruc", System.Data.DbType.String, be.Ruc, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "razon_social", System.Data.DbType.String, be.RazonSocial, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "direccion", System.Data.DbType.String, be.Direccion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "direccion_fiscal", System.Data.DbType.String, be.DireccionFiscal, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "telefono", System.Data.DbType.String, be.Telefono, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "email", System.Data.DbType.String, be.Email, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "website", System.Data.DbType.String, be.Website, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "activo", System.Data.DbType.Boolean, be.Activo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_emisor_electronico", System.Data.DbType.Boolean, be.EsEmisorElectronico, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "usuario_sunat", System.Data.DbType.String, be.UsuarioSunat, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "clave_sunat", System.Data.DbType.String, be.ClaveSunat, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ruta_firma_digital", System.Data.DbType.String, be.RutaFirmaDigital, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "email_envio", System.Data.DbType.String, be.EmailEnvio, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "clave_email", System.Data.DbType.String, be.ClaveEmail, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "smtp_email", System.Data.DbType.String, be.SmtpEmail, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<int>>(fields, "puerto_email", System.Data.DbType.Int32, be.PuertoEmail, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_corporativo", System.Data.DbType.Boolean, be.EsCorporativo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<string>(fields, "ubigeo_distrito", System.Data.DbType.String, be.UbigeoDistrito, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_agente_percepcion", System.Data.DbType.Boolean, be.EsAgentePercepcion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_agente_retencion", System.Data.DbType.Boolean, be.EsAgenteRetencion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_buen_contribuyente", System.Data.DbType.Boolean, be.EsBuenContribuyente, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "homologado", System.Data.DbType.Boolean, be.Homologado, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "en_pruebas", System.Data.DbType.Boolean, be.EnPruebas, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "en_produccion", System.Data.DbType.Boolean, be.EnProduccion, paramIsSourceColumn, paramTableAlias);
            fields = AddField<byte[]>(fields, "logo", System.Data.DbType.Binary, be.Logo, paramIsSourceColumn, paramTableAlias);
            fields = AddField<Nullable<bool>>(fields, "es_ssl", System.Data.DbType.Boolean, be.EsSsl, paramIsSourceColumn, paramTableAlias);
            
    		return fields;
        }
    	
    	protected override List<Field> GetFieldsJoin(List<Field> paramFields, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "")
        {
            Empresa_FE be = (Empresa_FE)paramDE;
    		
            
    		return paramFields;
    	}
    	protected override string GetTablesJoin(string paramTables, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
    		string paramTableAlias = "",
    		Dictionary<string, string> paramFieldsJoin = null)
        {
    		Empresa_FE be = (Empresa_FE)paramDE;	
    
    
    		return paramTables;
    	}	
    		
    }
}

namespace Facel.Filter.Accesses
{
    [Serializable]
    public partial class Empresa_FA : Empresa_JA
    {	
    	public  Empresa_FA(string paramTableName, string paramConnectionStringName)
            : base(paramTableName, paramConnectionStringName)
    	{
    	}
    	
    	protected override Entity GetDE()
        {
            return new Empresa_BE();
        }
    	protected override Access GetDA()
        {
            return new Empresa_BA(TableName, ConnectionStringName);
        }
    }
}


//JoinLogic
namespace Facel.Join.Logics
{
    [Serializable]
    public partial class Empresa_JL : LogicEnumerate
    {
    	protected override Access GetDA()
        {
            return new Empresa_JA(TableName, ConnectionStringName);
        }
    	
    	public ObservableCollection<Empresa_BE> LoadConvert(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
                int paramTop = 0,
    			int paramRowFrom = 0, int paramRowTo = 0)
        {
        	return new ObservableCollection<Empresa_BE>(Load(paramDE, paramMaxDepth, paramTypeLoad, paramIsSourceColumn,
                    paramTop,
    				paramRowFrom, paramRowTo).ConvertAll(x => x as Empresa_BE));
        }
    	public Empresa_FE Convert(Empresa_BE paramDE)
        {
            Empresa_FE be = new Empresa_FE();
    
    		be.Id = new Filter<Nullable<int>>(paramDE.Id);
    		be.IdEmpresaPadre = new Filter<Nullable<int>>(paramDE.IdEmpresaPadre);
    		be.Ruc = new Filter<string>(paramDE.Ruc);
    		be.RazonSocial = new Filter<string>(paramDE.RazonSocial);
    		be.Direccion = new Filter<string>(paramDE.Direccion);
    		be.DireccionFiscal = new Filter<string>(paramDE.DireccionFiscal);
    		be.Telefono = new Filter<string>(paramDE.Telefono);
    		be.Email = new Filter<string>(paramDE.Email);
    		be.Website = new Filter<string>(paramDE.Website);
    		be.Activo = new Filter<Nullable<bool>>(paramDE.Activo);
    		be.EsEmisorElectronico = new Filter<Nullable<bool>>(paramDE.EsEmisorElectronico);
    		be.UsuarioSunat = new Filter<string>(paramDE.UsuarioSunat);
    		be.ClaveSunat = new Filter<string>(paramDE.ClaveSunat);
    		be.RutaFirmaDigital = new Filter<string>(paramDE.RutaFirmaDigital);
    		be.EmailEnvio = new Filter<string>(paramDE.EmailEnvio);
    		be.ClaveEmail = new Filter<string>(paramDE.ClaveEmail);
    		be.SmtpEmail = new Filter<string>(paramDE.SmtpEmail);
    		be.PuertoEmail = new Filter<Nullable<int>>(paramDE.PuertoEmail);
    		be.EsCorporativo = new Filter<Nullable<bool>>(paramDE.EsCorporativo);
    		be.UbigeoDistrito = new Filter<string>(paramDE.UbigeoDistrito);
    		be.EsAgentePercepcion = new Filter<Nullable<bool>>(paramDE.EsAgentePercepcion);
    		be.EsAgenteRetencion = new Filter<Nullable<bool>>(paramDE.EsAgenteRetencion);
    		be.EsBuenContribuyente = new Filter<Nullable<bool>>(paramDE.EsBuenContribuyente);
    		be.Homologado = new Filter<Nullable<bool>>(paramDE.Homologado);
    		be.EnPruebas = new Filter<Nullable<bool>>(paramDE.EnPruebas);
    		be.EnProduccion = new Filter<Nullable<bool>>(paramDE.EnProduccion);
    		be.Logo = new Filter<byte[]>(paramDE.Logo);
    		be.EsSsl = new Filter<Nullable<bool>>(paramDE.EsSsl);
      
            return be;
        }	
    }
}

namespace Facel.Filter.Logics
{
    [Serializable]
    public partial class Empresa_FL : Empresa_JL
    {
    	protected override Access GetDA()
        {
            return new Empresa_FA(TableName, ConnectionStringName);
        }
    }
}

