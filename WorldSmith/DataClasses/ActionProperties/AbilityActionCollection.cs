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

  

    public class AbilityActionCollection : IEnumerable<ActionCollection>
    {
        public static List<string> AllActions = new List<string>()
        {
            "OnSpellStart",
            "OnChannelSucceeded",  
            "OnChannelInterrupted",
            "OnChannelFinish",     
            "OnToggleOn",          
            "OnToggleOff",         
            "OnAbilityPhaseStart", 
            "OnOwnerDied",
            "OnOwnerSpawned",      
            "OnUpgrade",           
            "OnProjectileHitUnit", 
            "OnProjectileFinish",  
        };


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

        public bool HasCollection(string key)
        {
            if (!AllActions.Contains(key))
            {
                return false;
            }

            KeyValue actionCollection = Ability.KeyValue[key];
            return actionCollection != null;
        }
        
        public ActionCollection GetActionCollection(string Key)
        {
            if (!AllActions.Contains(Key))
            {
                return null;
            }

            KeyValue actionCollection = Ability.KeyValue[Key];
            if (actionCollection == null) return null; //No action collection at that key

            return new ActionCollection(Key, actionCollection);
        }

        public void CreateActionCollection(string key)
        {
            if (HasCollection(key)) throw new ArgumentException("Already have a ActionCollection for key " + key);

            KeyValue kv = new KeyValue(key);
            Ability.KeyValue.AddChild(kv);

        }

      
        public ActionCollection this[string Key]
        {
            get
            {
                return GetActionCollection(Key);                
            }
        }



        public IEnumerator<ActionCollection> GetEnumerator()
        {
            foreach(string key in AllActions)
            {
                ActionCollection ac = GetActionCollection(key);
                if (ac == null) continue;
                yield return ac;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (string key in AllActions)
            {
                ActionCollection ac = GetActionCollection(key);
                if (ac == null) continue;
                yield return ac;
            }
        }
    }
}
