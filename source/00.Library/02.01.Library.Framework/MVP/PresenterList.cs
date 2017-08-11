using System;
using System.Transactions;
using Library.Framework.Interface;
using Library.Framework.Layers;

namespace Library.Framework.MVP
{ 
    [Serializable]
    public class PresenterList
    {
        public LogicEnumerate Logic { get; set; }

        public IViewList ViewList;
        public IResultMessage ResultMessage;

        public PresenterList(LogicEnumerate paramDL,
            IViewList paramViewList, IResultMessage paramResultMessage)
        {
            Logic = paramDL;

            ViewList = paramViewList;

            ResultMessage = paramResultMessage;
        }

        public bool Refresh()
        {
            ViewList.LoadTable();

            return true;
        }
    }
}
