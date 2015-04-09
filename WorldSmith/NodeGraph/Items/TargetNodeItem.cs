using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WorldSmith.NodeGraph.Items
{
    class TargetNodeItem : NodeItem
    {
        public string Text
        {
            get;
            set;
        }

        public TargetNodeItem(string text, NodeItemType type)
            : base(type)
        {
            Text = text;
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

        public override SizeF MeasureContent(Graphics context)
        {
            var stringSize = context.MeasureString(this.Text, SystemFonts.MenuFont, GraphConstants.MinimumItemWidth);

            return stringSize;
        }

        public override void RenderPin(Graphics graphics)
        {

            if (Connector.HasConnection)
            {
                graphics.FillEllipse(Brushes.Indigo, PinBounds);
            }
            else
            {
                graphics.DrawEllipse(Pens.Indigo, PinBounds);               
            }
            float CenterX = PinBounds.X + PinBounds.Width / 2;
            graphics.DrawLine(Pens.BlueViolet, CenterX, PinBounds.Top, CenterX, PinBounds.Bottom);

            float CenterY = PinBounds.Y + PinBounds.Height / 2;
            graphics.DrawLine(Pens.BlueViolet, PinBounds.Left, CenterY, PinBounds.Right, CenterY);


        }
    }
}
