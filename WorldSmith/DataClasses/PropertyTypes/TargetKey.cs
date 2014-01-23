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
        public enum CenterType
        {
            NONE,
            POINT,
            TARGET,
            ATTACKER,
            UNIT,
            CASTER,
        }

        public CenterType Center
        {
            get;
            set;
        }

        //Radius >='99999' will write to GLOBAL
        public int Radius
        {
            get;
            set;
        }

        public class ThicknessType
        {
            public int Length
            {
                get;
                set;
            }
            public int Thickness 
            {
                get;
                set;
            }

            public KeyValue ToKeyValue()
            {
                KeyValue root = new KeyValue("Line");
                root += new KeyValue("Length") + Length;
                root += new KeyValue("Thickness") + Thickness;
                return root;
            }

            public override string ToString()
            {
              return ToKeyValue().ToString();
            }
        }

        public ThicknessType Line
        {
            get;
            set;
        }

        [Flags]
        public enum TeamsType
        {
            IGNORE,
            DOTA_UNIT_TARGET_TEAM_ENEMY,
            DOTA_UNIT_TARGET_TEAM_FRIENDLY,
            DOTA_UNIT_TARGET_TEAM_BOTH,            
            DOTA_UNIT_TARGET_TEAM_CUSTOM,
        }

        public TeamsType Teams
        {
            get;
            set;
        }

        [Flags]
        public enum UnitTargetFlags
        {
            DOTA_UNIT_TARGET_FLAG_NONE                      = 0,
            DOTA_UNIT_TARGET_FLAG_RANGED_ONLY               = 1 << 1,
            DOTA_UNIT_TARGET_FLAG_MELEE_ONLY                = 1 << 2,
            DOTA_UNIT_TARGET_FLAG_DEAD                      = 1 << 3,
            DOTA_UNIT_TARGET_FLAG_MAGIC_IMMUNE_ENEMIES      = 1 << 4,
            DOTA_UNIT_TARGET_FLAG_NOT_MAGIC_IMMUNE_ALLIES   = 1 << 5,
            DOTA_UNIT_TARGET_FLAG_INVULNERABLE              = 1 << 6,
            DOTA_UNIT_TARGET_FLAG_FOW_VISIBLE               = 1 << 7,
            DOTA_UNIT_TARGET_FLAG_NO_INVIS                  = 1 << 8,
            DOTA_UNIT_TARGET_FLAG_NOT_ANCIENTS              = 1 << 9,
            DOTA_UNIT_TARGET_FLAG_PLAYER_CONTROLLED         = 1 << 10,
            DOTA_UNIT_TARGET_FLAG_NOT_DOMINATED             = 1 << 11,
            DOTA_UNIT_TARGET_FLAG_NOT_SUMMONED              = 1 << 12,
            DOTA_UNIT_TARGET_FLAG_NOT_ILLUSION              = 1 << 13,
            DOTA_UNIT_TARGET_FLAG_NOT_ATTACK_IMMUNE         = 1 << 14,
            DOTA_UNIT_TARGET_FLAG_MANA_ONLY                 = 1 << 15,
            DOTA_UNIT_TARGET_FLAG_CHECK_DISABLE_HELP        = 1 << 16,
            DOTA_UNIT_TARGET_FLAG_NOT_CREEP_HERO            = 1 << 17,
            DOTA_UNIT_TARGET_FLAG_OUT_OF_WORLD              = 1 << 18,
            DOTA_UNIT_TARGET_FLAG_NOT_NIGHTMARED            = 1 << 19,
        }

        public UnitTargetFlags Flags
        {
            get;
            set;
        }

        [Flags]
        public enum UnitTargetTypes
        {
            DOTA_UNIT_TARGET_NONE           = 0,
            DOTA_UNIT_TARGET_HERO           = 1 << 1,
            DOTA_UNIT_TARGET_CREEP          = 1 << 2,
            DOTA_UNIT_TARGET_BUILDING       = 1 << 3,
            DOTA_UNIT_TARGET_MECHANICAL     = 1 << 4,
            DOTA_UNIT_TARGET_COURIER        = 1 << 5,
            DOTA_UNIT_TARGET_OTHER          = 1 << 6,
            DOTA_UNIT_TARGET_TREE           = 1 << 7,
            DOTA_UNIT_TARGET_CUSTOM         = 1 << 8,
            DOTA_UNIT_TARGET_BASIC          = 1 << 9,
        }

        public UnitTargetTypes Types
        {
            get;
            set;
        }

        public UnitTargetTypes ExcludeTypes
        {
            get;
            set;
        }

        public int MaxTargets
        {
            get;
            set;
        }

        public bool Random
        {
            get;
            set;
        }

        public TargetKey()
        {

        }

        public TargetKey(string value)
        {

        }

        public TargetKey(KeyValue kv)
        {

        }




    }
}
