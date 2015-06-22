using Graph;
using Graph.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSmith.NodeGraph.Items
{
    public class NumberValueItem : NodeNumericSliderItem
    {
        public NumberValueItem(string text, float sliderSize, float textSize, float minValue, float maxValue, float defaultValue, NodeItemType type)
            : base(text, sliderSize, textSize, minValue, maxValue, defaultValue, type)
        {

        }

        public NumberValueItem(string text, NodeItemType type)
            : base(text, 0, 0, 0, 0, 0, type)
        {

        }

        public override void RenderContent(Graphics graphics)
        {
            if (ItemType == NodeItemType.Input)
            {
                base.RenderContent(graphics);
                return;
            }

            RenderAsLabel(graphics, Text);
        }

        public override SizeF MeasureContent(Graphics graphics)
        {
            if (ItemType == NodeItemType.Input)
            {
                return base.MeasureContent(graphics);
            }

            return MeasureAsLabel(graphics, Text);
        }
    }
}
