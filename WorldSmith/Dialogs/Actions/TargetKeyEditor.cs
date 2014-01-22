using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public TargetKeyEditor()
        {
            InitializeComponent();
        }

        private void InitLinks()
        {
            AddLinks(linkHeader);
            CenterType(true);
            AddLinks(linkTargetFilter);
            AddLinks(linkChance);

        }

        private void AddLinks(LinkLabel label)
        {
            string text = label.Text;

            label.Links.Clear();

            //Find each % and get the positions to create links
            int ind = text.IndexOf('%', 0);
            int count = 0;
            while (ind != -1)
            {
                int start = ind;
                int end = text.IndexOf(' ', start);
                int len = end == -1 ? text.Length - start : end - start;

                label.Links.Add(start - count, len - 1, text.Substring(start + 1, len - 1)); //Shif the region back one because we remove the % signs.

                ind = text.IndexOf('%', start + len);

                count++;

            }
            
            label.Text = text.Replace("%", "");

        }


        private void CenterType(bool type)
        {

            if (type)
            {
                linkLineOrCircle.Text = "With radius %Radius";
            }
            else
            {
                linkLineOrCircle.Text = "With Length %Length and Thickness %Thickness";
              
            }
            AddLinks(linkLineOrCircle);                

        }

    }
}
