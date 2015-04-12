using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using System.Drawing.Drawing2D;

namespace WorldSmith.NodeGraph.Items
{
    class ExecuteNodeItem : NodeItem
    {
        public string Text
        {
            get;
            set;
        }
        public override Color MainColor
        {
            get
            {
                return Color.White;
            }
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
            StringFormat format = this.ItemType == NodeItemType.Input ? GraphConstants.LeftTextStringFormat : GraphConstants.RightTextStringFormat;
            var stringSize = context.MeasureString(this.Text, SystemFonts.MenuFont, new SizeF(GraphConstants.MinimumItemWidth, GraphConstants.MinimumItemHeight), format);

            return stringSize;
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
            using (var path = new GraphicsPath(FillMode.Winding))
            {
                path.AddLine(PinBounds.Left, PinBounds.Top, PinBounds.X + PinBounds.Width / 2, PinBounds.Top);
                path.AddLine(PinBounds.X + PinBounds.Width / 2, PinBounds.Top, PinBounds.Right, PinBounds.Top + PinBounds.Height / 2);
                path.AddLine(PinBounds.Right, PinBounds.Top + PinBounds.Height / 2, PinBounds.X + PinBounds.Width / 2, PinBounds.Bottom);
                path.AddLine(PinBounds.X + PinBounds.Width / 2, PinBounds.Bottom, PinBounds.Left, PinBounds.Bottom);
                path.AddLine(PinBounds.Left, PinBounds.Bottom, PinBounds.Left, PinBounds.Top);

                path.CloseFigure();

                graphics.DrawPath(Pens.White, path);
                if (Connector.HasConnection) graphics.FillPath(Brushes.White, path);

            }               
        }

    }
}
