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
    public abstract class LogicEnumerate : Logic
    {
        public LogicEnumerate(string paramEntityName,
            string paramTableName, string paramConnectionStringName)
            : base (paramEntityName,
            paramTableName, paramConnectionStringName)
        {
        }

        public new AccessEnumerate DA
        {
            get
            {
                return (AccessEnumerate)base.DA;
            }
        }

        public virtual List<Entity> Load(Enumerate paramDE, int paramMaxDepth = 0, TypeLoad paramTypeLoad = TypeLoad.DataReader, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            return DA.Load(paramDE, paramMaxDepth, paramTypeLoad, paramIsSourceColumn,
                paramTop,
                paramRowFrom, paramRowTo);
        }

        public virtual byte Update(List<Field> paramFieldsUpdate, Enumerate paramDE2, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            return Convert.ToByte(DA.Update(paramFieldsUpdate, paramDE2, paramMaxDepth, paramIsSourceColumn));
        }
        public virtual byte Delete(Enumerate paramDE2, int paramMaxDepth = 0, bool paramIsSourceColumn = false)
        {
            return Convert.ToByte(DA.Delete(paramDE2, paramMaxDepth, paramIsSourceColumn));
        }
        
        public virtual int Count(Enumerate paramDE, int paramMaxDepth = 0, string paramTableName = null)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.GetDataTable(DA.ConnectionStringName, DA.GetCommandJoin(paramDE, paramMaxDepth), string.Empty).Rows.Count;
        }

        public DataTable GetDataCombo(Enumerate paramDE, string paramValueName, string paramDisplayName, bool paramAddBlank = false, int paramMaxDepth = 0, bool paramIsSourceColumn = false, string paramTableName = null,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.GetDataCombo(DA.ConnectionStringName, GetCommandJoin(paramDE, paramMaxDepth, paramIsSourceColumn, 
                paramTop, 
                paramRowFrom, paramRowTo), paramTableName, paramValueName, paramDisplayName, paramAddBlank);
        }
        public DataTable GetDataTable(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false, string paramTableName = null,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.GetDataTable(DA.ConnectionStringName, GetCommandJoin(paramDE, paramMaxDepth, paramIsSourceColumn, 
                paramTop,
                paramRowFrom, paramRowTo), paramTableName);
        }

        public DbDataAdapter FillDataSet(DataSet paramDataSet, Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
            string paramTableName = null, 
            bool paramClear = true,
            Dictionary<string, object> paramAdapterParameterValues = null,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.FillDataSet(DA.ConnectionStringName, paramDataSet, GetDataAdapterJoin(paramDE, paramMaxDepth, paramIsSourceColumn, null,
                paramTop, 
                paramRowFrom, paramRowTo), 
                DA.TableName, 
                paramClear, ParameterField(paramAdapterParameterValues));
        }
        public DbDataAdapter FillDataTable(DataTable paramDataTable, Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false, 
            bool paramClear = true,
            Dictionary<string, object> paramAdapterParameterValues = null,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            return Database.FillDataTable(DA.ConnectionStringName, paramDataTable, GetDataAdapterJoin(paramDE, paramMaxDepth, paramIsSourceColumn, null,
                paramTop, 
                paramRowFrom, paramRowTo), 
                paramClear, 
                ParameterField(paramAdapterParameterValues));
        }

        public DataSet UpdateDataSet(DataSet paramDataSet, DbDataAdapter paramDataAdapter, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            return Database.UpdateDataSet(DA.ConnectionStringName, paramDataSet, paramDataAdapter, DA.TableName, ParameterField(paramAdapterParameterValues));
        }
        public DataTable UpdateDataTable(DataTable paramDataTable, DbDataAdapter paramDataAdapter, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            return Database.UpdateDataTable(DA.ConnectionStringName, paramDataTable, paramDataAdapter, ParameterField(paramAdapterParameterValues));
        }

        public List<Field> GetFieldsJoin(Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            string paramTableAlias = "")
        {
            return DA.GetFieldsJoin(paramDE, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTableAlias);
        }
        public string GetTablesJoin(Enumerate paramDE, int paramDepth, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            string paramTablePrefix = "", string paramTableAlias = "",
            Dictionary<string, string> paramFieldsJoin = null)
        {
            return DA.GetTablesJoin(paramDE, paramDepth, paramMaxDepth, paramIsSourceColumn, paramTablePrefix, paramTableAlias,
                paramFieldsJoin);
        }
        public string GetColumnsJoin(Dictionary<string, string> paramColumns,
            string paramTablePrefix = "", string paramTableAlias = "",
            bool paramJoinLeft = true, bool paramJoinRight = false)
        {
            return DA.GetColumnsJoin(paramColumns, paramTablePrefix, paramTableAlias, paramJoinLeft, paramJoinRight);
        }

        public DbCommand GetCommandJoin(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            return DA.GetCommandJoin(paramDE, paramMaxDepth, paramIsSourceColumn,
                paramTop, 
                paramRowFrom, paramRowTo);
        }
        public DbDataAdapter GetDataAdapterJoin(Enumerate paramDE, int paramMaxDepth = 0, bool paramIsSourceColumn = false, Dictionary<string, object> paramAdapterParameterValues = null,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            return DA.GetDataAdapterJoin(paramDE, paramMaxDepth, paramIsSourceColumn, ParameterField(paramAdapterParameterValues),
                paramTop, 
                paramRowFrom, paramRowTo);
        }
    }
}
