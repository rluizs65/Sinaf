using System;
using System.Collections.Generic;

namespace Base.Core.Generics
{
    public class GenericClass
    {
        private readonly Dictionary<Type, object> list = new Dictionary<Type, object>();

        public void Add<T>() where T : new()
        {
            T item = new T();
            Type type = typeof(T);

            if (!list.ContainsKey(type)) list[type] = new List<T>();

            var l = (List<T>)list[type];
            l.Add(item);
        }

        public List<object> ListClass 
        {
            get
            {
                List<object> result = new List<object>();

                foreach (var item in (list as IDictionary<Type, object>))
                {
                    result.Add(item.Key);
                }
                return result;
            }
        }
    }
}
