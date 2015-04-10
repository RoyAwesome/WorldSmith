using KVLib;
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

            if (source is TextEditor)
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
            if (DotaObject is DotaAbility && EditorType == typeof(DotaAbilityEditor)) return true;
            if (EditorType == typeof(TextEditor) || EditorType == typeof(DotaObjectEditor)) return true;
            return false;
        }

        public override void OpenDefaultEditor()
        {
            if (DotaObject is DotaAbility) OpenAbilityEditor(); //If we are an Ability, open the Ability Editor
            else OpenObjectEditor();
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
            if (!EditorWasOpen)
            {
                Editor.EditingObject = DotaObject;
                Editor.TabText = DotaObject.ClassName;
                Editor.Show(MainForm.PrimaryDockingPanel, DockState.Document);
            }
            return Editor;
        }

        public DotaAbilityEditor OpenAbilityEditor()
        {
            bool EditorWasOpen = ContainsEditor<DotaAbilityEditor>();
            DotaAbilityEditor Editor = OpenEditor<DotaAbilityEditor>();
            if (!EditorWasOpen)
            {
                Editor.Ability = DotaObject as DotaAbility;
                Editor.TabText = DotaObject.ClassName;
                Editor.Show(MainForm.PrimaryDockingPanel, DockState.Document);
            }
            return Editor;
        }
    }
}
