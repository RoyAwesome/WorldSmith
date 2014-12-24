using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WorldSmith.DataClasses;

namespace WorldSmith.Panels
{
    public partial class DotaObjectEditor : DockContent, IEditor
    {

        private bool HideConfirmation = false;

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
            this.FormClosing += DotaObjectEditor_FormClosing;
        }

        void DotaObjectEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveDocument.NotifyEditorClosed(this);
        }

        public Documents.Document ActiveDocument
        {
            get;
            set;
        }

        public void NotifyDocumentModified(IEditor source)
        {
            
        }

        public void NotifyDocumentSaved(IEditor source)
        {
            //If we are the source, don't do anything.  We already have the changes
            if(source != this)
            {
                DotaDataObject obj = EditingObject;
                //Force the property editor to clear out the data and redraw
                EditingObject = null;
                EditingObject = obj;
            }
          
        }


        public void CloseDocument(bool ConfirmChanges)
        {
            HideConfirmation = !ConfirmChanges;
            this.Close();
        }
    }
}
