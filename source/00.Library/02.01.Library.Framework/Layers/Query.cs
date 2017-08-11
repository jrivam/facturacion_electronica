using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common;
using Library.Common.Data;

namespace Library.Framework.Layers
{
    public class Query
    {        
        public string ConnectionStringName { get; set; }
        public string TableName { get; set; }

        public string CommandText { get; set; }
        public CommandType CommandType { get; set; }
        public Dictionary<string, DbType> CommandParameters { get; set; }

        public Query()
        {
        }
        public Query(string paramConnectionStringName,
            string paramTableName,
            string paramCommandText,
            CommandType paramCommandType = CommandType.StoredProcedure,
            Dictionary<string, DbType> paramCommandParameters = null)
        {
            ConnectionStringName = paramConnectionStringName;
            TableName = paramTableName;

            CommandText = paramCommandText;
            CommandType = paramCommandType;
            CommandParameters = paramCommandParameters;
        }

        public DbCommand GetCommand(Dictionary<string, KeyValuePair<DbType, object>> paramCommandParameters = null)
        {
            return Database.GetCommand(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName, CommandType, CommandText, paramCommandParameters);
        }

        public DataTable GetDataTable(Dictionary<string, KeyValuePair<DbType, object>> paramCommandParameters = null)
        {
            return Database.GetDataTable(ConnectionStringName, GetCommand(paramCommandParameters), TableName);
        }
        public DataTable GetDataCombo(string paramValueName, string paramDisplayName, bool paramAddBlank = false, Dictionary<string, KeyValuePair<DbType, object>> paramCommandParameters = null)
        {
            return Database.GetDataCombo(ConnectionStringName, GetCommand(paramCommandParameters), TableName, paramValueName, paramDisplayName, paramAddBlank);
        }
    }
}
