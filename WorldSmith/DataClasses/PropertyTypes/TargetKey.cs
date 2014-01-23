using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class TargetKey
    {
        public enum PresetType
        {
            NONE,
            CASTER,
            TARGET,
            POINT,
            UNIT,
            PROJECTILE,
            ATTACKER,
        }

        public PresetType Preset
        {
            get;
            set;
        }

        public enum ShapeE
        {
            CIRCLE,
            LINE,
        }

        public ShapeE Shape
        {
            get;
            set;
        }

        public PresetType Center
        {
            get;
            set;
        }

        public NumberValue Radius
        {
            get;
            set;
        }

        public NumberValue Length
        {
            get;
            set;
        }

        public NumberValue Thickness
        {
            get;
            set;
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

        public AbilityUnitTargetTypeFlags Teams
        {
            get;
            set;
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
            get;
            set;
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

        public AbilityUnitTargetTypeFlags Flags
        {
            get;
            set;
        }

        public NumberValue MaxTargets
        {
            get;
            set;
        }

        public NumberValue Random
        {
            get;
            set;
        }

        public TargetKey()
        {
            Preset = PresetType.TARGET;
        }

        public KeyValue ToKV(string key)
        {
            KeyValue kv = new KeyValue(key);
            if (Preset != PresetType.NONE)
            {
                kv += Preset.ToString();
                return kv;
            }
            kv += new KeyValue("Center") + Center.ToString();
            if(this.Shape == ShapeE.CIRCLE)
            {
                kv += new KeyValue("Radius") + Radius.ToString();
            }
            if(this.Shape == ShapeE.LINE)
            {
                KeyValue linechild = new KeyValue("Line");
                linechild += new KeyValue("Length") + Length.ToString();
                linechild += new KeyValue("Thickness") + Thickness.ToString();
            }
            
            kv += new KeyValue("Teams") + Teams.ToString().Replace(",", " |");
            kv += new KeyValue("Types") + UnitTypes.ToString().Replace(",", " |");
            kv += new KeyValue("Flags") + Flags.ToString().Replace(",", " |");

            if(MaxTargets.Value != "-1")
            {
                kv += new KeyValue("MaxTargets") + MaxTargets.ToString();
                kv += new KeyValue("Random") + Random.ToString();
            }
                       

            return kv;
        }

        public KeyValue ToKV()
        {
            return ToKV("Target");
        }

        public override string ToString()
        {
            return ToKV().ToString();
        }
        
    }
}
