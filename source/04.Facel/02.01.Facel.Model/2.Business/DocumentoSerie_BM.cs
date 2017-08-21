using System;
using System.Data.Common;
using System.Collections.Generic;
using Library.Common.Data;
using Library.Framework;
using Library.Framework.Layers;

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



//BusinessEntity
namespace Facel.Data.Entities
{
    public partial class DocumentoSerie_DE
    {
    }
}
namespace Facel.Business.Entities
{
    public partial class DocumentoSerie_BE
    {
    }
}

//BusinessAccess
namespace Facel.Data.Accesses
{
    public partial class DocumentoSerie_DA
    {	
    }
}
namespace Facel.Business.Accesses
{
    public partial class DocumentoSerie_BA
    {
    	//protected override DbCommand GetCommandData(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        //{
            //DocumentoSerie_BE be = (DocumentoSerie_BE)paramDE;
    
    		//paramCommand.CommandText = "gsp_documento_serie_data";
            //paramCommand.Parameters.Add(Database.GetParameter(ConnectionStringName, "@param_type", System.Data.DbType.String, paramType));
    
    		//return paramCommand;
        //}
        //protected override DbCommand GetCommandKey(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        //{
            //DocumentoSerie_BE be = (DocumentoSerie_BE)paramDE;
    
            //paramCommand.CommandText = "gsp_documento_serie_key";
            //paramCommand.Parameters.Add(Database.GetParameter(ConnectionStringName, "@param_type", System.Data.DbType.String, paramType));
    
            //return paramCommand;
        //}		
    }
}

//BusinessLogic
namespace Facel.Data.Logics
{
    public partial class DocumentoSerie_DL
    {
        public  DocumentoSerie_DL(string paramEntityName = "DocumentoSerie",
    	string paramTableName = "documento_serie", string paramConnectionStringName = FacelMain.ConnectionStringName)
            : base(paramEntityName,
    		paramTableName, paramConnectionStringName)
        {
        }
    }
}
namespace Facel.Business.Logics
{
    public partial class DocumentoSerie_BL
    {
    	protected override bool ValidateInsert(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            bool ret = base.ValidateInsert(paramDE, ref paramField, ref paramMessage);
    
            if (!ret)
            {
                if (paramMessage == LibraryFramework.V0005_FieldEmpty)
                {
    	
    				if (paramField == "IdDocumentoVenta")
    					paramMessage = string.Format(LibraryFramework.V0005_FieldEmpty, "el DocumentosVenta");
                }
            }
    
            return ret;
        }
    	protected override bool ValidateDelete(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            bool ret = base.ValidateDelete(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);
    
            if (!ret)
            {
                if (paramMessage == LibraryFramework.V0006_TableDependencies)
                {
    				string sCurrentTable = "El DocumentoSerie";
    				
     			}
            }
    
            return ret;
        }	
    }
}

//FilterEntities
namespace Facel.Join.Entities
{
    public partial class DocumentoSerie_JE
    {
    }
}
namespace Facel.Filter.Entities
{
    public partial class DocumentoSerie_FE
    {
    }
}

//FilterAccess
namespace Facel.Join.Accesses
{
    public partial class DocumentoSerie_JA
    {	
    }
}
namespace Facel.Filter.Accesses
{
    public partial class DocumentoSerie_FA
    {	
    }
}

//FilterLogic
namespace Facel.Join.Logics
{
    public partial class DocumentoSerie_JL
    {
        public  DocumentoSerie_JL(string paramEntityName = "DocumentoSerie",
    	string paramTableName = "documento_serie", string paramConnectionStringName = FacelMain.ConnectionStringName)
            : base(paramEntityName,
    		paramTableName, paramConnectionStringName)
    	{
    	}
    }
}
namespace Facel.Filter.Logics
{
    public partial class DocumentoSerie_FL
    {
    }
}
	
