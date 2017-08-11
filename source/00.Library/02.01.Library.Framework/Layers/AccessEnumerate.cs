using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common;
using Library.Framework.Data;
using Library.Common.Data;
using System.Configuration;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class AccessEnumerate : Access
    {
        protected abstract Access GetDA();

        public AccessEnumerate(string paramTableName, string paramConnectionStringName,
            string paramParameterNamePrefix = "param")
            : base(paramTableName, paramConnectionStringName, paramParameterNamePrefix)
        {
        }

        public virtual Enumerate Convert(Entity paramDE)
        {
            return null;
        }

        public virtual int Update(List<Field> paramFieldsUpdate, Enumerate paramDE2, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            int ret = 0;

            DbCommand command = GetCommandUpdate(paramFieldsUpdate, paramDE2, paramMaxDepth, paramIsSourceColumn);
            lock (syncLock)
            {
                ret = Database.ExecuteNonQuery(ConnectionStringName, command);
            }

            return ret;
        }
        public virtual int Delete(Enumerate paramDE2, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            int ret = 0;

            DbCommand command = GetCommandDelete(paramDE2, paramMaxDepth, paramIsSourceColumn);
            lock (syncLock)
            {
                ret = Database.ExecuteNonQuery(ConnectionStringName, command);
            }

            return ret;
        }
        
        public virtual List<Entity> Load(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            if (paramTypeLoad == TypeLoad.DataReader)
                return Read(paramDE, paramMaxDepth, paramIsSourceColumn,
                    paramTop,
                    paramRowFrom, paramRowTo);
            else
                return Row(paramDE, paramMaxDepth, paramIsSourceColumn,
                    paramTop,
                    paramRowFrom, paramRowTo);
        }
        protected virtual List<Entity> Read(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            List<Entity> ret = new List<Entity>();

            using (DbConnection connection = Database.GetConnection(ConnectionStringName))
            {
                connection.Open();

                using (DbDataReader reader = Database.ExecuteReader(connection, GetCommandJoin(paramDE, paramMaxDepth, paramIsSourceColumn,
                    paramTop,
                    paramRowFrom, paramRowTo)))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            ret.Add(((AccessEntity)GetDA()).LoadEntityReader(reader, GetDE()));
                        reader.Close();
                    }
                }

                connection.Close();
            }
            return ret;
        }
        protected virtual List<Entity> Row(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            List<Entity> ret = new List<Entity>();

            using (DataTable table = Database.GetDataTable(ConnectionStringName, GetCommandJoin(paramDE, paramMaxDepth, paramIsSourceColumn,
                paramTop, 
                paramRowFrom, paramRowTo), string.Empty))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                        ret.Add(((AccessEntity)GetDA()).LoadEntityRow(row, GetDE()));
                }
            }

            return ret;
        }

        public DbCommand GetCommandJoin(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            int depth = 0;
            DbCommand command = GetCommandJoin(Database.GetCommand(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName), paramDE, depth, paramMaxDepth, paramIsSourceColumn,
                paramTop,
                paramRowFrom, paramRowTo);

            GetParameters(command.Parameters, GetFieldsJoin(paramDE, depth, paramMaxDepth, paramIsSourceColumn, TableName));

            return command;
        }
        protected virtual DbCommand GetCommandJoin(DbCommand paramCommand, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            int depth = 0;

            List<Field> fields = new List<Field>();

            depth = paramDepth;
            List<Field> fieldsjoin = GetFieldsJoin(paramDE, depth, paramMaxDepth, paramIsSourceColumn, TableName);
            foreach (Field f in fieldsjoin)
                fields.Add(f);

            depth = paramDepth;
            paramCommand.CommandText = Sql.CommandTextSelect(DomainTableName() + System.Environment.NewLine + GetTablesJoin(paramDE, depth, paramMaxDepth, paramIsSourceColumn, "", TableName), fields, fields, fields, true,
                paramTop,
                paramRowFrom, paramRowTo);
            paramCommand.CommandType = CommandType.Text;

            return paramCommand;
        }

        public DbCommand GetCommandUpdate(List<Field> paramFieldsUpdate, Enumerate paramDE2, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            int depth = 0;
            DbCommand command = GetCommandUpdate(Database.GetCommand(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName), paramFieldsUpdate, paramDE2, depth, paramMaxDepth, paramIsSourceColumn);

            return command;
        }
        protected virtual DbCommand GetCommandUpdate(DbCommand paramCommand, List<Field> paramFieldsUpdate, Enumerate paramDE2, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            int depth = 0;

            List<Field> fields = new List<Field>();

            depth = paramDepth;
            List<Field> fieldsjoin = GetFieldsJoin(paramDE2, depth, paramMaxDepth, paramIsSourceColumn, TableName);
            foreach (Field f in fieldsjoin)
                fields.Add(f);

            depth = paramDepth;
            string commandtext = "";
            commandtext += Sql.CommandTextUpdate(TableName,
            DomainTableName() + System.Environment.NewLine + GetTablesJoin(paramDE2, depth, paramMaxDepth, paramIsSourceColumn, "", TableName), paramFieldsUpdate, fieldsjoin);

            paramCommand.CommandText = commandtext;
            paramCommand.CommandType = CommandType.Text;

            GetParameters(paramCommand.Parameters, paramFieldsUpdate);
            GetParameters(paramCommand.Parameters, GetFieldsJoin(paramDE2, depth, paramMaxDepth, paramIsSourceColumn, TableName));

            return paramCommand;
        }

        public DbCommand GetCommandDelete(Enumerate paramDE2, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            int depth = 0;
            DbCommand command = GetCommandDelete(Database.GetCommand(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName), paramDE2, depth, paramMaxDepth, paramIsSourceColumn);

            return command;
        }
        protected virtual DbCommand GetCommandDelete(DbCommand paramCommand, Enumerate paramDE2, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            List<Field> fieldsall = new List<Field>();
            List<Field> fieldskeyonly = new List<Field>();
            List<Field> fieldsdataonly = new List<Field>();

            int depth = 0;
            List<Field> fields = new List<Field>();

            depth = paramDepth;
            List<Field> fieldsjoin = GetFieldsJoin(paramDE2, depth, paramMaxDepth, paramIsSourceColumn, TableName);
            foreach (Field f in fieldsjoin)
                fields.Add(f);

            depth = paramDepth;

            string commandtext = "";
            commandtext += Sql.CommandTextDelete(TableName,
            DomainTableName() + System.Environment.NewLine + GetTablesJoin(paramDE2, depth, paramMaxDepth, paramIsSourceColumn, "", TableName), fields);

            paramCommand.CommandText = commandtext;
            paramCommand.CommandType = CommandType.Text;

            GetParameters(paramCommand.Parameters, GetFieldsJoin(paramDE2, depth, paramMaxDepth, paramIsSourceColumn, TableName));

            return paramCommand;
        }

        public virtual List<Field> GetFieldsKey(Enumerate paramDE, bool paramIsSourceColumn = false,
            string paramTableAlias = "")
        {
            return new List<Field>();
        }
        public virtual List<Field> GetFieldsData(Enumerate paramDE, bool paramIsSourceColumn = false,
            string paramTableAlias = "")
        {
            return new List<Field>();
        }
        public virtual List<Field> GetFieldsJoin(Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            string paramTableAlias = "")
        {
            List<Field> fields = new List<Field>();
            
            if (!paramDE.Exclude)
            {
                paramDepth++;

                List<Field> fieldskey = GetFieldsKey(paramDE, paramIsSourceColumn, paramTableAlias);
                foreach (Field f in fieldskey)
                    fields.Add(f);

                List<Field> fieldsdata = GetFieldsData(paramDE, paramIsSourceColumn, paramTableAlias);
                foreach (Field f in fieldsdata)
                    fields.Add(f);

                if (paramMaxDepth == 0 || (paramMaxDepth > 0 && paramDepth < paramMaxDepth))
                    fields = GetFieldsJoin(fields, paramDE, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias);
            }

            return fields;
        }

        protected virtual List<Field> GetFieldsJoin(List<Field> paramFields, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
            string paramTableAlias = "")
        {
            return paramFields;
        }

        public string GetTablesJoin(Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            string paramTablePrefix = "", string paramTableAlias = "",
            Dictionary<string, string> paramFieldsJoin = null)
        {
            string columns = "", tables = "";

            if (!paramDE.Exclude)
            {
                paramDepth++;
                if (paramMaxDepth == 0 || (paramMaxDepth > 0 && paramDepth <= paramMaxDepth))
                {
                    if (!string.IsNullOrWhiteSpace(paramTablePrefix))
                        columns = GetColumnsJoin(paramFieldsJoin,
                            paramTablePrefix, paramTableAlias, paramDE.JoinLeft, paramDE.JoinRight);

                    tables += GetTablesJoin(columns, paramDE, paramDepth, paramMaxDepth, paramIsSourceColumn,
                        paramTableAlias, paramFieldsJoin);
                }
            }
            
            return tables;
        }
        protected virtual string GetTablesJoin(string paramTables, Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            string paramTableAlias = "",
            Dictionary<string, string> paramFieldsJoin = null)
        {
            return paramTables;
        }

        public DbDataAdapter GetDataAdapter(Enumerate paramDE, bool paramIsSourceColumn = false, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            return ((AccessEntity)GetDA()).GetDataAdapter(GetDE(), paramIsSourceColumn, paramAdapterParameterValues);
        }
        public DbDataAdapter GetDataAdapterJoin(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false, Dictionary<string, object> paramAdapterParameterValues = null,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            DbDataAdapter adapter = GetDataAdapter(paramDE, paramIsSourceColumn, paramAdapterParameterValues);
            adapter.SelectCommand = GetCommandJoin(paramDE, paramMaxDepth, paramIsSourceColumn,
                paramTop,
                paramRowFrom, paramRowTo);
            return adapter;
        }

        public string GetColumnsJoin(Dictionary<string, string> paramColumns,
            string paramTablePrefix = "", string paramTableAlias = "",
            bool paramJoinLeft = true, bool paramJoinRight = false)
        {
            string joincolumns = string.Empty;

            foreach (KeyValuePair<string, string> vp in paramColumns)
            {
                if (!string.IsNullOrWhiteSpace(joincolumns))
                    joincolumns += "and ";
                joincolumns += String.Format("{0} = {1}{2}", TableField(vp.Key, paramTablePrefix), TableField(vp.Value, paramTableAlias), System.Environment.NewLine);
            }

            string jointype = string.Empty;
            if (paramJoinLeft)
                if (paramJoinRight)
                    jointype = "inner join";
                else
                    jointype = "left join";
            else
                if (paramJoinRight)
                    jointype = "right join";
                else
                    jointype = "outer join";

            return String.Format("{0} {1} on {2}{3}", jointype, DomainTableName(paramTableAlias), System.Environment.NewLine, joincolumns);
        }
    }

    [Serializable]
    public abstract class AccessEnumerateId : AccessEnumerate
    {
        public AccessEnumerateId(string paramTableName, string paramConnectionStringName,
            string paramParameterNamePrefix = "param")
            : base(paramTableName, paramConnectionStringName, paramParameterNamePrefix)
        {
        }

        public override List<Field> GetFieldsKey(Enumerate paramDE, bool paramIsSourceColumn = false,
            string paramTableAlias = "")
        {
            List<Field> fields = new List<Field>();

            if (paramDE is EnumerateId)
                fields = AddField<Nullable<int>>(fields, "id", System.Data.DbType.Int32, ((EnumerateId)paramDE).Id, paramIsSourceColumn, paramTableAlias);

            return fields;
        }
    }
}
