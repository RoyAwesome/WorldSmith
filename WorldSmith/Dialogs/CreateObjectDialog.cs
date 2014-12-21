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

namespace WorldSmith.Dialogs
{
    public partial class CreateObjectDialog : Form
    {
        public CreateObjectDialog(DotaType type)
        {
            InitializeComponent();

            dialogType = type;
 
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

        private DotaType dialogType;

        private void FillInFromList(int Type, IEnumerable<DotaDataObject> ObjectList)
        {
            foreach (DotaDataObject ddo in ObjectList)
            {
                objectListBox.Items.Add(ddo.ClassName);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(nameTextBox.Text)) && (!String.IsNullOrEmpty(objectListBox.SelectedItem.ToString())))
            {
                switch (dialogType)
                {
                    case DotaType.Hero:
                        MessageBox.Show("Creating of custom heroes is not yet supported.");
                        /**
                        DotaHero baseHero =
                            DotaData.AllHeroes.FirstOrDefault(x => x.ClassName == objectListBox.SelectedItem.ToString());
                        DotaHero hero = new DotaHero();
                        hero.BaseClass = baseHero.ClassName;
                        hero.ClassName = nameTextBox.Text;
                        DotaData.AllHeroes.Add(hero); 
                        **/
                        break;

                    case DotaType.Unit:

                        DotaUnit baseUnit =
                            DotaData.AllUnits.FirstOrDefault(x => x.ClassName == objectListBox.SelectedItem.ToString());
                        DotaUnit unit = new DotaUnit(nameTextBox.Text);
                        unit.BaseClass = baseUnit.ClassName;
                        unit.ObjectInfo.ObjectClass = DotaDataObject.DataObjectInfo.ObjectDataClass.Custom;
                        DotaData.AllUnits.Add(unit);
                        break;

                    case DotaType.Ability:
                        DotaAbility baseAbility =
                            DotaData.AllAbilities.FirstOrDefault(x => x.ClassName == objectListBox.SelectedItem.ToString());
                        DotaAbility ability = new DotaAbility(nameTextBox.Text);
                        ability.BaseClass = baseAbility.ClassName;
                        ability.ObjectInfo.ObjectClass = DotaDataObject.DataObjectInfo.ObjectDataClass.Custom;
                        DotaData.AllAbilities.Add(ability);
                        break;

                    case DotaType.Item:
                        DotaItem baseItem =
                            DotaData.AllItems.FirstOrDefault(x => x.ClassName == objectListBox.SelectedItem.ToString());
                        DotaItem item = new DotaItem(nameTextBox.Text);
                        item.BaseClass = baseItem.ClassName;
                        item.ObjectInfo.ObjectClass = DotaDataObject.DataObjectInfo.ObjectDataClass.Custom;
                        DotaData.AllItems.Add(item);
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                switch (dialogType)
                {
                    case DotaType.Hero:
                        MessageBox.Show("Please enter a valid hero name and select a base hero.");
                        break;
                    case DotaType.Unit:
                        MessageBox.Show("Please enter a valid unit name and select a base unit.");
                        break;
                    case DotaType.Ability:
                        MessageBox.Show("Please enter a valid ability name and select a base ability.");
                        break;
                    case DotaType.Item:
                        MessageBox.Show("Please enter a valid item name and select a base item.");
                        break;
                }
            }
            
                
            
        }
    }
}
