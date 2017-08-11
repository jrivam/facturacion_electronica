using System;
using System.Transactions;
using Library.Framework.Interface;
using Library.Framework.Layers;

namespace Library.Framework.MVP
{ 
    [Serializable]
    public class PresenterQuery
    {
        public LogicEnumerate Logic { get; set; }

        public IViewQuery View;
        public IResultMessage ResultMessage;

        public PresenterQuery(LogicEnumerate paramDL,
            IViewQuery paramView, IResultMessage paramResultMessage)
        {
            Logic = paramDL; 
            
            View = paramView;

            ResultMessage = paramResultMessage;
        }

        public bool Refresh()
        {
            View.LoadTable();

            return true;
        }
        public bool Filter()
        {
            return View.ShowFilter();
        }
        public bool Print()
        {
            View.PrintTable();

            return true;
        }

    }
}
