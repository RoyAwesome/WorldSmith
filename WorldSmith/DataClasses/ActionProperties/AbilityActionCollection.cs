using KVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.Dialogs;

namespace WorldSmith.DataClasses
{
    public class AbilityActionCollectionConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return typeof(string) == sourceType;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return typeof(string) == destinationType;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return new AbilityActionCollection();
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value == null) return "";
            return value.ToString();
        }
    }


    [Editor(typeof(AbilityActionEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AbilityActionCollection
    {
        public Dictionary<string, ActionCollection> Actions = new Dictionary<string, ActionCollection>()
        {
            { "OnSpellStart",               new ActionCollection() },
            { "OnChannelSucceeded",         new ActionCollection() },
            { "OnChannelInterrupted",       new ActionCollection() },
            { "OnChannelFinish",            new ActionCollection() },
            { "OnToggleOn",                 new ActionCollection() },
            { "OnToggleOff",                new ActionCollection() },
            { "OnAbilityPhaseStart",        new ActionCollection() },
            { "OnOwnerSpawned",             new ActionCollection() },
            { "OnUpgrade",                  new ActionCollection() },
            { "OnProjectileHitUnit",        new ActionCollection() },
            { "OnProjectileFinish",         new ActionCollection() },   
            
            //ITEMS
            //{ "OnUnequip",                new ActionCollection() },
        };

        public List<BaseActionVariable> Variables = new List<BaseActionVariable>();


        public AbilityModifierCollection Modifiers = new AbilityModifierCollection();

        public AbilityActionCollection()
        {

        }

        public KeyValue ToKV()
        {
            KeyValue kv = new KeyValue("Actions");
            foreach (KeyValuePair<string, ActionCollection> k in Actions)
            {
                KeyValue child = k.Value.ToKV(k.Key);
                kv += child;
            }

            return kv;
        }

        public override string ToString()
        {
            KeyValue doc = ToKV();

            StringBuilder sb = new StringBuilder();
            foreach (KeyValue kv in doc.Children)
            {
                sb.AppendLine(kv.ToString());
            }
            return sb.ToString();
        }
    }
}
