using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common.Data;
using Library.Framework.Data;
using Library.Framework.Aspects;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class AccessEntity : Access
    {
        public AccessEntity(string paramTableName, string paramConnectionStringName,
            string paramParameterNamePrefix = "param")
            : base(paramTableName, paramConnectionStringName, 
            paramParameterNamePrefix)
        {
        }

        public virtual bool KeyIsEmpty(Entity paramDE)
        {
            return true;
        }

        public virtual void Clear(Entity paramDE)
        {
            ClearData(ClearKey(paramDE)).Loaded = false;
        }
        protected virtual Entity ClearKey(Entity paramDE)
        {
            return paramDE;
        }
        protected virtual Entity ClearData(Entity paramDE)
        {
            return paramDE;
        }

        public virtual bool Save(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            if (paramDE.Loaded)
            {
                if (paramDE.MarkDelete)
                    return (Erase(paramDE, paramIsKeyEmpty, paramIsSourceColumn));
                else
                    return (Update(paramDE, paramIsKeyEmpty, paramIsSourceColumn) >= 0);
            }
            else
            {
                return (Insert(paramDE, paramIsKeyEmpty, paramIsSourceColumn) > 0);
            }

            return true;
        }
        //[UndoAspect]
        protected virtual int Insert(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            int ret = 0;

            DbCommand command = (paramIsKeyEmpty) ? GetCommandData(paramDE, "I", paramIsSourceColumn) : GetCommandKey(paramDE, "I", paramIsSourceColumn);
            if (!string.IsNullOrWhiteSpace(command.CommandText)) 
                lock (syncLock)
                    ret = Database.ExecuteNonQuery(ConnectionStringName, command);
    
            if (ret > 0)
            {
                LoadKeyParameters(command.Parameters, paramDE);
                paramDE.Loaded = true;
                paramDE.Saved = true;
            }

            return ret;
        }
        //[UndoAspect]
        protected virtual int Update(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            int ret = 0; 
            
            DbCommand command = (paramIsKeyEmpty) ? GetCommandData(paramDE, "U", paramIsSourceColumn) : GetCommandKey(paramDE, "U", paramIsSourceColumn);
            if (!string.IsNullOrWhiteSpace(command.CommandText))
                lock (syncLock)
                    ret = Database.ExecuteNonQuery(ConnectionStringName, command);

            if (ret > 0)
            {
                paramDE.Saved = true;
            }

            return ret;
        }

        public virtual bool Erase(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            return (Delete(paramDE, paramIsKeyEmpty, paramIsSourceColumn) >= 0);
        }
        //[UndoAspect]
        protected virtual int Delete(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            int ret = 0; 
            
            DbCommand command = (paramIsKeyEmpty) ? GetCommandData(paramDE, "D", paramIsSourceColumn) : GetCommandKey(paramDE, "D", paramIsSourceColumn);
            if (!string.IsNullOrWhiteSpace(command.CommandText))
                lock (syncLock)
                    ret = Database.ExecuteNonQuery(ConnectionStringName, command);
            
            if (ret > 0)
                paramDE.Saved = true;

            return ret;
        }

        public virtual bool Load(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false, TypeLoad paramTypeLoad = TypeLoad.DataReader)
        {
            if (paramTypeLoad == TypeLoad.DataReader)
                return (Read(paramDE, paramIsKeyEmpty, paramIsSourceColumn) > 0);
            else
                return (Row(paramDE, paramIsKeyEmpty, paramIsSourceColumn) > 0);
        }
        protected virtual int Read(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            int ret = 0;

            using (DbConnection connection = Database.GetConnection(ConnectionStringName))
            {
                connection.Open();

                using (DbDataReader reader = Database.ExecuteReader(connection, GetCommandSelect(paramDE, paramIsKeyEmpty, paramIsSourceColumn)))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        LoadEntityReader(reader, paramDE);
                        reader.Close();
                        ret++;
                    }
                }

                connection.Close();
            }

            return ret;
        }
        protected virtual int Row(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            int ret = 0;

            using (DataTable table = Database.GetDataTable(ConnectionStringName, GetCommandSelect(paramDE, paramIsKeyEmpty, paramIsSourceColumn), string.Empty))
            {
                if (table.Rows.Count > 0)
                {
                    LoadEntityRow(table.Rows[0], paramDE);
                    ret++;
                }
            }

            return ret;
        }

        public DbCommand GetCommandData(Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        {
            DbCommand command = GetCommandData(Database.GetCommand(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName), paramDE, paramType, paramIsSourceColumn);

            GetParameters(command.Parameters, GetFieldsKey(paramDE, paramIsSourceColumn, TableName));
            GetParameters(command.Parameters, GetFieldsData(paramDE, paramIsSourceColumn, TableName)); 
            
            return command;
        }
        protected virtual DbCommand GetCommandData(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        {
            List<Field> fieldsall = new List<Field>();
            List<Field> fieldskeyonly = new List<Field>();
            List<Field> fieldsdataonly = new List<Field>();

            List<Field> fieldskey = GetFieldsKey(paramDE, paramIsSourceColumn, TableName);
            foreach (Field f in fieldskey)
            {
                fieldsall.Add(f);
                fieldskeyonly.Add(f);
            }

            List<Field> fieldsdata = GetFieldsData(paramDE, paramIsSourceColumn, TableName);
            foreach (Field f in fieldsdata)
            {
                fieldsall.Add(f);
                fieldsdataonly.Add(f);
            }

            string commandtext = "";

            if (paramType == "F")
                commandtext += Sql.CommandTextSelect(TableName, fieldsall, fieldsall, fieldsall) + System.Environment.NewLine; ;

            if (paramType == "I")
            {
                commandtext += "begin" + System.Environment.NewLine;
                commandtext += Sql.CommandTextAuto(TableName, fieldskeyonly, null) + System.Environment.NewLine;
                commandtext += Sql.CommandTextInsert(TableName, fieldsall, fieldsall) + System.Environment.NewLine;
                commandtext += "end" + System.Environment.NewLine;
            }

            if (paramType == "U")
                commandtext += Sql.CommandTextUpdate(TableName, TableName, fieldsdataonly, fieldsall) + System.Environment.NewLine; ;
            if (paramType == "D")
                commandtext += Sql.CommandTextDelete(TableName, TableName, fieldsall) + System.Environment.NewLine;

            paramCommand.CommandText = commandtext;
            paramCommand.CommandType = CommandType.Text;

            return paramCommand;
        }

        public DbCommand GetCommandKey(Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        {
            DbCommand command = GetCommandKey(Database.GetCommand(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName), paramDE, paramType, paramIsSourceColumn);

            GetParameters(command.Parameters, GetFieldsKey(paramDE, paramIsSourceColumn, TableName));
            if (paramType == "I" || paramType == "U")
                GetParameters(command.Parameters, GetFieldsData(paramDE, paramIsSourceColumn, TableName));

            return command;
        }
        protected virtual DbCommand GetCommandKey(DbCommand paramCommand, Entity paramDE, string paramType, bool paramIsSourceColumn = false)
        {
            List<Field> fieldsall = new List<Field>();
            List<Field> fieldskeyonly = new List<Field>();
            List<Field> fieldsdataonly = new List<Field>();

            List<Field> fieldskey = GetFieldsKey(paramDE, paramIsSourceColumn, TableName);
            foreach (Field f in fieldskey)
            {
                fieldsall.Add(f);
                fieldskeyonly.Add(f);
            }
            List<Field> fieldsdata = GetFieldsData(paramDE, paramIsSourceColumn, TableName);
            foreach (Field f in fieldsdata)
            {
                fieldsall.Add(f);
                fieldsdataonly.Add(f);
            }

            string commandtext = "";
            if (paramType == "S")
                commandtext += Sql.CommandTextSelect(TableName, fieldsall, fieldskeyonly, fieldsall) + System.Environment.NewLine;

            if (paramType == "U")
                if (fieldsdataonly.Count > 0)
                    commandtext += Sql.CommandTextUpdate(TableName, TableName, fieldsdataonly, fieldskeyonly, false) + System.Environment.NewLine;

            if (paramType == "D")
                commandtext += Sql.CommandTextDelete(TableName, TableName, fieldskeyonly, false) + System.Environment.NewLine;

            if (paramType == "A")
                commandtext += Sql.CommandTextAuto(TableName, fieldsall, fieldskeyonly) + System.Environment.NewLine;

            if (paramType == "I")
                commandtext += Sql.CommandTextInsert(TableName, fieldsall, fieldsall) + System.Environment.NewLine;

            paramCommand.CommandText = commandtext;
            paramCommand.CommandType = CommandType.Text;

            return paramCommand;
        }

        public DbCommand GetCommandSelect(Entity paramDE, bool paramIsKeyEmpty, bool paramIsSourceColumn = false)
        {
            return (paramIsKeyEmpty) ? GetCommandData(paramDE, "F", paramIsSourceColumn) : GetCommandKey(paramDE, "S", paramIsSourceColumn);
        }

        public virtual List<Field> GetFieldsKey(Entity paramDE, bool paramIsSourceColumn = false, 
            string paramTableAlias = "")
        {
            return new List<Field>();
        }
        public virtual List<Field> GetFieldsData(Entity paramDE, bool paramIsSourceColumn = false, 
            string paramTableAlias = "")
        {
            return new List<Field>();
        }

        public DbDataAdapter GetDataAdapter(Entity paramDE, bool paramIsSourceColumn = false, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            DbDataAdapter adapter = Database.GetDataAdapter(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName);
            adapter.InsertCommand = GetCommandData(paramDE, "I", paramIsSourceColumn);
            adapter.UpdateCommand = GetCommandKey(paramDE, "U", paramIsSourceColumn);
            adapter.DeleteCommand = GetCommandData(paramDE, "D", paramIsSourceColumn);

            adapter = Database.SetAdapterParameterValues(adapter, paramAdapterParameterValues);

            return adapter;
        }
        public DbDataAdapter GetDataAdapterSelect(Entity paramDE, bool IsKeyEmpty, bool paramIsSourceColumn = false, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            DbDataAdapter adapter = GetDataAdapter(paramDE, paramIsSourceColumn, paramAdapterParameterValues);
            adapter.SelectCommand = GetCommandSelect(paramDE, IsKeyEmpty, paramIsSourceColumn);
            return adapter;
        }

        public virtual Entity LoadEntityReader(DbDataReader paramReader, Entity paramDE)
        {
            ClearData(paramDE);
            Entity ret = LoadDataReader(paramReader, LoadKeyReader(paramReader, paramDE));

            ret.Loaded = true;
            ret.Saved = false;

            return ret;
        }
        protected virtual Entity LoadKeyReader(DbDataReader paramReader, Entity paramDE)
        {
            return paramDE;
        }
        protected virtual Entity LoadDataReader(DbDataReader paramReader, Entity paramDE)
        {
            return paramDE;
        }

        public virtual Entity LoadEntityRow(DataRow paramRow, Entity paramDE)
        {
            ClearData(paramDE); 
            Entity ret = LoadDataRow(paramRow, LoadKeyRow(paramRow, paramDE));

            ret.Loaded = true;
            ret.Saved = false;

            return ret;
        }
        protected virtual Entity LoadKeyRow(DataRow paramRow, Entity paramDE)
        {
            return paramDE;
        }
        protected virtual Entity LoadDataRow(DataRow paramRow, Entity paramDE)
        {
            return paramDE;
        }

        protected virtual Entity LoadKeyParameters(DbParameterCollection paramParameters, Entity paramDE)
        {
            return paramDE;
        }
        protected virtual Entity LoadDataParameters(DbParameterCollection paramParameters, Entity paramDE)
        {
            return paramDE;
        }
    }

    [Serializable]
    public abstract class AccessEntityId : AccessEntity
    {
        public AccessEntityId(string paramTableName, string paramConnectionStringName,
            string paramParameterNamePrefix = "param")
            : base(paramTableName, paramConnectionStringName, paramParameterNamePrefix)
        {
        }

        public override bool KeyIsEmpty(Entity paramDE)
        {
            if (paramDE is EntityId)
                return (((EntityId)paramDE).Id == null);
            else
                return true;
        }
        protected override Entity ClearKey(Entity paramDE)
        {
            if (paramDE is EntityId)
                ((EntityId)paramDE).Id = null;
            return paramDE;
        }

        public override List<Field> GetFieldsKey(Entity paramDE, bool paramIsSourceColumn = false, 
            string paramTableAlias = "")
        {
            List<Field> fields = new List<Field>();

            if (paramDE is EntityId)
                fields.Add(CreateField<Nullable<int>>("id", System.Data.DbType.Int32, ((EntityId)paramDE).Id, paramIsSourceColumn, paramTableAlias, ParameterDirection.InputOutput));

            return fields;
        }

        protected override Entity LoadKeyReader(DbDataReader paramReader, Entity paramDE)
        {
            if (paramDE is EntityId)
                ((EntityId)paramDE).Id = Conversion.To<Nullable<int>>(paramReader[TableColumn("id")]);
            return paramDE;
        }
        protected override Entity LoadKeyRow(DataRow paramRow, Entity paramDE)
        {
            if (paramDE is EntityId)
                ((EntityId)paramDE).Id = Conversion.To<Nullable<int>>(paramRow[TableColumn("id")]);
            return paramDE;
        }
        protected override Entity LoadKeyParameters(DbParameterCollection paramParameters, Entity paramDE)
        {
            if (paramDE is EntityId)
                ((EntityId)paramDE).Id = Conversion.To<Nullable<int>>(paramParameters[TableParameter("id")].Value);
            return paramDE;
        }
    }
}
