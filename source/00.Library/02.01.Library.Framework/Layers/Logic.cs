using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common;
using Library.Common.Data;
using Library.Framework.Data;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class Logic
    {
        public string EntityName { get; set; }

        public string TableName { get; set; }
        public string ConnectionStringName { get; set; }

        Access _DA;
        public Access DA
        {
            get
            {
                if (_DA == null)
                    _DA = GetDA();
                return _DA;
            }
        }

        public Logic(string paramEntityName,
            string paramTableName, string paramConnectionStringName)
        {
            EntityName = paramEntityName;

            TableName = paramTableName;
            ConnectionStringName = paramConnectionStringName;
        }

        protected abstract Access GetDA();
        
        public string EntityField(string paramField, string paramAlias = "")
        {
            return (string.IsNullOrEmpty(paramAlias) ? EntityName : paramAlias) + "." + paramField;
        }

        public string TableField(string paramField, string paramTable)
        {
            return DA.TableField(paramField, paramTable);
        }
        public string TableColumn(string paramColumn, string paramPrefixTable = "")
        {
            return DA.TableColumn(paramColumn, paramPrefixTable);
        }
        public string TableColumnX(string paramColumn, string paramPostfixTable = "", string paramPrefixTable = "")
        {
            return DA.TableColumnX(paramColumn, paramPostfixTable, paramPrefixTable);
        }
        public string TableParameter(string paramColumn, string paramPrefixTable = "")
        {
            return DA.TableParameter(paramColumn, paramPrefixTable);
        }

        public Field GetField(string paramColumnName,
            bool paramIsSourceColumn = false,
            string paramTablePrefix = "", string paramTableAlias = "",
            ParameterDirection paramParameterDirection = ParameterDirection.Input)
        {
            return DA.GetField(paramColumnName, paramIsSourceColumn, paramTablePrefix, paramTableAlias, paramParameterDirection);
        }
        public List<Field> AddField<T>(List<Field> paramFields,
            Field paramField,
            T paramValue)
        {
            return DA.AddField<T>(paramFields, paramField, paramValue);
        }

        public bool CompareField(string paramField, string paramCompareTo, string paramAlias = "")
        {
            return EntityField(paramField, paramAlias).ToUpper() == EntityField(paramCompareTo).ToUpper();
        }
        public Dictionary<string, object> ParameterField(Dictionary<string, object> paramAdapterParameterValues, string paramPrefixTable = "")
        {
            Dictionary<string, object> ParameterValues = new Dictionary<string, object>();

            if (paramAdapterParameterValues != null)
                foreach (KeyValuePair<string, object> kvp in paramAdapterParameterValues)
                    ParameterValues.Add(TableParameter(kvp.Key, paramPrefixTable), kvp.Value);

            return ParameterValues;
        }
    }
}
