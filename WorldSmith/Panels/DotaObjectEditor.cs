using DigitalRune.Windows.Docking;
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

namespace WorldSmith.Panels
{
    public partial class DotaObjectEditor : DockableForm
    {

        public DotaDataObject EditingObject
        {
            get
            {
                return propertyGrid1.SelectedObject as DotaDataObject;
            }
            set
            {
                propertyGrid1.SelectedObject = value;
            }
        }
        
        public DotaObjectEditor()
        {
            InitializeComponent();
        }
    }
}
