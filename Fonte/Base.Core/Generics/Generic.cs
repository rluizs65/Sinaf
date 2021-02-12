using System;

namespace Base.Core.Generics
{
    public class Generic
    {
        public Generic()
        {
        }
    }

    [Serializable]
    public class Generic<TClass> : Generic
    {
        private TClass _value;

        public TClass Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Type Type
        {
            get { return typeof(TClass); }
        }
    }
}
