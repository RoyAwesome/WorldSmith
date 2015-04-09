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
            if (this.ItemType == NodeItemType.Input)
            {
                graphics.DrawString(this.Text, SystemFonts.MenuFont, Node.TextColor, ContentBounds, GraphConstants.LeftTextStringFormat);
            }
            else
            {
                graphics.DrawString(this.Text, SystemFonts.MenuFont, Node.TextColor, ContentBounds, GraphConstants.RightTextStringFormat);
            } 
        }

        public override void RenderPin(Graphics graphics)
        {
            base.RenderPin(graphics);
        }


    }
}
