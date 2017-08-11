using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Common;
using System.Data;
using Library.Common.Data;

namespace Library.Framework.Data
{
    public class ParameterValue
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class ParameterComparer
    {
        public ParameterValue NameValue { get; set; }

        public bool Not { get; set; }
        public Operator Comparer { get; set; }
        public Element Ignorer { get; set; }

        public Parameters And { get; set; }
    }
    public class Parameters
    {
        public List<ParameterComparer> Or { get; set; }
    }
    public class Field
    {
        public string Name { get; set; }
        public bool IsSourceColumn { get; set; }

        public string TableName { get; set; }
        public string TableNameAlias { get; set; }
        public string ColumnName { get; set; }
        public string ColumnNameAlias { get; set; }

        public DbType Type { get; set; }

        public ParameterDirection Direction { get; set; }

        public string ParameterName { get; set; }
        public object Value { get; set; }

        public ParameterValue ParameterIsNull { get; set; }
        public Parameters Parameters { get; set; }

        public Agrupation Group { get; set; }
        public int Order { get; set; }
        public int Repeat { get; set; }
        public Dictionary<object, object> Equivalences;
    }

    static public class Sql
    {
        static public string GetColumns(List<Field> paramFields, bool paramColumnAlias = true)
        {
            string columns = string.Empty;
            string lasttablename = string.Empty;
            foreach (Field f in paramFields)
            {
                for (int i = 0; i <= f.Repeat; i++)
                {
                    columns += !string.IsNullOrWhiteSpace(columns) ? ", " : string.Empty;
                    
                    if (lasttablename != f.TableName)
                    {
                        columns += Environment.NewLine;
                        lasttablename = f.TableName;
                    }
                    f.ColumnNameAlias = f.ColumnNameAlias + (i > 0 ? "_" + i.ToString() : string.Empty);
                    columns += System.Environment.NewLine + f.Name + ((paramColumnAlias) ? String.Format(" as [{0}]", f.ColumnNameAlias) : string.Empty);
                }
                if (f.Equivalences != null)
                {
                    string sWhen = string.Empty;
                    foreach (KeyValuePair<object, object> kvp in f.Equivalences)
                        sWhen += System.Environment.NewLine + string.Format("when {0} then {1}", Value.SqlComparer(f.Name, kvp.Key), Value.SqlValue(kvp.Value));
                    if (sWhen != string.Empty)
                    {
                        sWhen += System.Environment.NewLine;

                        columns += !string.IsNullOrWhiteSpace(columns) ? ", " : string.Empty;

                        f.ColumnNameAlias = f.ColumnNameAlias + "_Eq";
                        columns += System.Environment.NewLine + string.Format("case{0}end", sWhen) + ((paramColumnAlias) ? String.Format(" as [{0}]", f.ColumnNameAlias) : string.Empty);
                    }
                }
            }
            columns += Environment.NewLine;

            return columns;
        }
        static public string GetAuto(List<Field> paramFields)
        {
            string columns = string.Empty;
            foreach (Field f in paramFields)
            {
                columns += !string.IsNullOrWhiteSpace(columns) ? ", " : string.Empty;
                columns += System.Environment.NewLine + String.Format("{0} = isnull(max({1}), 0) + 1", f.ParameterName, f.Name);
            }
            return columns;
        }
        static public string GetSet(List<Field> paramFields)
        {
            string columns = string.Empty;
            foreach (Field f in paramFields)
            {
                columns += !string.IsNullOrWhiteSpace(columns) ? ", " : string.Empty;
                columns += System.Environment.NewLine + String.Format("{0} = {1}", f.Name, f.ParameterName);
            }
            return columns;
        }
        static public string GetCondition(List<Field> paramFields, bool paramIsNull = true)
        {
            string condition = string.Empty;
            foreach (Field f in paramFields)
            {
                if (!string.IsNullOrWhiteSpace(f.ParameterName))
                {
                    condition += !string.IsNullOrWhiteSpace(condition) ? "and " : string.Empty;
                    condition += string.Format("({0} = {1}{2})", f.Name, f.ParameterName, (paramIsNull) ? string.Format(" or {0} is null", f.ParameterName) : string.Empty) + System.Environment.NewLine;
                }
                else
                    condition = GetConditionFilter(condition, f.Name, f.ParameterIsNull, f.Parameters, System.Environment.NewLine + "and ");
            }
            return condition;
        }
        static public string GetConditionFilter(string paramCondition, string paramColumnName, ParameterValue paramParameterIsNull, Parameters paramParameters, string paramConnector)
        {
            string condition = string.Empty;
            if (paramParameters != null)
            {
                if (paramParameters.Or != null)
                {
                    if (paramParameters.Or.Count > 0)
                    {
                        paramCondition += !string.IsNullOrWhiteSpace(paramCondition) ? paramConnector : string.Empty;
                        paramCondition += "(";
                        foreach (ParameterComparer p in paramParameters.Or)
                        {
                            condition += !string.IsNullOrWhiteSpace(condition) ? "or " : string.Empty;
                            if (p.NameValue != null)
                            {
                                if (p.NameValue.Value != null)
                                {
                                    condition += string.Format("({0}{1}", ((p.Not) ? "not " : ""), (paramParameterIsNull.Value != null) ? string.Format("isnull({0}, {1})", paramColumnName, paramParameterIsNull.Name) : paramColumnName);

                                    string comparision = string.Empty;
                                    switch (p.Comparer)
                                    {
                                        case Operator.EqualOrGreater:
                                            comparision += ">=";
                                            break;
                                        case Operator.EqualOrLess:
                                            comparision += "<=";
                                            break;
                                        case Operator.Greater:
                                            comparision += ">";
                                            break;
                                        case Operator.Less:
                                            comparision += "<";
                                            break;
                                        case Operator.Like:
                                        case Operator.LikeBegin:
                                        case Operator.LikeEnd:
                                            comparision += "like";
                                            break;
                                        default:
                                            comparision += "=";
                                            break;
                                    }
                                    condition += string.Format(" {0} ", comparision);

                                    if (p.Comparer == Operator.Like)
                                        condition += string.Format("'%' + {0} + '%'", p.NameValue.Name);
                                    else if (p.Comparer == Operator.LikeBegin)
                                        condition += string.Format("'%' + {0}", p.NameValue.Name);
                                    else if (p.Comparer == Operator.LikeEnd)
                                        condition += string.Format("{0} + '%'", p.NameValue.Name);
                                    else
                                        condition += string.Format("{0}", p.NameValue.Name);

                                    if (p.Ignorer == Element.Parameter)
                                        condition += string.Format(" or {0} is null)", p.NameValue.Name);
                                    if (p.Ignorer == Element.Field)
                                        condition += string.Format(" or {0} is null)", paramColumnName);
                                }
                                else
                                {
                                    condition += string.Format("({0}isnull({1}, {2}) is null)", ((p.Not) ? "not " : ""), paramColumnName, p.NameValue.Name);
                                }
                            }
                            condition = GetConditionFilter(condition, paramColumnName, paramParameterIsNull, p.And, System.Environment.NewLine + "and ");
                        }
                        paramCondition += string.Format("{0})", condition) + System.Environment.NewLine;
                    }
                }
            }
            return paramCondition;
        }
        static public string GetValues(List<Field> paramFields)
        {
            string values = string.Empty;
            foreach (Field f in paramFields)
            {
                values += !string.IsNullOrWhiteSpace(values) ? ", " : string.Empty;
                values += System.Environment.NewLine + f.ParameterName;
            }
            return values;
        }
        static public string GetOrder(List<Field> paramFields)
        {
            string order = string.Empty;
            foreach (Field f in paramFields.Where(x => x.Order != 0).OrderBy(x => Math.Abs(x.Order)).ToList())
            {
                order += !string.IsNullOrWhiteSpace(order) ? ", " : string.Empty;
                order += System.Environment.NewLine + f.Name;
                if (f.Order < 0)
                    order += " desc";
            }
            return order;
        }

        static public string CommandTextAuto(string paramTable,
            List<Field> paramFieldsColumns,
            List<Field> paramFieldsCondition)
        {
            string auto = string.Empty;
            string condition = string.Empty;

            if (paramFieldsColumns == null)
                paramFieldsColumns = new List<Field>();
            if (paramFieldsColumns.Count > 0)
                auto = GetAuto(paramFieldsColumns);

            if (paramFieldsCondition == null)
                paramFieldsCondition = new List<Field>();
            if (paramFieldsCondition.Count > 0)
                condition = GetCondition(paramFieldsCondition);

            return String.Format("{0}{1}{2}",
                    String.Format("select {0}", (!string.IsNullOrWhiteSpace(auto) ? auto : "max(id) + 1")),
                    System.Environment.NewLine + String.Format("from {0}", paramTable),
                    System.Environment.NewLine + (!string.IsNullOrWhiteSpace(condition) ? "where " : string.Empty) + condition);
        }
        static public string CommandTextSelect(string paramTables,
            List<Field> paramFieldsColumns,
            List<Field> paramFieldsCondition,
            List<Field> paramFieldsOrder,
            bool paramColumnAlias = true,
            int paramTop = 0,
            int paramRowFrom = 0, int paramRowTo = 0)
        {
            string columns = string.Empty;
            string condition = string.Empty;
            string order = string.Empty;

            if (paramFieldsColumns == null)
                paramFieldsColumns = new List<Field>();
            if (paramFieldsColumns.Count > 0)
                columns = GetColumns(paramFieldsColumns, paramColumnAlias);

            if (paramFieldsCondition == null)
                paramFieldsCondition = new List<Field>();
            if (paramFieldsCondition.Count > 0)
                condition = GetCondition(paramFieldsCondition);

            if (paramFieldsOrder == null)
                paramFieldsOrder = new List<Field>();
            if (paramFieldsOrder.Count > 0)
                order = GetOrder(paramFieldsOrder);

            if (paramRowFrom == 0 && paramRowTo == 0)
            {
                string sSelectCommand = string.Empty;
                
                sSelectCommand = String.Format("{0}{1}{2}",
                    String.Format("select {0}{1}", (paramTop > 0 ? "Top " + paramTop : string.Empty), (!string.IsNullOrWhiteSpace(columns) ? columns : "*")),
                    System.Environment.NewLine + string.Format("from {0}", paramTables),
                    System.Environment.NewLine + (!string.IsNullOrWhiteSpace(condition) ? "where " : string.Empty) + condition);

                string sGroupColumns = string.Empty;
                string sGroupCalculations = string.Empty;
                string sGroupOrders = string.Empty;

                foreach (Field f in paramFieldsColumns)
                {
                    if (f.Group != Agrupation.None)
                    {
                        if (f.Group != Agrupation.Grouped)
                        {
                            sGroupCalculations += !string.IsNullOrWhiteSpace(sGroupCalculations) ? ", " + System.Environment.NewLine : string.Empty;
                            if (f.Group == Agrupation.Count)
                                sGroupCalculations += string.Format("Count({0}) as {0}", f.ColumnNameAlias);
                            if (f.Group == Agrupation.Sum)
                                sGroupCalculations += string.Format("Sum({0}) as {0}", f.ColumnNameAlias);
                            if (f.Group == Agrupation.Avg)
                                sGroupCalculations += string.Format("Avg({0}) as {0}", f.ColumnNameAlias);
                            if (f.Group == Agrupation.Min)
                                sGroupCalculations += string.Format("Min({0}) as {0}", f.ColumnNameAlias);
                            if (f.Group == Agrupation.Max)
                                sGroupCalculations += string.Format("Max({0}) as {0}", f.ColumnNameAlias);
                        }
                        else
                        {
                            sGroupColumns += !string.IsNullOrWhiteSpace(sGroupColumns) ? ", " + System.Environment.NewLine : string.Empty;
                            sGroupColumns += f.ColumnNameAlias;
                            if (f.Order != 0)
                            {
                                sGroupOrders += !string.IsNullOrWhiteSpace(sGroupOrders) ? ", " + System.Environment.NewLine : string.Empty;
                                sGroupOrders += f.ColumnNameAlias;
                            }
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(sGroupColumns))
                {
                    sSelectCommand = string.Format(@"select {0},{3}{1}{3}from({3}{2}{3}) g{3}group by {0}",
                        sGroupColumns, sGroupCalculations, sSelectCommand,
                        System.Environment.NewLine);
                    sSelectCommand = string.Format("{0}{1}", sSelectCommand, System.Environment.NewLine + (!string.IsNullOrWhiteSpace(sGroupOrders) ? "order by " : string.Empty) + sGroupOrders);
                }
                else
                    sSelectCommand = string.Format("{0}{1}", sSelectCommand, System.Environment.NewLine + (!string.IsNullOrWhiteSpace(order) ? "order by " : string.Empty) + order);
                
                return sSelectCommand;
            }
            else
            {
                string condition_rownumber = string.Empty;

                if (paramRowFrom > 0)
                    condition_rownumber += (!string.IsNullOrWhiteSpace(condition_rownumber) ? " and " : string.Empty) + string.Format("x.ROW_NUMBER >= {0} + 1" + paramRowFrom.ToString());
                if (paramRowTo > 0)
                    condition_rownumber += (!string.IsNullOrWhiteSpace(condition_rownumber) ? " and " : string.Empty) + string.Format("x.ROW_NUMBER <= {0} + {1}" + paramRowFrom.ToString(), paramRowTo.ToString());

                return String.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER ({0}) AS [ROW_NUMBER], {1}{2}{3}) as x {4} ORDER BY x.[ROW_NUMBER]",
                    System.Environment.NewLine + (!string.IsNullOrWhiteSpace(order) ? "order by " : string.Empty) + order,
                    (!string.IsNullOrWhiteSpace(columns) ? columns : "*"),
                    System.Environment.NewLine + string.Format("from {0}", paramTables),
                    System.Environment.NewLine + (!string.IsNullOrWhiteSpace(condition) ? "where " : string.Empty) + condition,
                    System.Environment.NewLine + (!string.IsNullOrWhiteSpace(condition_rownumber) ? "where " : string.Empty) + condition_rownumber);
            }
        }
        static public string CommandTextInsert(string paramTable,
            List<Field> paramFieldsColumns,
            List<Field> paramFieldsValues)
        {
            string columns = string.Empty;
            string values = string.Empty;

            if (paramFieldsColumns == null)
                paramFieldsColumns = new List<Field>();
            if (paramFieldsValues == null)
                paramFieldsValues = new List<Field>();
            if (paramFieldsColumns.Count == paramFieldsValues.Count && paramFieldsColumns.Count > 0)
            {
                columns = GetColumns(paramFieldsColumns, false);
                values = GetValues(paramFieldsValues);
            }

            return String.Format("{0}{1}{2}",
                String.Format("insert into {0}", paramTable),
                System.Environment.NewLine + String.Format("({0})", columns),
                System.Environment.NewLine + String.Format("values({0})", values));
        }
        static public string CommandTextUpdate(string paramTable, string paramFrom,
            List<Field> paramFieldsSet,
            List<Field> paramFieldsCondition,
            bool paramIsNull = true)
        {
            string set = string.Empty;
            string condition = string.Empty;

            if (paramFieldsSet == null)
                paramFieldsSet = new List<Field>();
            if (paramFieldsSet.Count > 0)
                set = GetSet(paramFieldsSet);

            if (paramFieldsCondition == null)
                paramFieldsCondition = new List<Field>();
            if (paramFieldsCondition.Count > 0)
                condition = GetCondition(paramFieldsCondition, paramIsNull);

            return String.Format("{0}{1}{2}{3}",
                String.Format("update {0}", paramTable),
                System.Environment.NewLine + String.Format("set {0}", set),
                System.Environment.NewLine + String.Format("from {0}", paramFrom),
                System.Environment.NewLine + (!string.IsNullOrWhiteSpace(condition) ? "where " : string.Empty) + condition);

        }
        static public string CommandTextDelete(string paramTable, string paramFrom,
            List<Field> paramFieldsCondition,
            bool paramIsNull = true)
        {
            string condition = string.Empty; 
            
            if (paramFieldsCondition == null)
                paramFieldsCondition = new List<Field>();
            if (paramFieldsCondition.Count > 0)
                condition = GetCondition(paramFieldsCondition, paramIsNull);

            return String.Format("{0}{1}{2}",
                String.Format("delete {0}", paramTable),
                System.Environment.NewLine + String.Format("from {0}", paramFrom),
                System.Environment.NewLine + (!string.IsNullOrWhiteSpace(condition) ? "where " : string.Empty) + condition);
        }
    }
}
