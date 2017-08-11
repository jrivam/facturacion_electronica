using System;
using System.Collections.Generic;
using System.Data;

namespace Library.Common.Data
{
    static public class Value
    {
        static public bool IsNull(object paramValue)
        {
            return (paramValue == null || paramValue == DBNull.Value);
        }
        
        static public DataTable CreateCombo(string paramTableName, string paramValueName, string paramDisplayName, bool paramAddBlank = false)
        {
            DataTable t = new DataTable(paramTableName);

            t.Columns.Add(paramValueName);
            t.Columns.Add(paramDisplayName);

            if (paramAddBlank)
                t = AddBlank(t, paramValueName, paramDisplayName);

            return t;
        }
        static public DataTable AddBlank(DataTable paramDataTable, string paramValueName, string paramDisplayName)
        {
            DataRow r = paramDataTable.NewRow();
            r[paramValueName] = DBNull.Value;
            r[paramDisplayName] = " ";//ComboBoxColumn error. tiene que ser espacio la descripcion, si es vacio o null se cae.
            paramDataTable.Rows.InsertAt(r, 0);

            return paramDataTable;
        }

        static public Dictionary<int, string> GetYears(int paramFrom = 0, int paramTo = 0, int paramInterval = 1)
        {
            Dictionary<int, string> ht = new Dictionary<int, string>();

            if (paramFrom == 0)
                paramFrom = DateTime.Now.Year;
            if (paramTo == 0)
                paramTo = DateTime.Now.Year;

            for (int i = paramTo; i >= paramFrom; i -= paramInterval)
                if (i >= paramFrom && i <= paramTo) 
                    ht.Add(i, i.ToString());

            return ht;
        }
        static public string GetMonth(int paramMonth)
        {
            if (paramMonth == 1)
                return "Enero";
            if (paramMonth == 2)
                return "Febrero";
            if (paramMonth == 3)
                return "Marzo";
            if (paramMonth == 4)
                return "Abril";
            if (paramMonth == 5)
                return "Mayo";
            if (paramMonth == 6)
                return "Junio";
            if (paramMonth == 7)
                return "Julio";
            if (paramMonth == 8)
                return "Agosto";
            if (paramMonth == 9)
                return "Setiembre";
            if (paramMonth == 10)
                return "Octubre";
            if (paramMonth == 11)
                return "Noviembre";
            if (paramMonth == 12)
                return "Diciembre";

            return "";
        }
        static public Dictionary<int, string> GetMonths(int paramFrom = 0, int paramTo = 0, int paramInterval = 1)
        {
            Dictionary<int, string> ht = new Dictionary<int, string>();

            if (paramFrom == 0)
                paramFrom = 1;
            if (paramTo == 0)
                paramTo = 12;

            for (int i = paramFrom; i <= paramTo; i += paramInterval)
                if (i >= paramFrom && i <= paramTo)
                    ht.Add(i, GetMonth(i));

            return ht;
        }
        static public Dictionary<int, string> GetDays(int paramYear = 0, int paramMonth = 0, int paramFrom = 0, int paramTo = 0, int paramInterval = 1)
        {
            Dictionary<int, string> ht = new Dictionary<int, string>();

            if (paramFrom == 0)
                paramFrom = 1;
            if (paramTo == 0)
                paramTo = 31; 
            
            if (paramYear == 0)
                paramYear = DateTime.Now.Year;
            if (paramMonth == 0)
                paramMonth = DateTime.Now.Month;

            int days = 0;
            if (paramMonth == 2)
                days = (paramYear % 4 == 0) ? 29 : 28;
            else if (paramMonth == 4 || paramMonth == 6 || paramMonth == 9 || paramMonth == 11)
                days = 30;
            else
                days = 31;

            for (int i = 1; i <= days; i += paramInterval)
                if (i >= paramFrom && i <= paramTo) 
                    ht.Add(i, i.ToString());

            return ht;
        }
        
        static public Dictionary<string, string> GetPeriod()
        {
            Dictionary<string, string> ht = new Dictionary<string, string>();

            ht.Add("H", "Horas");
            ht.Add("D", "Dias");
            ht.Add("S", "Semanas");
            ht.Add("M", "Meses");

            return ht;
        }

        static public string SqlValue(object paramValue)
        {
            string sValue = string.Empty;
            if (paramValue.GetType() == typeof(string))
                sValue = string.Format("'{0}'", paramValue);
            else if (paramValue.GetType() == typeof(DateTime) ||
                paramValue.GetType() == typeof(DateTime?))
                sValue = string.Format("'{0}'", string.Format("yyyy-MM-dd hh:mm:ss", paramValue));
            else
                sValue = string.Format("{0}", paramValue);

            return sValue;
        }
        static public string SqlComparer(string paramField, object paramValue)
        {
            if (paramValue == null)
                return string.Format("{0} is null", paramField);
            else
                return string.Format("{0} = {1}", paramField, SqlValue(paramValue));
        }
    }
}
