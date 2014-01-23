using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorldSmith
{

    public partial class LocaleManager : Component
    {

        //The control that will be managed
        private ContainerControl _parentControl = null;

        [
            PropertyTab("General"),
            DisplayName("Parent Control"),
            Description("The control that is managed")
        ]
        public ContainerControl ParentControl
        {
            get { return _parentControl; }
            set { _parentControl = value; }
        }

       

        private CultureInfo _currentCulture = null;



        public LocaleManager()
        {

        }


        public LocaleManager(IContainer container)
        {
            container.Add(this);   
            InitializeComponent();

        }


        public void updateCulture(String cultureName)
        {


            CultureInfo _newCulture = new CultureInfo(cultureName);
            
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            if(_currentCulture != _newCulture)
            {
                _currentCulture = _newCulture;
                if (_parentControl != null)
                {
                    Thread.CurrentThread.CurrentUICulture = _newCulture;

                    //Changes the resources (text) of all controls to the new locale
                    updateControls(resources, _parentControl);

                    //Applies the same changes to all menus
                    updateMenus(resources, _parentControl);
                }
            }

            
            
        }


        //Helps apply the locale change to everything in the form
        private void updateControls(ComponentResourceManager res, Control control)
        {

            foreach(Control child in control.Controls)
            {
                //Updates the child with the strings from the new locale
                res.ApplyResources(child, child.Name);

                updateControls(res, child);

            }

        }

        private void updateMenus(ComponentResourceManager res, Control control)
        {
            
            foreach (MenuStrip menuStrip in control.Controls.OfType<MenuStrip>())
            {
                foreach (ToolStripMenuItem menuStripItem in menuStrip.Items)
                {
                    res.ApplyResources(menuStripItem, menuStripItem.Name);
                }
                
                
              

            }

        }

        //Used to get the parent object
        public override ISite Site
        {
            get { return base.Site; }
            set
            {
                base.Site = value;
                if (value == null)
                {
                    return;
                }

                IDesignerHost host = value.GetService(
                    typeof(IDesignerHost)) as IDesignerHost;
                if (host != null)
                {
                    IComponent componentHost = host.RootComponent;
                    if (componentHost is ContainerControl)
                    {
                        ParentControl = componentHost as ContainerControl;
                        _parentControl = ParentControl;
                    }
                }
            }
        }
    }
}
