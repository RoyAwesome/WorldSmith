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

        public const string DEFAULT_UNIT_CLASS = "npc_dota_creature";
        public const string DEFAULT_ABILITY_CLASS = "ability_datadriven";
        public const string DEFAULT_ITEM_CLASS = "item_datadriven";

        private void FillInFromList(int Type, IEnumerable<DotaDataObject> ObjectList)
        {
            switch (dialogType)
            {
                case DotaType.Hero:
                    break;
                case DotaType.Unit:
                    objectListBox.Items.Add(DEFAULT_UNIT_CLASS);
                    break;
                case DotaType.Ability:
                    objectListBox.Items.Add(DEFAULT_ABILITY_CLASS);
                    break;
                case DotaType.Item:
                    objectListBox.Items.Add(DEFAULT_ITEM_CLASS);
                    break;
            }
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
            if (!String.IsNullOrEmpty(nameTextBox.Text))
            {

                switch(dialogType)
                {
                    case DotaType.Hero:
                        MessageBox.Show("Dota 2 does not currently support custom heroes.");
                        break;
                    case DotaType.Unit:
                        DotaUnit unit = new DotaUnit(nameTextBox.Text);
                        unit.BaseClass = DEFAULT_UNIT_CLASS;
                        if (objectListBox.SelectedIndex != -1) unit.BaseClass = objectListBox.SelectedItem.ToString();
                        unit.ObjectInfo.ObjectClass = DotaDataObject.DataObjectInfo.ObjectDataClass.Custom;
                        DotaData.AllUnits.Add(unit);
                        break;
                    case DotaType.Ability:
                        DotaAbility ability = new DotaAbility(nameTextBox.Text);
                        ability.BaseClass = DEFAULT_ABILITY_CLASS;
                        if (objectListBox.SelectedIndex != -1) ability.BaseClass = objectListBox.SelectedItem.ToString();
                        ability.ObjectInfo.ObjectClass = DotaDataObject.DataObjectInfo.ObjectDataClass.Custom;
                        DotaData.AllAbilities.Add(ability);
                        break;
                    case DotaType.Item:
                        DotaItem item = new DotaItem(nameTextBox.Text);
                        item.BaseClass = DEFAULT_ITEM_CLASS;
                        if (objectListBox.SelectedIndex != -1) item.BaseClass = objectListBox.SelectedItem.ToString();
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
                        MessageBox.Show("Please enter a valid hero name.");
                        break;
                    case DotaType.Unit:
                        MessageBox.Show("Please enter a valid unit name.");
                        break;
                    case DotaType.Ability:
                        MessageBox.Show("Please enter a valid ability name.");
                        break;
                    case DotaType.Item:
                        MessageBox.Show("Please enter a valid item name.");
                        break;
                }
            }
            
                
            
        }
    }
}
