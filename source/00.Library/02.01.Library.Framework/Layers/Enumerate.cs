using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Common;
using Library.Framework.Data;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class Enumerate
    {
        public bool _JoinLeft = true;
        public virtual bool JoinLeft { get { return _JoinLeft; } set { _JoinLeft = value; } }
        public bool _JoinRight = false;
        public virtual bool JoinRight { get { return _JoinRight; } set { _JoinRight = value; } }

        public bool Exclude { get; set; }
    }

    [Serializable]
    public abstract class EnumerateId : Enumerate
    {
        public virtual Filter<Nullable<int>> Id { get; set; }
    }
}
