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
            return new AbilityActionCollection(null);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value == null) return "";
            return value.ToString();
        }
    }

  

    public class AbilityActionCollection : IEnumerable<DotaActionCollection>
    {
      
        public DotaScriptCollection<BaseActionVariable> Variables;


        public DotaScriptCollection<DotaModifier> Modifiers;

        public DotaAbility Ability
        {
            get;
            private set;
        }

        
        public AbilityActionCollection(DotaAbility ability)
        {
            Ability = ability;
            KeyValue kv = ability.KeyValue["Modifiers"];
            if(kv == null)
            {
                kv = new KeyValue("Modifiers");
            }
            Modifiers = new DotaScriptCollection<DotaModifier>(kv);

            kv = ability.KeyValue["AbilitySpecial"];
            if(kv == null)
            {
                kv = new KeyValue("AbilitySpecial");
            }
            Variables = new DotaScriptCollection<BaseActionVariable>(kv);

        }
            
        
        public DotaActionCollection GetActionCollection(DotaEvent Event)
        {
            if (!Event.EventAppliesTo.HasFlag(DotaEvent.EventAppliesToFlags.ABILITY)) return null;

            KeyValue actionCollection = Ability.KeyValue[Event.ClassName];
            if (actionCollection == null) return null; //No action collection at that key

            return new DotaActionCollection(actionCollection);
        }
             

      
        public DotaActionCollection this[string Key]
        {
            get
            {
                DotaEvent ev = DotaData.Events.FirstOrDefault(x => x.EventAppliesTo.HasFlag(DotaEvent.EventAppliesToFlags.ABILITY));
                if (ev == null) return null;
                return GetActionCollection(ev);                
            }
        }



        public IEnumerator<DotaActionCollection> GetEnumerator()
        {
            foreach(DotaEvent key in DotaData.Events.Where(x => x.EventAppliesTo.HasFlag(DotaEvent.EventAppliesToFlags.ABILITY)))
            {
                DotaActionCollection ac = GetActionCollection(key);
                if (ac == null) continue;
                yield return ac;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (DotaEvent key in DotaData.Events.Where(x => x.EventAppliesTo.HasFlag(DotaEvent.EventAppliesToFlags.ABILITY)))
            {
                DotaActionCollection ac = GetActionCollection(key);
                if (ac == null) continue;
                yield return ac;
            }
        }
    }
}
