using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class TargetKey : DotaDataObject
    {
        public static TargetKey DefaultTarget
            {
                get { return new TargetKey(); }
            }
      
        public string Preset
        {
            get
            {
                if (KeyValue.HasChildren) return null;
                return KeyValue.GetString();
            }
            set
            {
                if (KeyValue.HasChildren) KeyValue.ClearChildren();
                KeyValue.Set(value);
            }
        }

        public enum ShapeE
        {
            CIRCLE,
            LINE,
        }

        public ShapeE Shape
        {
            get
            {
                KeyValue kv = GetSubkey("Shape");
                return (kv == null ? ShapeE.LINE : kv.GetEnum<ShapeE>());
            }
            set
            {
                KeyValue kv = GetSubkey("Shape");
                if (kv == null)
                {
                    kv = new KeyValue("Shape");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public string Center
        {
            get
            {
                KeyValue kv = GetSubkey("Center");
                return (kv == null ? "" : kv.GetString());
            }
            set
            {
                KeyValue kv = GetSubkey("Center");
                if (kv == null)
                {
                    kv = new KeyValue("Center");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public NumberValue Radius
        {
            get
            {
                KeyValue kv = GetSubkey("Radius");
                return (kv == null ? new NumberValue("") : kv.GetNumberValue());
            }
            set
            {
                KeyValue kv = GetSubkey("Radius");
                if (kv == null)
                {
                    kv = new KeyValue("Radius");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public NumberValue Length
        {
            get
            {
                KeyValue kv = GetSubkey("Length");
                return (kv == null ? new NumberValue("") : kv.GetNumberValue());
            }
            set
            {
                KeyValue kv = GetSubkey("Length");
                if (kv == null)
                {
                    kv = new KeyValue("Length");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public NumberValue Thickness
        {
            get
            {
                KeyValue kv = GetSubkey("Thickness");
                return (kv == null ? new NumberValue("") : kv.GetNumberValue());
            }
            set
            {
                KeyValue kv = GetSubkey("Thickness");
                if (kv == null)
                {
                    kv = new KeyValue("Thickness");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        [Flags]
        public enum AbilityUnitTargetTeamFlags
        {
            DOTA_UNIT_TARGET_TEAM_NONE = 0,
            DOTA_UNIT_TARGET_TEAM_ENEMY = 1 << 1,
            DOTA_UNIT_TARGET_TEAM_FRIENDLY = 1 << 2,
            DOTA_UNIT_TARGET_TEAM_CUSTOM = 1 << 3,
            DOTA_UNIT_TARGET_TEAM_BOTH = 1 << 4,
        }

        public AbilityUnitTargetTeamFlags Teams
        {
            get
            {
                KeyValue kv = GetSubkey("Teams");
                return (kv == null ? AbilityUnitTargetTeamFlags.DOTA_UNIT_TARGET_TEAM_NONE : kv.GetEnum<AbilityUnitTargetTeamFlags>());
            }
            set
            {
                KeyValue kv = GetSubkey("Teams");
                if (kv == null)
                {
                    kv = new KeyValue("Teams");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        [Flags]
        public enum AbilityUnitTargetTypeFlags
        {
            DOTA_UNIT_TARGET_NONE = 0,
            DOTA_UNIT_TARGET_HERO = 1 << 1,
            DOTA_UNIT_TARGET_CREEP = 1 << 2,
            DOTA_UNIT_TARGET_BUILDING = 1 << 3,
            DOTA_UNIT_TARGET_MECHANICAL = 1 << 4,
            DOTA_UNIT_TARGET_COURIER = 1 << 5,
            DOTA_UNIT_TARGET_OTHER = 1 << 6,
            DOTA_UNIT_TARGET_TREE = 1 << 7,
            DOTA_UNIT_TARGET_CUSTOM = 1 << 8,
            DOTA_UNIT_TARGET_BASIC = 1 << 9,
        }

        public AbilityUnitTargetTypeFlags UnitTypes
        {
            get
            {
                KeyValue kv = GetSubkey("UnitTypes");
                return (kv == null ? AbilityUnitTargetTypeFlags.DOTA_UNIT_TARGET_NONE : kv.GetEnum<AbilityUnitTargetTypeFlags>());
            }
            set
            {
                KeyValue kv = GetSubkey("UnitTypes");
                if (kv == null)
                {
                    kv = new KeyValue("UnitTypes");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        [Flags]
        public enum AbilityUnitTargetFlags
        {
            DOTA_UNIT_TARGET_FLAG_NONE = 0,
            DOTA_UNIT_TARGET_FLAG_RANGED_ONLY = 1 << 1,
            DOTA_UNIT_TARGET_FLAG_MELEE_ONLY = 1 << 2,
            DOTA_UNIT_TARGET_FLAG_DEAD = 1 << 3,
            DOTA_UNIT_TARGET_FLAG_MAGIC_IMMUNE_ENEMIES = 1 << 4,
            DOTA_UNIT_TARGET_FLAG_NOT_MAGIC_IMMUNE_ALLIES = 1 << 5,
            DOTA_UNIT_TARGET_FLAG_INVULNERABLE = 1 << 6,
            DOTA_UNIT_TARGET_FLAG_FOW_VISIBLE = 1 << 7,
            DOTA_UNIT_TARGET_FLAG_NO_INVIS = 1 << 8,
            DOTA_UNIT_TARGET_FLAG_NOT_ANCIENTS = 1 << 9,
            DOTA_UNIT_TARGET_FLAG_PLAYER_CONTROLLED = 1 << 10,
            DOTA_UNIT_TARGET_FLAG_NOT_DOMINATED = 1 << 11,
            DOTA_UNIT_TARGET_FLAG_NOT_SUMMONED = 1 << 12,
            DOTA_UNIT_TARGET_FLAG_NOT_ILLUSION = 1 << 13,
            DOTA_UNIT_TARGET_FLAG_NOT_ATTACK_IMMUNE = 1 << 14,
            DOTA_UNIT_TARGET_FLAG_MANA_ONLY = 1 << 15,
            DOTA_UNIT_TARGET_FLAG_CHECK_DISABLE_HELP = 1 << 16,
            DOTA_UNIT_TARGET_FLAG_NOT_CREEP_HERO = 1 << 17,
            DOTA_UNIT_TARGET_FLAG_OUT_OF_WORLD = 1 << 18,
            DOTA_UNIT_TARGET_FLAG_NOT_NIGHTMARED = 1 << 19,
        }

        public AbilityUnitTargetFlags Flags
        {
            get
            {
                KeyValue kv = GetSubkey("Flags");
                return (kv == null ? AbilityUnitTargetFlags.DOTA_UNIT_TARGET_FLAG_NONE : kv.GetEnum<AbilityUnitTargetFlags>());
            }
            set
            {
                KeyValue kv = GetSubkey("Flags");
                if (kv == null)
                {
                    kv = new KeyValue("Flags");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public NumberValue MaxTargets
        {
            get
            {
                KeyValue kv = GetSubkey("MaxTargets");
                return (kv == null ? new NumberValue("") : kv.GetNumberValue());
            }
            set
            {
                KeyValue kv = GetSubkey("MaxTargets");
                if (kv == null)
                {
                    kv = new KeyValue("MaxTargets");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public NumberValue Random
        {
            get
            {
                KeyValue kv = GetSubkey("Random");
                return (kv == null ? new NumberValue("") : kv.GetNumberValue());
            }
            set
            {
                KeyValue kv = GetSubkey("Random");
                if (kv == null)
                {
                    kv = new KeyValue("Random");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public TargetKey(string Preset)
            : base(new KeyValue("Target") + Preset)
        {

        }

    
        public TargetKey(KeyValue kv)
            : base(kv)
        {

        }

        public TargetKey()
            : base(new KeyValue("Target") + "Caster")
        {

        }
        
        
    }
}
