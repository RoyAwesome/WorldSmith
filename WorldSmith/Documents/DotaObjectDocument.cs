using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;
using WorldSmith.DataClasses;
using WorldSmith.Panels;

namespace WorldSmith.Documents
{
    public class DotaObjectDocument : TextDocument
    {
        public readonly DotaDataObject DotaObject;

        public DotaObjectDocument(DotaDataObject RootObject)
            : base()
        {
            DotaObject = RootObject;

            //TODO: Some discovery if this object came from the VPK or from the addon. 
            //For now, source it from the addon.  We'll fix this stuff later.
            Source = DocumentSource.File;
            Path = ""; //Path here is empty.  Saving this document does 'nothing' as it will be serialized into the npc_units_custom.txt when the addon is 
                        //put together
            Name = RootObject.ClassName;
        }

        protected override string GetDocumentText()
        {
            return DotaObject.KeyValue.ToString();
        }

        protected override void DoSave()
        {
            //Commit these changes to the dota object.  
            //TODO: If a text editor is open here, get the text and serialize it into the dota object
        }

        public override void Reload()
        {
            //Nothing
        }

        public override bool CanEditorOpen(Type EditorType)
        {
            if (EditorType == typeof(TextEditor) || EditorType == typeof(DotaObjectEditor)) return true;
            return false;
        }

        public override void OpenDefaultEditor()
        {
            OpenObjectEditor(); 
            //OpenTextEditor();

        }

        public override TextEditor OpenTextEditor()
        {
            TextEditor editor = base.OpenTextEditor();
            editor.TabText = DotaObject.ClassName + " Text";
            return editor;
        }

        public DotaObjectEditor OpenObjectEditor()
        {
            bool EditorWasOpen = ContainsEditor<DotaObjectEditor>();
            DotaObjectEditor Editor = OpenEditor<DotaObjectEditor>();
            if(!EditorWasOpen)
            {
                Editor.EditingObject = DotaObject;
                Editor.TabText = DotaObject.ClassName;
                Editor.Show(MainForm.PrimaryDockingPanel, DockState.Document);
            }         
            return Editor;
        }
    }
}
