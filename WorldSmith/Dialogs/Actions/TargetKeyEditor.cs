using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Panels;

namespace WorldSmith.Dialogs.Actions
{
    public partial class TargetKeyEditor : Form
    {

        Dictionary<string, string[]> ContextTargets = new Dictionary<string, string[]>()
        {
            //ABILITY EVENT CONTEXTS
            { "OnSpellStart", new string[] { "CASTER", "TARGET", "POINT" } },
            { "OnChannelSucceeded", new string[] { "CASTER", "TARGET", "POINT" } },
            { "OnChannelInterrupted", new string[] { "CASTER", "TARGET", "POINT" } },
            { "OnChannelFinish", new string[] { "CASTER", "TARGET", "POINT" } },
            { "OnAbilityPhaseStart", new string[] { "CASTER", "TARGET", "POINT" } },
          
            
            { "OnOwnerDied", new string[] { "UNIT" } },
            { "OnOwnerSpawned", new string[] { "UNIT" } },
            { "OnUpgrade", new string[] { "UNIT" } },
            { "OnToggleOn", new string[] { "UNIT" } },
            { "OnToggleOff", new string[] { "UNIT" } },

            { "OnProjectileHitUnit", new string[] { "CASTER", "TARGET", "POINT", "PROJECTILE" } },
            { "OnProjectileFinish", new string[] { "CASTER", "TARGET", "POINT", "PROJECTILE" } },

            //MODIFER EVENT CONTEXTS
            { "OnAttacked", new string[] { "ATTACKER", "UNIT" } },
            { "OnIntervalThink", new string[] { "UNIT", "TARGET", "CASTER" } },
            { "OnCreated", new string[] { "CASTER", "TARGET" } },
            { "OnAttackLanded", new string[] { "ATTACKER", "UNIT", "TARGET", "CASTER"} },
            { "OnTakeDamage", new string[] { "ATTACKER", "TARGET", "CASTER" } },
            { "OnDealDamage", new string[] { "ATTACKER", "TARGET", "CASTER" } },
            { "OnDeath", new string[] { "UNIT", "CASTER" } },
            { "OnKill", new string[] { "TARGET", "CASTER" } },
            { "OnAttackStart", new string[] { "CASTER", "TARGET" } },
            { "OnDestroy", new string[] { "CASTER", "TARGET" } },
        };

        public TargetKey Target
        {
            get;
            set;
        }

        public TargetKeyEditor(TargetKey target)
        {

            InitializeComponent();
            Target = target;
            InitLinks();
        }

        public TargetKeyEditor()
            : this(new TargetKey())
        {
            
        }

        public void SetPresets(string category)
        {
            if (!ContextTargets.ContainsKey(category)) return;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ContextTargets[category]);
            comboBox1.SelectedIndex = 0;
        }

        private void InitLinks()
        {
            linkHeader.Grammer = "Create a %Type centered around %Center";
            linkHeader.Object = Target;
            CenterType(true);
            linkTargetFilter.Grammer = "That targets %Types on %Teams with %Flags";
            linkTargetFilter.Object = Target;
            linkChance.Grammer = "and selects %MaxTargets and %Random additional units";
            linkChance.Object = Target;
        

        }



        private void CenterType(bool type)
        {

            if (type)
            {
                linkLineOrCircle.Grammer = "With radius %Radius";
            }
            else
            {
                linkLineOrCircle.Grammer = "With Length %Length and Thickness %Thickness";
              
            }
            linkLineOrCircle.Object = Target;              

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                radioButton2.Checked = false;
                linkHeader.Enabled = false;
                linkLineOrCircle.Enabled = false;
                linkTargetFilter.Enabled = false;
                linkChance.Enabled = false;

                comboBox1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                linkHeader.Enabled = true;
                linkLineOrCircle.Enabled = true;
                linkTargetFilter.Enabled = true;
                linkChance.Enabled = true;

                comboBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
