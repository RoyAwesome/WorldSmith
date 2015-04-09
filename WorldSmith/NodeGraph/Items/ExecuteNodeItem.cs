using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace WorldSmith.NodeGraph.Items
{
    class ExecuteNodeItem : NodeItem
    {
        public string Text
        {
            get;
            set;
        }
        public ExecuteNodeItem(string name)
            : base()
        {
            Text = name;
        }

        public ExecuteNodeItem(string Name, NodeItemType type)
            : base(type)
        {
            Text = Name;
        }



        public override SizeF MeasureContent(Graphics context)
        {
            return new SizeF(GraphConstants.MinimumItemWidth, GraphConstants.MinimumItemHeight);
        }

        public override void RenderContent(Graphics graphics)
        {
           

            if (this.Input != null)
            {
                graphics.DrawString(this.Text, SystemFonts.MenuFont, Brushes.Black, ContentBounds, GraphConstants.LeftTextStringFormat);
            }
            else
            {
                graphics.DrawString(this.Text, SystemFonts.MenuFont, Brushes.Black, ContentBounds, GraphConstants.RightTextStringFormat);
            }
                       
               
        }

      
    }
}
