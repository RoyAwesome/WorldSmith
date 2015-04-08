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

        public ExecuteNodeItem(string Name, bool input, bool output)
            : base(input, output)
        {
            Text = Name;
        }



        public override SizeF Measure(Graphics context)
        {
            return new SizeF(GraphConstants.MinimumItemWidth, GraphConstants.MinimumItemHeight);
        }

        public override void Render(Graphics graphics, SizeF minimumSize, PointF position)
        {
            var size = Measure(graphics);
            size.Width = Math.Max(minimumSize.Width, size.Width);
            size.Height = Math.Max(minimumSize.Height, size.Height);

            if (this.Input.Enabled != this.Output.Enabled)
            {
                graphics.DrawString(this.Text, SystemFonts.MenuFont, Brushes.Black, new RectangleF(position, size), GraphConstants.RightTextStringFormat);
            }
            else
            {
                graphics.DrawString(this.Text, SystemFonts.MenuFont, Brushes.Black, new RectangleF(position, size), GraphConstants.CenterTextStringFormat);
            }

               
        }
    }
}
