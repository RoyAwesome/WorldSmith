using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVLib;
using System.ComponentModel;
using System.Reflection;
using WorldSmith.DataClasses.Attributes;

namespace WorldSmith.DataClasses
{
    public class DotaDataObject : ICloneable
    {
        public class DataObjectInfo
        {
            public enum ObjectDataClass
            {
                Default,
                Override,
                Custom,
            }

            public string OriginatingFile;
            public bool FromVPK;
            public ObjectDataClass ObjectClass;

        }


        [Category("Base")]
        [Description("Class name for this object")]
        [NonKVSerialized]
        public string ClassName
        {
            get
            {
                return KeyValue.Key;
            }
        }

        [NonKVSerialized]
        [Browsable(false)]
        public DataObjectInfo ObjectInfo
        {
            get;
            set;
        }

        [Browsable(false)]
        public KeyValue KeyValue
        {
            get;
            private set;
        }

        public DotaDataObject(KeyValue DataSource)
            : this()
        {
            KeyValue = DataSource;
        }
        public DotaDataObject(string ClassName)
            : this()
        {
            KeyValue = new KeyValue(ClassName);
            
        }

  
        private DotaDataObject()
        {
            ObjectInfo = new DataObjectInfo();
        }

        protected KeyValue GetSubkey(string property)
        {            
            return KeyValue[property];
        }

        [Obsolete("Use the Key-Value constructor")]
        public virtual void LoadFromKeyValues(KeyValue kv)
        {
            KeyValue = kv;
        }

        [Obsolete("use the KeyValue property")]
        public virtual KeyValue SaveToKV()
        {
            return KeyValue;
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
