using System;
using System.ComponentModel;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class Entity : INotifyPropertyChanged
	{
        public bool Loaded { get; set; }
        public bool Changed { get; set; }
        public bool MarkDelete { get; set; }
        public bool Saved { get; set; }

        public virtual bool Exists { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            Changed = true;
            Saved = false;
        }
    }

    [Serializable]
    public abstract class EntityId : Entity
    {
        private Nullable<int> _Id;
        public virtual Nullable<int> Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (value != _Id)
                {
                    _Id = value; 
                    OnPropertyChanged("Id");

                    Loaded = false;
                }
            }
        }

        public override bool Exists
        {
            get
            {
                return (Id != null);
            }
        }

        public virtual Nullable<int> InsertId { get; set; }
    }
}
