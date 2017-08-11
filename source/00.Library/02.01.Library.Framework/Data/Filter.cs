using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;


//Enumerate feEnumerate = new Enumerate()
//{
//    FieldInt = new Filter<int?>() { Order = 1},
//    FieldInt = new Filter<int?>(1),
//    FieldString = new Filter<string>(new List<string> { "a", "b", "c" }, Operator.Like) { Order = -2 },
//    FieldBool = new Filter<bool?>(new List<bool?> { true, false }),
//    FieldIntNot = new Filter<int?>(1, Operator.Equal, true),
//    FieldIntAnd = new Filter<int?>(0, Operator.EqualOrGreater, false, new Filter<int?>(10, Operator.EqualOrLess))
//    FilterAndOr = new Filter<string>("a", Operator.Equal, false, new Filter<string>(new List<string> { "b","c","d"}));
//    FilterBoolNotNull = new Filter<bool?>(new Condition<bool?>(true, true)) { ValueIsNull = false };
//};
//feEnumerate.Table.FieldString = new Filter<string>("a");

namespace Library.Framework.Data
{
    public enum Operator
    {
        Equal,
        EqualOrGreater,
        EqualOrLess,
        Greater,
        Less,
        Like,
        LikeBegin,
        LikeEnd
    }
    public enum Element
    {
        Parameter,
        Field,
        None
    }
    public enum Agrupation
    {
        None,
        Grouped,
        Count,
        Sum,
        Avg,
        Min,
        Max
    }

    public class Condition<T>
    {
        public bool Not { get; set; }
        public Operator Comparer { get; set; }
        public T Value { get; set; }

        public Element Ignorer { get; set; }

        public Filter<T> And { get; set; }

        public Condition()
        {
        }
        public Condition(T paramValue, bool paramNot = false,
            Operator paramComparer = Operator.Equal, 
            Filter<T> paramAnd = null)
        {
            Value = paramValue;

            Not = paramNot;
            Comparer = paramComparer;

            And = paramAnd;
        }
    }
    public class Filter<T>
    {
        public List<Condition<T>> Or { get; set; }

        public T ValueIsNull { get; set; }

        public Agrupation Group { get; set; }
        
        public int Order { get; set; }
        public int Repeat { get; set; }

        public IDictionary<T, object> Equivalences;

        public Filter()
        {
        }
        public Filter(List<Condition<T>> paramOr)
            : this()
        {
            Or = paramOr;
        }
        public Filter(Condition<T> paramOr)
            : this(new List<Condition<T>>() { paramOr })
        {
        }
        public Filter(List<T> paramOr)
            : this(new List<Condition<T>>())
        {
            foreach (T t in paramOr)
                Or.Add(new Condition<T>(t));
        }
        public Filter(T paramOr, bool paramNotOr = false, Operator paramComparerOr = Operator.Equal, 
            Filter<T> paramAnd = null)
            : this(new List<Condition<T>>() { new Condition<T>(paramOr, paramNotOr, paramComparerOr, paramAnd) })
        {
        }
        public Filter(List<T> paramOr, bool paramNotOr = false, Operator paramComparerOr = Operator.Equal)
            : this(new List<Condition<T>>())
        {
            foreach (T t in paramOr)
                Or.Add(new Condition<T>(t, paramNotOr, paramComparerOr));
        }
    }

    static public class HelperFilter
    {
        static public void GetFilterValue<T>(Filter<T> paramFilter,
            ref T paramValue)
        {
            paramValue = default(T);
            if (paramFilter != null && paramFilter.Or != null)
                paramValue = paramFilter.Or[0].Value;
        }
        static public void GetFilterValue<T>(Filter<T> paramFilter,
            T paramValue,
            Action<T> setterValue)
        {
            GetFilterValue<T>(paramFilter,
            ref paramValue);
            setterValue(paramValue);
        }

        static public bool HasValue<T>(Filter<T> paramFilter)
        {
            if (paramFilter != null)
                if (paramFilter.Or != null)
                    return true;
            return false;
        }

        static public void GetFilterValue<T>(Filter<T> paramFilter,
            ref T paramValueIni, ref T paramValueFin,
            Operator paramOperatorIni = Operator.EqualOrGreater,
            Operator paramOperatorFin = Operator.EqualOrLess)
        {
            paramValueIni = default(T);
            paramValueFin = default(T);

            if (paramFilter != null && paramFilter.Or != null)
            {
                if (paramFilter.Or[0].Comparer == paramOperatorIni)
                {
                    paramValueIni = paramFilter.Or[0].Value;
                    if (paramFilter.Or[0].And != null && paramFilter.Or[0].And.Or != null)
                        paramValueFin = paramFilter.Or[0].And.Or[0].Value;
                }
                if (paramFilter.Or[0].Comparer == paramOperatorFin)
                    paramValueFin = paramFilter.Or[0].Value;
            }
        }
        static public void GetFilterValue<T>(Filter<T> paramFilter,
            T paramValueIni, T paramValueFin, 
            Action<T> setterValueIni, Action<T> setterValueFin,
            Operator paramOperatorIni = Operator.EqualOrGreater,
            Operator paramOperatorFin = Operator.EqualOrLess)
        {
            GetFilterValue<T>(paramFilter,
            ref paramValueIni, ref paramValueFin,
            paramOperatorIni, paramOperatorFin);
            setterValueIni(paramValueIni);
            setterValueFin(paramValueFin);
        }

        static public void SetFilterValue<T>(ref Filter<T> paramFilter,
            T paramValue,
            bool paramNot = false,
            Operator paramOperator = Operator.Like)
        {
            if (paramFilter == null)
                paramFilter = new Filter<T>();
            else
                paramFilter.Or = null;

            if (paramValue != null)
            {
                Condition<T> cndIni = new Condition<T>(paramValue, paramNot, paramOperator);
                paramFilter.Or = new List<Condition<T>>();
                paramFilter.Or.Add(cndIni);
            }
        }
        static public void SetFilterValue<T>(Filter<T> paramFilter,
            Action<Filter<T>> setterFilter,
            T paramValue,
            bool paramNot = false,
            Operator paramOperator = Operator.Like)
        {
            SetFilterValue<T>(ref paramFilter,
            paramValue,
            paramNot, 
            paramOperator);
            setterFilter(paramFilter);
        }

        static public void SetFilterValue<T>(ref Filter<T> paramFilter,
            T paramValueIni, T paramValueFin,
            bool paramNot = false,
            Operator paramOperatorIni = Operator.EqualOrGreater,
            Operator paramOperatorFin = Operator.EqualOrLess)
        {
            if (paramFilter == null)
                paramFilter = new Filter<T>();
            else
                paramFilter.Or = null;

            if (paramValueIni != null)
            {
                Condition<T> cndIni = new Condition<T>(paramValueIni, paramNot, paramOperatorIni);
                paramFilter.Or = new List<Condition<T>>();
                paramFilter.Or.Add(cndIni);
            }
            if (paramValueFin != null)
            {
                Condition<T> cndFin = new Condition<T>(paramValueFin, paramNot, paramOperatorFin);
                if (paramValueIni != null)
                {
                    paramFilter.Or[0].And = new Filter<T>();
                    paramFilter.Or[0].And.Or = new List<Condition<T>>();
                    paramFilter.Or[0].And.Or.Add(cndFin);
                }
                else
                {
                    paramFilter.Or = new List<Condition<T>>();
                    paramFilter.Or.Add(cndFin);
                }
            }
        }
        static public void SetFilterValue<T>(Filter<T> paramFilter,
            Action<Filter<T>> setterFilter,
            T paramValueIni, T paramValueFin,
            bool paramNot = false,
            Operator paramOperatorIni = Operator.EqualOrGreater,
            Operator paramOperatorFin = Operator.EqualOrLess)
        {
            SetFilterValue<T>(ref paramFilter,
            paramValueIni, paramValueFin,
            paramNot,
            paramOperatorIni, paramOperatorFin);
            setterFilter(paramFilter);
        }
    }
}