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
    public partial class AgentesPercepcion_DE
    {
    }
}
namespace Facel.Business.Entities
{
    public partial class AgentesPercepcion_BE
    {
    }
}

//BusinessAccess
namespace Facel.Data.Accesses
{
    public partial class AgentesPercepcion_DA
    {	
    }
}
namespace Facel.Business.Accesses
{
    public partial class AgentesPercepcion_BA
    {
    	//protected override DbCommand GetCommandData(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        //{
            //AgentesPercepcion_BE be = (AgentesPercepcion_BE)paramDE;
    
    		//paramCommand.CommandText = "gsp_agentes_percepcion_data";
            //paramCommand.Parameters.Add(Database.GetParameter(ConnectionStringName, "@param_type", System.Data.DbType.String, paramType));
    
    		//return paramCommand;
        //}
        //protected override DbCommand GetCommandKey(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        //{
            //AgentesPercepcion_BE be = (AgentesPercepcion_BE)paramDE;
    
            //paramCommand.CommandText = "gsp_agentes_percepcion_key";
            //paramCommand.Parameters.Add(Database.GetParameter(ConnectionStringName, "@param_type", System.Data.DbType.String, paramType));
    
            //return paramCommand;
        //}		
    }
}

//BusinessLogic
namespace Facel.Data.Logics
{
    public partial class AgentesPercepcion_DL
    {
        public  AgentesPercepcion_DL(string paramEntityName = "AgentesPercepcion",
    	string paramTableName = "agentes_percepcion", string paramConnectionStringName = FacelMain.ConnectionStringName)
            : base(paramEntityName,
    		paramTableName, paramConnectionStringName)
        {
        }
    }
}
namespace Facel.Business.Logics
{
    public partial class AgentesPercepcion_BL
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
    				string sCurrentTable = "El AgentesPercepcion";
    				
     			}
            }
    
            return ret;
        }	
    }
}

//FilterEntities
namespace Facel.Join.Entities
{
    public partial class AgentesPercepcion_JE
    {
    }
}
namespace Facel.Filter.Entities
{
    public partial class AgentesPercepcion_FE
    {
    }
}

//FilterAccess
namespace Facel.Join.Accesses
{
    public partial class AgentesPercepcion_JA
    {	
    }
}
namespace Facel.Filter.Accesses
{
    public partial class AgentesPercepcion_FA
    {	
    }
}

//FilterLogic
namespace Facel.Join.Logics
{
    public partial class AgentesPercepcion_JL
    {
        public  AgentesPercepcion_JL(string paramEntityName = "AgentesPercepcion",
    	string paramTableName = "agentes_percepcion", string paramConnectionStringName = FacelMain.ConnectionStringName)
            : base(paramEntityName,
    		paramTableName, paramConnectionStringName)
    	{
    	}
    }
}
namespace Facel.Filter.Logics
{
    public partial class AgentesPercepcion_FL
    {
    }
}
	
