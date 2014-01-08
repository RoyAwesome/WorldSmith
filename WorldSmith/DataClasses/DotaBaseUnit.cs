using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    class DotaBaseUnit : DotaDataObject
    {     
        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue("models/development/invisiblebox.mdl")]
        public string Model
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string SoundSet
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(1)]
        public int Level
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(false)]
        public bool IsAncient
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(false)]
        public bool IsNeutralUnitType
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string SelectionGroup
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(false)]
        public bool SelectOnSpawn
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(true)]
        public bool CanBeDominated
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(false)]
        public bool IgnoreAddSummonedToSelection
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(true)]
        public bool AutoAttacksByDefault
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability1
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability2
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability3
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability4
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability5
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability6
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability7
        {
            get;
            set;
        }


        [Category("Abilities")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string Ability8
        {
            get;
            set;
        }


        [Category("Armor")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int ArmorPhysical
        {
            get;
            set;
        }


        [Category("Armor")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int MagicalResistance
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_UNIT_CAP_NO_ATTACK")]
        public string AttackCapabilities
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(1)]
        public int AttackDamageMin
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(1)]
        public int AttackDamageMax
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue("DAMAGE_TYPE_ArmorPhysical")]
        public string AttackDamageType
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(1.7)]
        public float AttackRate
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(0.75)]
        public float AttackAnimationPoint
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(800)]
        public int AttackAcquisitionRange
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(600)]
        public int AttackRange
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(250)]
        public int AttackRangeBuffer
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string ProjectileModel
        {
            get;
            set;
        }


        [Category("Attack")]
        [Description("No Description Set")]
        [DefaultValue(900)]
        public int ProjectileSpeed
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_ATTRIBUTE_STRENGTH")]
        public string AttributePrimary
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int AttributeBaseStrength
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int AttributeStrengthGain
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int AttributeBaseIntelligence
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int AttributeIntelligenceGain
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int AttributeBaseAgility
        {
            get;
            set;
        }


        [Category("Attributes")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int AttributeAgilityGain
        {
            get;
            set;
        }


        [Category("Bounty")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int BountyXP
        {
            get;
            set;
        }


        [Category("Bounty")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int BountyGoldMin
        {
            get;
            set;
        }


        [Category("Bounty")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int BountyGoldMax
        {
            get;
            set;
        }


        [Category("Bounds")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_HULL_SIZE_HERO")]
        public string BoundsHullName
        {
            get;
            set;
        }


        [Category("Bounds")]
        [Description("No Description Set")]
        [DefaultValue(50)]
        public int RingRadius
        {
            get;
            set;
        }


        [Category("Bounds")]
        [Description("No Description Set")]
        [DefaultValue(-1)]
        public int HealthBarOffset
        {
            get;
            set;
        }


        [Category("Movement")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_UNIT_CAP_MOVE_NONE")]
        public string MovementCapabilities
        {
            get;
            set;
        }


        [Category("Movement")]
        [Description("No Description Set")]
        [DefaultValue(300)]
        public int MovementSpeed
        {
            get;
            set;
        }


        [Category("Movement")]
        [Description("No Description Set")]
        [DefaultValue(0.5)]
        public float MovementTurnRate
        {
            get;
            set;
        }


        [Category("Movement")]
        [Description("No Description Set")]
        [DefaultValue(false)]
        public bool HasAggressiveStance
        {
            get;
            set;
        }


        [Category("Movement")]
        [Description("No Description Set")]
        [DefaultValue(100)]
        public int FollowRange
        {
            get;
            set;
        }


        [Category("Status")]
        [Description("No Description Set")]
        [DefaultValue(150)]
        public int StatusHealth
        {
            get;
            set;
        }


        [Category("Status")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int StatusHealthRegen
        {
            get;
            set;
        }


        [Category("Status")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int StatusMana
        {
            get;
            set;
        }


        [Category("Status")]
        [Description("No Description Set")]
        [DefaultValue(0)]
        public int StatusManaRegen
        {
            get;
            set;
        }


        [Category("Status")]
        [Description("No Description Set")]
        [DefaultValue(-1)]
        public int StatusStartingMana
        {
            get;
            set;
        }


        [Category("Team")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_TEAM_NEUTRALS")]
        public string TeamName
        {
            get;
            set;
        }


        [Category("Team")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_COMBAT_CLASS_ATTACK_HERO")]
        public string CombatClassAttack
        {
            get;
            set;
        }


        [Category("Team")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_COMBAT_CLASS_DEFEND_HERO")]
        public string CombatClassDefend
        {
            get;
            set;
        }


        [Category("Team")]
        [Description("No Description Set")]
        [DefaultValue("DOTA_NPC_UNIT_RELATIONSHIP_TYPE_DEFAULT")]
        public string UnitRelationshipClass
        {
            get;
            set;
        }


        [Category("Vision")]
        [Description("No Description Set")]
        [DefaultValue(575)]
        public int VisionDaytimeRange
        {
            get;
            set;
        }


        [Category("Vision")]
        [Description("No Description Set")]
        [DefaultValue(575)]
        public int VisionNighttimeRange
        {
            get;
            set;
        }


        [Category("Bots")]
        [Description("No Description Set")]
        [DefaultValue(1)]
        public float AttackDesire
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(false)]
        public bool HasInventory
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue(true)]
        public bool WakesNeutrals
        {
            get;
            set;
        }


        [Category("General")]
        [Description("No Description Set")]
        [DefaultValue("")]
        public string IdleSoundLoop
        {
            get;
            set;
        }





    }
}
