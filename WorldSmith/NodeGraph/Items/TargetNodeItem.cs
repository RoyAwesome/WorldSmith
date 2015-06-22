using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using WorldSmith.DataClasses;

namespace WorldSmith.NodeGraph.Items
{
    public class TargetNodeItem : NodeItem
    {
        public string Text
        {
            get;
            set;
        }

        public TargetKey Target
        {
            get;
            set;
        }
        public override Color MainColor
        {
            get
            {
                return Color.Indigo;
            }
        }
        public TargetNodeItem(string text, NodeItemType type)
            : base(type)
        {
            Text = text;
        }

        public TargetNodeItem(TargetKey target)
            : base(NodeItemType.Output)
        {
            Text = target.Preset;
            Target = target;
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
            StringFormat format = this.ItemType == NodeItemType.Input ? GraphConstants.LeftTextStringFormat : GraphConstants.RightTextStringFormat;
            var stringSize = context.MeasureString(this.Text, SystemFonts.MenuFont, new SizeF(GraphConstants.MinimumItemWidth, GraphConstants.MinimumItemHeight), format);

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
