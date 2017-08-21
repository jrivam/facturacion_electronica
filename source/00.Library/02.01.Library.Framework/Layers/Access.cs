using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common.Data;
using Library.Framework.Data;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class Access
    {
        protected static object syncLock = new object(); 
        
        public string TableName { get; set; }
        public string ConnectionStringName { get; set; }

        public string ParameterNamePrefix { get; set; }

        protected abstract Entity GetDE();

        public string DomainName {
            get
            {
                string sServer = Database.GetConnectionStringKey(ConnectionStringName, "Data Source");
                sServer = (sServer.Substring(0, 1) == "."
                    ? sServer.Substring(1, sServer.Length - 1)
                    : sServer);
                string sDatabase = Database.GetConnectionStringKey(ConnectionStringName, "Initial Catalog");

                return String.Format("[{0}]..[{1}]", sDatabase, TableName);
            }
        }

        public string DomainTableName(string paramTableAlias = "")
        {
            return String.Format("{0} {1}", DomainName, (string.IsNullOrWhiteSpace(paramTableAlias) ? TableName : paramTableAlias));
        }

        public string TableField(string paramField, string paramTable)
        {
            return paramTable + "." + paramField;
        }
        public string TableColumn(string paramColumn, string paramTablePrefix = "")
        {
            return (string.IsNullOrWhiteSpace(paramTablePrefix) ? TableName : paramTablePrefix) + "_" + paramColumn;
        }
        public string TableColumnX(string paramColumn, string paramTablePostfix = "", string paramTablePrefix = "")
        {
            return TableColumn((string.IsNullOrWhiteSpace(paramTablePostfix) ? string.Empty : "_" + paramTablePostfix + "_") + paramColumn, paramTablePrefix);
        }
        public string TableParameter(string paramColumn, string paramTablePrefix = "")
        {
            return "@" + (string.IsNullOrWhiteSpace(ParameterNamePrefix) ? string.Empty : ParameterNamePrefix + "_") + TableColumn(paramColumn, paramTablePrefix);
        }

        public Access(string paramTableName, string paramConnectionStringName, 
            string paramParameterNamePrefix = "param")
        {
            TableName = paramTableName;
            ConnectionStringName = paramConnectionStringName;

            ParameterNamePrefix = paramParameterNamePrefix;
        }

        public DbParameterCollection GetParameters(DbParameterCollection paramParameters, List<Field> paramFields)
        {
            if (paramFields != null)
                foreach (Field f in paramFields)
                {
                    if (!string.IsNullOrWhiteSpace(f.ParameterName))
                        paramParameters.Add(Database.GetParameter(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName, f.ParameterName, f.Type, f.Value, f.ColumnNameAlias, f.IsSourceColumn, f.Direction));
                    if (f.ParameterIsNull != null)
                        if (f.ParameterIsNull.Value != null)
                            paramParameters.Add(Database.GetParameter(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName, f.ParameterIsNull.Name, f.Type, f.ParameterIsNull.Value));
                    paramParameters = GetParametersFilter(paramParameters,
                        f.Type, f.ColumnNameAlias, f.IsSourceColumn, f.Direction,
                        f.Parameters.Or);
                }

            return paramParameters;
        }
        public DbParameterCollection GetParametersFilter(DbParameterCollection paramParameters, 
            DbType paramType, string paramColumnName, bool paramIsSourceColumn, ParameterDirection paramDirection,
            List<ParameterComparer> paramFields)
        {
            if (paramFields != null)
                foreach (ParameterComparer p in paramFields)
                {
                    paramParameters.Add(Database.GetParameter(Database.GetConnectionStringSettings(ConnectionStringName).ProviderName, p.NameValue.Name, paramType, p.NameValue.Value, paramColumnName, paramIsSourceColumn, paramDirection));
                    if (p.And != null)
                        paramParameters = GetParametersFilter(paramParameters,
                            paramType, paramColumnName, paramIsSourceColumn, paramDirection,
                            p.And.Or);
                }

            return paramParameters;
        }

        protected ParameterValue CreateParameterValue(string paramParameterName, object paramValue,
            string paramTableName = "")
        {
            return new ParameterValue()
                {
                    Name = TableParameter(paramParameterName, paramTableName),
                    Value = paramValue
                };
        }
        protected ParameterComparer CreateParameterComparer(string paramParameterName, object paramValue, bool paramNot = false,
            Operator paramComparer = Operator.Equal,
            string paramTableName = "")
        {
            return new ParameterComparer()
            {
                NameValue = CreateParameterValue(paramParameterName, paramValue, paramTableName),
                Not = paramNot,
                Comparer = paramComparer
            };
        }

        public virtual Field GetField(string paramColumnName,
            bool paramIsSourceColumn = false,
            string paramTablePrefix = "", string paramTableAlias = "", 
            ParameterDirection paramParameterDirection = ParameterDirection.Input)
        {
            return null;
        }
        public List<Field> AddField<T>(List<Field> paramFields,
            Field paramField,
            T paramValue)
        {
            paramField.ParameterName = TableParameter(paramField.ColumnName, paramField.TableName);
            paramField.Value = paramValue;
            paramFields.Add(paramField);

            return paramFields;
        }

        protected Field CreateField(string paramFieldName, 
            System.Data.DbType paramDbType,
            //ParameterComparer paramParameter = null, 
            bool paramIsSourceColumn = false,
            string paramTableAlias = "", 
            ParameterDirection paramParameterDirection = ParameterDirection.Input)
        {
            Field f = new Field()
            {
                Name = TableField(paramFieldName, paramTableAlias),
                Type = paramDbType,
                Direction = paramParameterDirection,
                TableName = TableName,
                TableNameAlias = paramTableAlias,
                ColumnName = paramFieldName,
                ColumnNameAlias = TableColumn(paramFieldName, paramTableAlias),
                IsSourceColumn = paramIsSourceColumn,
                Equivalences = new Dictionary<object,object>(),
                Parameters = new Parameters() { Or = new List<ParameterComparer>()}
            };

            //if (paramParameter != null)
            //    f.Parameters.Or.Add(paramParameter);

            return f;
        }

        //-------
        protected Field CreateField<T>(string paramFieldName, System.Data.DbType paramDbType,
            T paramValue,
            bool paramIsSourceColumn = false,
            string paramTableAlias = "", 
            ParameterDirection paramParameterDirection = ParameterDirection.Input)
        {
            Field f = CreateField(paramFieldName, paramDbType, //null, 
                paramIsSourceColumn,
                paramTableAlias,
                paramParameterDirection);


            f.ParameterName = TableParameter(paramFieldName, paramTableAlias);
            f.Value = paramValue;

            return f;
        }
        protected List<Field> AddField<T>(List<Field> paramFields,
            string paramFieldName, System.Data.DbType paramDbType,
            T paramValue,
            bool paramIsSourceColumn = false,
            string paramTableAlias = "", 
            ParameterDirection paramParameterDirection = ParameterDirection.Input)
        {
            paramFields.Add(CreateField<T>(paramFieldName, paramDbType, paramValue,
                paramIsSourceColumn,
                paramTableAlias,
                paramParameterDirection));

            return paramFields;
        }
        //-------------------

        protected List<Field> AddField<T>(List<Field> paramFields,
            string paramFieldName, System.Data.DbType paramDbType,
            Filter<T> paramFilter,
            bool paramIsSourceColumn = false,
            string paramTableAlias = "",
            int paramCounter = 0)
        {
            Field f = CreateField(paramFieldName, paramDbType, //null, 
                paramIsSourceColumn,
                paramTableAlias);
            if (paramFilter != null)
            {
                f.Group = paramFilter.Group;
                f.Order = paramFilter.Order;
                f.Repeat = paramFilter.Repeat;

                if (paramFilter.Equivalences != null)
                    foreach (KeyValuePair<T, object> kvp in paramFilter.Equivalences)
                        f.Equivalences.Add(kvp.Key, kvp.Value);

                f.Parameters.Or = AddParameter<T>(f.Parameters.Or,
                    paramFieldName, paramTableAlias,
                    paramFilter, paramCounter);
                f.ParameterIsNull = CreateParameterValue(paramFieldName + "IsNull", paramFilter.ValueIsNull);
            }
            paramFields.Add(f);

            return paramFields;
        }

        protected List<ParameterComparer> AddParameter<T>(List<ParameterComparer> paramParameterComparers,
            string paramFieldName, string paramTableAlias,
            Filter<T> paramParameters, int paramCounter)
        {
            if (paramParameters.Or != null)
                if (paramParameters.Or.Count > 0)
                {
                    foreach (Condition<T> c in paramParameters.Or)
                    {
                        paramCounter++;

                        ParameterComparer p = CreateParameterComparer(paramFieldName + paramCounter.ToString(), c.Value, c.Not, c.Comparer, paramTableAlias);
                        p.Ignorer = c.Ignorer;
                        paramParameterComparers.Add(p);

                        if (c.And != null)
                        {
                            p.And = new Parameters();
                            p.And.Or = AddParameter<T>(new List<ParameterComparer>(),
                                paramFieldName, paramTableAlias,
                                c.And, paramCounter);
                        }
                    }
                }
            return paramParameterComparers;
        }
    }
}
