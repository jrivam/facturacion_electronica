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
    public partial class Agentes_Retencion_DE
    {
    }
}
namespace Facel.Business.Entities
{
    public partial class Agentes_Retencion_BE
    {
    }
}

//BusinessAccess
namespace Facel.Data.Accesses
{
    public partial class Agentes_Retencion_DA
    {	
    }
}
namespace Facel.Business.Accesses
{
    public partial class Agentes_Retencion_BA
    {
    	//protected override DbCommand GetCommandData(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        //{
            //Agentes_Retencion_BE be = (Agentes_Retencion_BE)paramDE;
    
    		//paramCommand.CommandText = "gsp_agentes_retencion_data";
            //paramCommand.Parameters.Add(Database.GetParameter(ConnectionStringName, "@param_type", System.Data.DbType.String, paramType));
    
    		//return paramCommand;
        //}
        //protected override DbCommand GetCommandKey(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        //{
            //Agentes_Retencion_BE be = (Agentes_Retencion_BE)paramDE;
    
            //paramCommand.CommandText = "gsp_agentes_retencion_key";
            //paramCommand.Parameters.Add(Database.GetParameter(ConnectionStringName, "@param_type", System.Data.DbType.String, paramType));
    
            //return paramCommand;
        //}		
    }
}

//BusinessLogic
namespace Facel.Data.Logics
{
    public partial class Agentes_Retencion_DL
    {
        public  Agentes_Retencion_DL(string paramEntityName = "Agentes_Retencion",
    	string paramTableName = "agentes_retencion", string paramConnectionStringName = FacelMain.ConnectionStringName)
            : base(paramEntityName,
    		paramTableName, paramConnectionStringName)
        {
        }
    }
}
namespace Facel.Business.Logics
{
    public partial class Agentes_Retencion_BL
    {
    	protected override bool ValidateInsert(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            bool ret = base.ValidateInsert(paramDE, ref paramField, ref paramMessage);
    
            if (!ret)
            {
                if (paramMessage == LibraryFramework.V0005_FieldEmpty)
                {
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
    				string sCurrentTable = "El Retencion";
    				
     			}
            }
    
            return ret;
        }	
    }
}

//FilterEntities
namespace Facel.Join.Entities
{
    public partial class Agentes_Retencion_JE
    {
    }
}
namespace Facel.Filter.Entities
{
    public partial class Agentes_Retencion_FE
    {
    }
}

//FilterAccess
namespace Facel.Join.Accesses
{
    public partial class Agentes_Retencion_JA
    {	
    }
}
namespace Facel.Filter.Accesses
{
    public partial class Agentes_Retencion_FA
    {	
    }
}

//FilterLogic
namespace Facel.Join.Logics
{
    public partial class Agentes_Retencion_JL
    {
        public  Agentes_Retencion_JL(string paramEntityName = "Agentes_Retencion",
    	string paramTableName = "agentes_retencion", string paramConnectionStringName = FacelMain.ConnectionStringName)
            : base(paramEntityName,
    		paramTableName, paramConnectionStringName)
    	{
    	}
    }
}
namespace Facel.Filter.Logics
{
    public partial class Agentes_Retencion_FL
    {
    }
}
	
