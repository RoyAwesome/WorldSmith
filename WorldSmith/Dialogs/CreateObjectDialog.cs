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

namespace WorldSmith.Dialogs
{
    public partial class CreateObjectDialog : Form
    {
        public CreateObjectDialog(DotaType type)
        {
            InitializeComponent();
        

 
            switch (type)
            {
                case DotaType.Hero:
                    labelBase.Text = "Base Hero:";
                    this.Text = "Create New Custom Hero";
                    FillInFromList(1, DotaData.DefaultHeroes);
                    break;
                case DotaType.Unit:
                    labelBase.Text = "Base Unit:";
                    this.Text = "Create New Custom Unit";
                    FillInFromList(1, DotaData.AllUnits);
                    break;
                case DotaType.Ability:
                    labelBase.Text = "Base Ability:";
                    this.Text = "Create New Custom Ability";
                    FillInFromList(1, DotaData.AllAbilities);
                    break;
                case DotaType.Item:
                    labelBase.Text = "Base Item:";
                    this.Text = "Create New Custom Item";
                    FillInFromList(1, DotaData.AllItems);
                    break;

            }
        }

        public enum DotaType
        {
            Hero,
            Unit,
            Ability,
            Item
        };

        private void FillInFromList(int Type, IEnumerable<DotaDataObject> ObjectList)
        {
            foreach (DotaDataObject ddo in ObjectList)
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
