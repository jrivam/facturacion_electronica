using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Library.Common.Data.DbProvider
{
    static public class SqlServer
    {
        static public DataTable GetColumns(string paramProviderName, string paramConnectionString, 
            string paramTableName, string paramColumnName = null)
        {
            return Database.GetDataTable(paramProviderName, paramConnectionString,
                Database.GetCommand(paramProviderName, 
                CommandType.Text, "select * from INFORMATION_SCHEMA.COLUMNS where table_name = @paramTableName and (column_name = @paramColumnName or @paramColumnName is null)",
                new Dictionary<string, KeyValuePair<DbType, object>>() { 
                { "@paramTableName", new KeyValuePair<DbType, object>(DbType.String, paramTableName) },
                { "@paramColumnName", new KeyValuePair<DbType, object>(DbType.String, paramColumnName) } 
                }),
                "COLUMNS");
        }
        static public DataTable GetTables(string paramProviderName, string paramConnectionString, 
            string paramTableName = null)
        {
            return Database.GetDataTable(paramProviderName, paramConnectionString,
                Database.GetCommand(paramProviderName,
                CommandType.Text, "select * from INFORMATION_SCHEMA.TABLES where (table_name = @paramTableName or @paramTableName is null)",
                new Dictionary<string, KeyValuePair<DbType, object>>() { 
                { "@paramTableName", new KeyValuePair<DbType, object>(DbType.String, paramTableName) }
                }),
                "TABLES");
        }
        static public DataTable GetProcedures(string paramProviderName, string paramConnectionString, 
            string paramProcedureName = null)
        {
            return Database.GetDataTable(paramProviderName, paramConnectionString,
                Database.GetCommand(paramProviderName,
                CommandType.Text, "select * from INFORMATION_SCHEMA.ROUTINES where (routine_name = @paramRoutineName or @paramRoutineName is null)",
                new Dictionary<string, KeyValuePair<DbType, object>>() { 
                { "@paramRoutineName", new KeyValuePair<DbType, object>(DbType.String, paramProcedureName) }
                }),
                "PROCEDURES");
        }
    }
}
