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
        [Category("Unit Base")]
        [Description("Path to the unit's model")]
        [DefaultValue("")]
        public string Model
        {
            get;
            set;
        }
        [Category("Unit Base")]
        [Description("Unit's soundset")]
        [DefaultValue("")]
        public string SoundSet
        {
            get;
            set;
        }

        [Category("Unit Base")]
        [Description("Unit's Level")]
        [DefaultValue(1)]
        public int Level
        {
            get;
            set;
        }


        [Category("Unit Base")]
        [Description("Is this unit considered an Ancient in the context of abilities?")]
        [DefaultValue(false)]
        public bool IsAncient
        {
            get;
            set;
        }

        [Category("Unit Base")]
        [Description("Is this unit considered a Neutral Unit?")]
        [DefaultValue(false)]
        public bool IsNeutralUnitType
        {
            get;
            set;
        }

        [Category("Unit Base")]
        [Description("Units with the same selection group will cycle together when tabbing through owned units")]
        [DefaultValue("")]
        public string SelectionGroup
        {
            get;
            set;
        }

        [Category("Unit Base")]
        [Description("Owner selects this unit when it's spawned")]
        [DefaultValue(false)]
        public bool SelectOnSpawn
        {
            get;
            set;
        }

        [Category("Unit Base")]
        [Description("Can this unit be dominated")]
        [DefaultValue(true)]
        public bool CanBeDominated
        {
            get;
            set;
        }
        [Category("Unit Base")]
        [Description("Ignore Add Summoned To Selection")]
        [DefaultValue(false)]
        public bool IgnoreAddSummonedToSelection
        {
            get;
            set;
        }       
    }
}
