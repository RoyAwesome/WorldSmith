using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSmith.Dialogs
{
    public partial class CreateObjectDialog : Form
    {
        public CreateObjectDialog(int Type)
        {
            InitializeComponent();

            switch (Type)
            {
                case 1: //Type 1 is heroes
                    labelBase.Text = "Base Hero:";
                    this.Text = "Create New Custom Hero";
                    codFillInFromList(1, WorldSmith.DataClasses.DotaData.DefaultHeroes);
                    break;
                case 2: //Type 2 is units
                    labelBase.Text = "Base Unit:";
                    this.Text = "Create New Custom Unit";
                    codFillInFromList(1, WorldSmith.DataClasses.DotaData.AllUnits);
                    break;
                case 3: //Type 3 is abilities
                    labelBase.Text = "Base Ability:";
                    this.Text = "Create New Custom Ability";
                    codFillInFromList(1, WorldSmith.DataClasses.DotaData.AllAbilities);
                    break;
                case 4: //Type 4 is items
                    labelBase.Text = "Base Item:";
                    this.Text = "Create New Custom Item";
                    codFillInFromList(1, WorldSmith.DataClasses.DotaData.AllItems);
                    break;

            }
        }

        private void codFillInFromList(int Type, IEnumerable<WorldSmith.DataClasses.DotaDataObject> ObjectList)
        {
            foreach (WorldSmith.DataClasses.DotaDataObject ddo in ObjectList)
            {
                objectListBox.Items.Add(ddo.ClassName);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
