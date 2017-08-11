using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common.Data.DbProvider;
using System.Configuration;
using System.Reflection;
using System.ComponentModel;

namespace Library.Common.Data
{
    public enum TypeLoad
    {
        DataReader,
        DataRow
    }

    static public class Database
    {
        public static DbType GetDBType(string paramProviderName, Type paramType)
        {
            DbParameter parameter = CreateParameter(paramProviderName);
            TypeConverter converter = TypeDescriptor.GetConverter(parameter.DbType);

            parameter.DbType = (DbType)converter.ConvertFrom(paramType.Name);

            return parameter.DbType;
        }

        static public ConnectionStringSettings GetConnectionStringSettings(string paramConnectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[paramConnectionStringName];
        }
        static public DbConnectionStringBuilder GetBuilder(string paramConnectionString)
        {
            return new DbConnectionStringBuilder() { ConnectionString = paramConnectionString };
        }
        static public DbProviderFactory GetFactory(string paramProviderName)
        {
            return DbProviderFactories.GetFactory(paramProviderName);
        }

        static public string GetConnectionStringKey(string paramConnectionStringName, string paramKey)
        {
            return GetBuilder(GetConnectionStringSettings(paramConnectionStringName).ConnectionString)[paramKey].ToString();
        }

        static public DbConnection CreateConnection(string paramProviderName)
        {
            return GetFactory(paramProviderName).CreateConnection();
        }
        static public DbConnection GetConnection(string paramConnectionStringName)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return GetConnection(ConnectionString.ProviderName, ConnectionString.ConnectionString);
        }
        static public DbConnection GetConnection(string paramProviderName, string paramConnectionString)
        {
            DbConnection connection = CreateConnection(paramProviderName);
            connection.ConnectionString = paramConnectionString;

            return connection;
        }

        static public DbDataAdapter CreateDataAdapter(string paramProviderName)
        {
            return GetFactory(paramProviderName).CreateDataAdapter();
        }
        static public DbDataAdapter GetDataAdapter(string paramProviderName, 
            DbCommand paramSelectCommand = null)
        {
            DbDataAdapter adapter = CreateDataAdapter(paramProviderName);
            adapter.SelectCommand = paramSelectCommand;
            return adapter;
        }

        static public DbParameter CreateParameter(string paramProviderName)
        {
            return GetFactory(paramProviderName).CreateParameter();
        }
        static public DbParameter GetParameter(string paramProviderName, 
            string paramParameterName, System.Data.DbType paramDbType, object paramValue = null, string paramSourceColumnName = null, bool paramIsSourceColumn = false, System.Data.ParameterDirection paramParameterDirection = ParameterDirection.Input)
        {
            DbParameter parameter = CreateParameter(paramProviderName);
            parameter.ParameterName = paramParameterName;
            parameter.DbType = paramDbType;
            parameter.Value = Conversion.NullCoalescing(paramValue, DBNull.Value);
            parameter.Direction = paramParameterDirection;
            if (paramIsSourceColumn)
                if (!string.IsNullOrWhiteSpace(paramSourceColumnName))
                    parameter.SourceColumn = paramSourceColumnName;

            return parameter;
        }

        static public DbCommand CreateCommand(string paramProviderName)
        {
            return GetFactory(paramProviderName).CreateCommand();
        }
        static public DbCommand GetCommand(string paramProviderName, 
            CommandType paramCommandType = CommandType.StoredProcedure, string paramCommandText = "", Dictionary<string, KeyValuePair<DbType, object>> paramCommandParameters = null)
        {
            DbCommand command = CreateCommand(paramProviderName);
            command.CommandType = paramCommandType;
            command.CommandText = paramCommandText;

            if (paramCommandParameters != null)
                foreach (KeyValuePair<string, KeyValuePair<DbType, object>> vp in paramCommandParameters)
                    command.Parameters.Add(GetParameter(paramProviderName, vp.Key, vp.Value.Key, vp.Value.Value));

            return command;
        }
  
        //--------------------------

        static public void SetCommandParameterValue(DbCommand paramCommand, string paramParameterName, object paramParameterValue)
        {
            paramCommand.Parameters[paramParameterName].SourceColumn = null;
            paramCommand.Parameters[paramParameterName].Value = paramParameterValue;
        }
        static public DbDataAdapter SetAdapterParameterValues(DbDataAdapter paramDataAdapter, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            if (paramAdapterParameterValues != null)
                foreach (KeyValuePair<string, object> kvp in paramAdapterParameterValues)
                {
                    SetCommandParameterValue(paramDataAdapter.InsertCommand, kvp.Key, kvp.Value);
                    SetCommandParameterValue(paramDataAdapter.UpdateCommand, kvp.Key, kvp.Value);
                }
            return paramDataAdapter;
        }

        static public DbDataReader ExecuteReader(DbConnection paramConnection, DbCommand paramCommand)
        {
            paramCommand.Connection = paramConnection;
            return paramCommand.ExecuteReader();
        }

        //---------------------------

        static public int ExecuteNonQuery(string paramConnectionStringName, 
            DbCommand paramCommand)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return ExecuteNonQuery(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramCommand);
        }
        static public int ExecuteNonQuery(string paramProviderName, string paramConnectionString, 
            DbCommand paramCommand)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            int ret = ExecuteNonQuery(connection, paramCommand);

            connection.Close();

            return ret;
        }
        static public int ExecuteNonQuery(DbConnection paramConnection, 
            DbCommand paramCommand)
        {
            paramCommand.Connection = paramConnection;
            return paramCommand.ExecuteNonQuery();
        }

        static public T ExecuteScalar<T>(string paramConnectionStringName,
            DbCommand paramCommand)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return ExecuteScalar<T>(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramCommand);
        }
        static public T ExecuteScalar<T>(string paramProviderName, string paramConnectionString, 
            DbCommand paramCommand)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            T ret = ExecuteScalar<T>(connection, paramCommand);

            connection.Close();

            return ret;
        }
        static public T ExecuteScalar<T>(DbConnection paramConnection, 
            DbCommand paramCommand)
        {
            paramCommand.Connection = paramConnection;
            return Conversion.To<T>(paramCommand.ExecuteScalar());
        }

        //-------------------------------

        static public DataTable GetDataCombo(string paramConnectionStringName, 
            DbCommand paramCommand, string paramTableName, string paramValueName, string paramDisplayName, bool paramAddBlank = false)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return GetDataCombo(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramCommand, paramTableName, paramValueName, paramDisplayName, paramAddBlank);
        }
        static public DataTable GetDataCombo(string paramProviderName, string paramConnectionString, 
            DbCommand paramCommand, string paramTableName, string paramValueName, string paramDisplayName, bool paramAddBlank = false)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            DataTable ret = GetDataCombo(connection, paramCommand, paramTableName, paramValueName, paramDisplayName, paramAddBlank);

            connection.Close();

            return ret;
        }
        static public DataTable GetDataCombo(DbConnection paramConnection, 
            DbCommand paramCommand, string paramTableName, string paramValueName, string paramDisplayName, bool paramAddBlank = false)
        {
            DataTable ret = Value.CreateCombo(paramTableName, paramValueName, paramDisplayName, paramAddBlank);

            DbDataReader reader = ExecuteReader(paramConnection, paramCommand);
            while (reader.Read())
            {
                DataRow r = ret.NewRow();
                r[paramValueName] = reader[paramValueName];
                r[paramDisplayName] = reader[paramDisplayName];
                ret.Rows.Add(r);
            }
            reader.Close();

            return ret;
        }

        static public DataTable GetDataTable(string paramConnectionStringName, 
            DbCommand paramCommand, string paramTableName)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return GetDataTable(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramCommand, paramTableName);
        }
        static public DataTable GetDataTable(string paramProviderName, string paramConnectionString, 
            DbCommand paramCommand, string paramTableName)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            DataTable ret = GetDataTable(connection, paramCommand, paramTableName);

            connection.Close();

            return ret;
        }
        static public DataTable GetDataTable(DbConnection paramConnection, 
            DbCommand paramCommand, string paramTableName)
        {
            DataTable ret = new DataTable { TableName = paramTableName };

            ret.Load(ExecuteReader(paramConnection, paramCommand));

            return ret;
        }

        static public DbDataAdapter FillDataSet(string paramConnectionStringName, 
            DataSet paramDataSet, DbDataAdapter paramDataAdapter, string paramTableName,
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return FillDataSet(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramDataSet, paramDataAdapter, paramTableName, 
                paramClear, 
                paramAdapterParameterValues,
                paramEmpty);
        }
        static public DbDataAdapter FillDataSet(string paramProviderName, string paramConnectionString, 
            DataSet paramDataSet, DbDataAdapter paramDataAdapter, string paramTableName,
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            DbDataAdapter adapter = FillDataSet(connection, paramDataSet, paramDataAdapter, paramTableName, 
                paramClear, 
                paramAdapterParameterValues,
                paramEmpty);

            connection.Close();

            return adapter;
        }
        static public DbDataAdapter FillDataSet(DbConnection paramConnection, 
            DataSet paramDataSet, DbDataAdapter paramDataAdapter, string paramTableName,
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            if (paramClear)
                if (paramDataSet.Tables.Contains(paramTableName))
                    paramDataSet.Tables[paramTableName].Clear();

            paramDataAdapter.SelectCommand.Connection = paramConnection;
            if (paramEmpty)
                paramDataAdapter.FillSchema(paramDataSet, SchemaType.Source);
            else 
                paramDataAdapter.Fill(paramDataSet, paramTableName);
            paramDataAdapter = SetAdapterParameterValues(paramDataAdapter, paramAdapterParameterValues);

            return paramDataAdapter;
        }

        static public DbDataAdapter FillDataTable(string paramConnectionStringName, 
            DataTable paramDataTable, DbDataAdapter paramDataAdapter,
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return FillDataTable(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramDataTable, paramDataAdapter,
                paramClear,  
                paramAdapterParameterValues,
                paramEmpty);
        }
        static public DbDataAdapter FillDataTable(string paramProviderName, string paramConnectionString, 
            DataTable paramDataTable, DbDataAdapter paramDataAdapter,
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            DbDataAdapter adapter = FillDataTable(connection, paramDataTable, paramDataAdapter,
                paramClear, 
                paramAdapterParameterValues,
                paramEmpty);

            connection.Close();

            return adapter;
        }
        static public DbDataAdapter FillDataTable(DbConnection paramConnection, 
            DataTable paramDataTable, DbDataAdapter paramDataAdapter, 
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            if (paramClear)
                if (paramDataTable != null)
                    paramDataTable.Clear(); 
            
            paramDataAdapter.SelectCommand.Connection = paramConnection;
            if (paramEmpty)
                paramDataAdapter.FillSchema(paramDataTable, SchemaType.Source);
            else
                paramDataAdapter.Fill(paramDataTable);
            paramDataAdapter = SetAdapterParameterValues(paramDataAdapter, paramAdapterParameterValues);

            return paramDataAdapter;
        }

        static public DataSet UpdateDataSet(string paramConnectionStringName, 
            DataSet paramDataSet, DbDataAdapter paramDataAdapter, string paramTableName, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return UpdateDataSet(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramDataSet, paramDataAdapter, paramTableName, paramAdapterParameterValues);
        }
        static public DataSet UpdateDataSet(string paramProviderName, string paramConnectionString, 
            DataSet paramDataSet, DbDataAdapter paramDataAdapter, string paramTableName, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            DataSet ds = UpdateDataSet(connection, paramDataSet, paramDataAdapter, paramTableName, paramAdapterParameterValues);

            connection.Close();

            return ds;
        }
        static public DataSet UpdateDataSet(DbConnection paramConnection, 
            DataSet paramDataSet, DbDataAdapter paramDataAdapter, string paramTableName, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            paramDataAdapter.InsertCommand.Connection = paramConnection;
            paramDataAdapter.UpdateCommand.Connection = paramConnection;
            paramDataAdapter.DeleteCommand.Connection = paramConnection;

            paramDataAdapter = SetAdapterParameterValues(paramDataAdapter, paramAdapterParameterValues);
            paramDataAdapter.Update(paramDataSet, paramTableName);

            return paramDataSet;
        }

        static public DataTable UpdateDataTable(string paramConnectionStringName, 
            DataTable paramDataTable, DbDataAdapter paramDataAdapter, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return UpdateDataTable(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramDataTable, paramDataAdapter, paramAdapterParameterValues);
        }
        static public DataTable UpdateDataTable(string paramProviderName, string paramConnectionString, 
            DataTable paramDataTable, DbDataAdapter paramDataAdapter, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            DbConnection connection = GetConnection(paramProviderName, paramConnectionString);
            connection.Open();

            DataTable dt = UpdateDataTable(connection, paramDataTable, paramDataAdapter, paramAdapterParameterValues);

            connection.Close();

            return dt;
        }
        static public DataTable UpdateDataTable(DbConnection paramConnection, 
            DataTable paramDataTable, DbDataAdapter paramDataAdapter, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            paramDataAdapter.InsertCommand.Connection = paramConnection;
            paramDataAdapter.UpdateCommand.Connection = paramConnection;
            paramDataAdapter.DeleteCommand.Connection = paramConnection;

            paramDataAdapter = SetAdapterParameterValues(paramDataAdapter, paramAdapterParameterValues);
            paramDataAdapter.Update(paramDataTable);

            return paramDataTable;
        }

        //--------------------------

        static public DataTable GetColumns(string paramConnectionStringName, 
            string paramTableName, string paramColumnName = null)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return GetColumns(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramTableName, paramColumnName);
        }
        static public DataTable GetColumns(string paramProviderName, string paramConnectionString, 
            string paramTableName, string paramColumnName = null)
        {
            if (paramProviderName == "System.Data.SqlClient")
                return SqlServer.GetColumns(paramProviderName, paramConnectionString,
                    paramTableName, paramColumnName);
            return new DataTable("COLUMNS");
        }

        static public DataTable GetTables(string paramConnectionStringName, 
            string paramTableName = null)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return GetTables(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramTableName);
        }
        static public DataTable GetTables(string paramProviderName, string paramConnectionString, 
            string paramTableName = null)
        {
            if (paramProviderName == "System.Data.SqlClient")
                return SqlServer.GetTables(paramProviderName, paramConnectionString, paramTableName);
            return new DataTable("TABLES");
        }

        static public DataTable GetProcedures(string paramConnectionStringName, 
            string paramProcedureName = null)
        {
            ConnectionStringSettings ConnectionString = GetConnectionStringSettings(paramConnectionStringName);
            return GetProcedures(ConnectionString.ProviderName, ConnectionString.ConnectionString,
                paramProcedureName);
        }
        static public DataTable GetProcedures(string paramProviderName, string paramConnectionString, 
            string paramProcedureName = null)
        {
            if (paramProviderName == "System.Data.SqlClient")
                return SqlServer.GetProcedures(paramProviderName, paramConnectionString, paramProcedureName);
            return new DataTable("PROCEDURES");
        }

        //--------------------------------

        static public int CountColumns(string paramConnectionStringName, 
            string paramTableName, string paramColumnName = null)
        {
            return (GetColumns(paramConnectionStringName, paramTableName, paramColumnName).Rows.Count);
        }
        static public int CountTables(string paramConnectionStringName, 
            string paramTableName = null)
        {
            return (GetTables(paramConnectionStringName, paramTableName).Rows.Count);
        }
        static public int CountProcedures(string paramConnectionStringName, 
            string paramProcedureName = null)
        {
            return (GetProcedures(paramConnectionStringName, paramProcedureName).Rows.Count);
        }
    }

    public class ObjectShredder<T>
    {
        private System.Reflection.FieldInfo[] _fi;
        private System.Reflection.PropertyInfo[] _pi;
        private System.Collections.Generic.Dictionary<string, int> _ordinalMap;
        private System.Type _type;

        // ObjectShredder constructor. 
        public ObjectShredder()
        {
            _type = typeof(T);
            _fi = _type.GetFields();
            _pi = _type.GetProperties();
            _ordinalMap = new Dictionary<string, int>();
        }

        /// <summary> 
        /// Loads a DataTable from a sequence of objects. 
        /// </summary> 
        /// <param name="source">The sequence of objects to load into the DataTable.</param>
        /// <param name="table">The input table. The schema of the table must match that 
        /// the type T.  If the table is null, a new table is created with a schema  
        /// created from the public properties and fields of the type T.</param> 
        /// <param name="options">Specifies how values from the source sequence will be applied to 
        /// existing rows in the table.</param> 
        /// <returns>A DataTable created from the source sequence.</returns> 
        public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            // Load the table from the scalar sequence if T is a primitive type. 
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, table, options);
            }

            // Create a new table if the input table is null. 
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            // Initialize the ordinal map and extend the table schema based on type T.
            table = ExtendTable(table, typeof(T));

            // Enumerate the source sequence and load the object values into rows.
            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (options != null)
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), true);
                    }
                }
            }
            table.EndLoadData();

            // Return the table. 
            return table;
        }

        public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            // Create a new table if the input table is null. 
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            // Enumerate the source sequence and load the scalar values into rows.
            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                Object[] values = new object[table.Columns.Count];
                while (e.MoveNext())
                {
                    values[table.Columns["Value"].Ordinal] = e.Current;

                    if (options != null)
                    {
                        table.LoadDataRow(values, (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(values, true);
                    }
                }
            }
            table.EndLoadData();

            // Return the table. 
            return table;
        }

        public object[] ShredObject(DataTable table, T instance)
        {

            FieldInfo[] fi = _fi;
            PropertyInfo[] pi = _pi;

            if (instance.GetType() != typeof(T))
            {
                // If the instance is derived from T, extend the table schema 
                // and get the properties and fields.
                ExtendTable(table, instance.GetType());
                fi = instance.GetType().GetFields();
                pi = instance.GetType().GetProperties();
            }

            // Add the property and field values of the instance to an array.
            Object[] values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                values[_ordinalMap[f.Name]] = f.GetValue(instance);
            }

            foreach (PropertyInfo p in pi)
            {
                values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
            }

            // Return the property and field values of the instance. 
            return values;
        }

        public DataTable ExtendTable(DataTable table, Type type)
        {
            // Extend the table schema if the input table was null or if the value  
            // in the sequence is derived from type T.             
            foreach (FieldInfo f in type.GetFields())
            {
                if (!_ordinalMap.ContainsKey(f.Name))
                {
                    // Add the field as a column in the table if it doesn't exist 
                    // already.
                    DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                        : table.Columns.Add(f.Name, f.FieldType);

                    // Add the field to the ordinal map.
                    _ordinalMap.Add(f.Name, dc.Ordinal);
                }
            }
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (!_ordinalMap.ContainsKey(p.Name))
                {
                    // Add the property as a column in the table if it doesn't exist 
                    // already.
                    DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                        : table.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);

                    // Add the property to the ordinal map.
                    _ordinalMap.Add(p.Name, dc.Ordinal);
                }
            }

            // Return the table. 
            return table;
        }
    }
}
