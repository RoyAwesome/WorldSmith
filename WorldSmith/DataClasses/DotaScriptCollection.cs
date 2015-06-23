using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class DotaScriptCollection <T> : IList<T> where T : DotaDataObject
    {

        public string ClassName
        {
            get
            {
                return KeyValue.Key;
            }
        }

        public KeyValue KeyValue
        {
            get;
            private set;
        }

        public int Count
        {
            get
            {
                return KeyValue.Children.Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                return CreateWrapper(KeyValue.Children.ElementAt(index));
            }

            set
            {
                KeyValue.ReplaceChildAtIndex(value.KeyValue, index);
            }
        }

        public DotaScriptCollection(KeyValue kv)
        {
            KeyValue = kv;
        }

        public DotaScriptCollection(string Classname)
            : this(new KeyValue(Classname).MakeEmptyParent())
        {

        }

        protected T CreateWrapper(KeyValue value)
        {
            return typeof(T).GetConstructor(new Type[] { typeof(KeyValue) }).Invoke(new object[] { value }) as T;
        }
        

        public virtual IEnumerator<T> GetEnumerator()
        {
            foreach(KeyValue kv in KeyValue.Children)
            {
                T obj = CreateWrapper(kv);
                yield return obj;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (KeyValue kv in KeyValue.Children)
            {
                T obj = CreateWrapper(kv);
                yield return obj;
            }
        }

        public int IndexOf(T item)
        {
            return KeyValue.IndexOfChild(item.KeyValue);
        }

        public void Insert(int index, T item)
        {
            KeyValue.ReplaceChildAtIndex(item.KeyValue, index);
        }

        public void RemoveAt(int index)
        {
            KeyValue.RemoveChildAt(index);
        }

        public void Add(T item)
        {
            KeyValue.AddChild(item.KeyValue);
        }

        public void Clear()
        {
            KeyValue.ClearChildren();
        }

        public bool Contains(T item)
        {
            return KeyValue.ContainsChild(item.KeyValue);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return KeyValue.RemoveChild(item.KeyValue);
        }

        public override string ToString()
        {
            return KeyValue.ToString();
        }
    }
}
