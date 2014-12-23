using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.DataClasses;
using WorldSmith.Panels;

namespace WorldSmith.Documents
{
    public class DotaObjectDocument : VirtualTextDocument
    {
        public readonly DotaDataObject DotaObject;

        public DotaObjectDocument(DotaDataObject RootObject)
            : base()
        {
            DotaObject = RootObject;
                       
            Source = DotaObject.ObjectInfo.FromVPK ? DocumentSource.VPK : DocumentSource.File;
            Path = DotaObject.ObjectInfo.OriginatingFile;

            Name = RootObject.ClassName;
        }

        protected override string GetDocumentText()
        {
            return DotaObject.KeyValue.ToString();
        }

        protected override void DoSave(IEditor source)
        {
            
            if(source is TextEditor)
            {
                TextEditor textEd = source as TextEditor;
                //Commit these changes to the dota object.  
                KeyValue kv = KVParser.KV1.Parse(textEd.TextContent);

                DotaObject.KeyValue = kv;
            }
            
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
                Editor.Show(MainForm.PrimaryDockingPanel, DigitalRune.Windows.Docking.DockState.Document);
            }         
            return Editor;
        }
    }
}
