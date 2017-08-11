using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Library.Common.Data
{
    static public class Conversion
    {
        static public T To<T>(object paramValue)
        {
            if (!Value.IsNull(paramValue))
                if (!string.IsNullOrWhiteSpace(paramValue.ToString()))
                {
                    Type t = typeof(T);
                    Type u = Nullable.GetUnderlyingType(t);

                    if (u != null)
                        return (T)Convert.ChangeType(paramValue, u);
                    else
                        return (T)Convert.ChangeType(paramValue, t);
                }

            return default(T);
        }

        static public object NullCoalescing(object paramValue, object paramValueIfNull)
        {
            return paramValue ?? paramValueIfNull;
        }
        static public T NullCoalescing<T>(object paramValue, object paramValueIfNull)
        {
            return To<T>(NullCoalescing(paramValue, paramValueIfNull));
        }

        static public object NullTernary(bool paramCondition, object paramValue)
        {
            return (paramCondition) ? paramValue : null;
        }
        static public T NullTernary<T>(bool paramCondition, object paramValue)
        {
            return To<T>(NullTernary(paramCondition, paramValue));
        }

        static public string Formatter(string paramText, string paramFormat, bool paramToNumber)
        {
            if (!string.IsNullOrEmpty(paramText))
            {
                paramText = paramText.Replace("..", ".");
                paramText = paramText.Replace("--", "-");

                if (!string.IsNullOrEmpty(paramFormat))
                {
                    if (paramToNumber)
                    {
                        if (paramText == "" || paramText == "." || paramText == "-")
                            return String.Format(paramFormat, 0);
                        else
                        {
                            if (paramText.IndexOf(".") >= 0)
                                return String.Format(paramFormat, Convert.ToDouble(String.Format("{0}.{1}", paramText.Substring(0, paramText.IndexOf(".")), paramText.Substring(paramText.IndexOf(".") + 1, paramText.Length - (paramText.IndexOf(".") + 1)))));
                            else
                                return String.Format(paramFormat, Convert.ToDouble(paramText + ((paramText.Substring(paramText.Length - 1, 1) == ".") ? "." : "")));
                        }
                    }
                    else
                        return String.Format(paramFormat, paramText);
                }
                else
                {
                    if (paramToNumber)
                    {
                        if (paramText == "" || paramText == "." || paramText == "-")
                            return "0";
                        else
                        {
                            if (paramText.IndexOf(".") >= 0)
                            {
                                if (paramText.Substring(0, 1) == "-")
                                    return String.Format("-{0}.{1}", Convert.ToDouble(paramText.Substring(1, paramText.IndexOf(".") - 1)), paramText.Substring(paramText.IndexOf(".") + 1, paramText.Length - (paramText.IndexOf(".") + 1)));
                                else
                                    return String.Format("{0}.{1}", Convert.ToDouble(paramText.Substring(0, paramText.IndexOf("."))), paramText.Substring(paramText.IndexOf(".") + 1, paramText.Length - (paramText.IndexOf(".") + 1)));
                            }
                            else
                                return Convert.ToDouble(paramText + ((paramText.Substring(paramText.Length - 1, 1) == ".") ? "." : "")).ToString();
                        }
                    }
                    else
                        return paramText;
                }
            }

            return paramText;
        }
        static public string Converter(string paramText)
        {
            if (paramText != null)
            {
                paramText = paramText.Replace("..", ".");
                paramText = paramText.Replace("--", "-"); 
                
                if (paramText == "" || paramText == ".")
                    return (0).ToString();
                else
                {
                    if (Convert.ToDouble(paramText).ToString().IndexOf(".") >= 0)
                    {
                        if (paramText.Substring(0, 1) == "-")
                            return String.Format("-{0}.{1}", Convert.ToDouble(paramText.Substring(1, paramText.IndexOf(".") - 1) == "" ? "0" : paramText.Substring(1, paramText.IndexOf(".") - 1)), paramText.Substring(paramText.IndexOf(".") + 1, paramText.Length - (paramText.IndexOf(".") + 1)));
                        else
                            return String.Format("{0}.{1}", Convert.ToDouble(paramText.Substring(0, paramText.IndexOf(".")) == "" ? "0" : paramText.Substring(0, paramText.IndexOf("."))), paramText.Substring(paramText.IndexOf(".") + 1, paramText.Length - (paramText.IndexOf(".") + 1)));
                    }
                    else
                        return Convert.ToDouble(paramText).ToString();
                }
            }

            return paramText;
        }

        static public DataTable ListToDataTable(IList paramList, string paramTableName, bool paramAddBlank = false)
        {
            return ListToDataTable(paramList, paramTableName, "Value", "Display", paramAddBlank);
        }
        static public DataTable ListToDataTable(IList paramList, string paramTableName, string paramValueName, string paramDisplayName, bool paramAddBlank = false)
        {
            return ListToDataTable(paramList, paramValueName, paramDisplayName, Value.CreateCombo(paramTableName, paramValueName, paramDisplayName, paramAddBlank));
        }
        static public DataTable ListToDataTable(IList paramList, string paramValueName, string paramDisplayName, DataTable paramDataTable, bool paramClearTable = false)
        {
            if (paramClearTable)
                paramDataTable.Clear();
            foreach (var s in paramList)
            {
                DataRow r = paramDataTable.NewRow();
                r[paramValueName] = s.ToString();
                r[paramDisplayName] = s.ToString();
                paramDataTable.Rows.Add(r);
            }

            return paramDataTable;
        }

        static public DataTable DictionaryToDataTable<T>(IDictionary<T, object> paramDictionary, string paramTableName, bool paramAddBlank = false)
        {
            return DictionaryToDataTable<T>(paramDictionary, paramTableName, "Value", "Display", paramAddBlank);
        }
        static public DataTable DictionaryToDataTable<T>(IDictionary<T, object> paramDictionary, string paramTableName, string paramValueName, string paramDisplayName, bool paramAddBlank = false)
        {
            return DictionaryToDataTable<T>(paramDictionary, paramValueName, paramDisplayName, Value.CreateCombo(paramTableName, paramValueName, paramDisplayName, paramAddBlank));
        }
        static public DataTable DictionaryToDataTable<T>(IDictionary<T, object> paramDictionary, string paramValueName, string paramDisplayName, DataTable paramDataTable, bool paramClearTable = false)
        {
            if (paramClearTable)
                paramDataTable.Clear();
            foreach (KeyValuePair<T, object> kvp in paramDictionary)
            {
                DataRow r = paramDataTable.NewRow();
                r[paramValueName] = kvp.Key;
                r[paramDisplayName] = kvp.Value;
                paramDataTable.Rows.Add(r);
            }

            return paramDataTable;
        }
    }
}

