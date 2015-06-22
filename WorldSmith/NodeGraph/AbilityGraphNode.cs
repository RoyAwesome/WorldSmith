using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.NodeGraph.Items;

namespace WorldSmith.NodeGraph
{
    public abstract class AbilityGraphNode : Node
    {

        public ExecuteNodeItem OutputExecute
        {
            get;
            protected set;
        }

        public ExecuteNodeItem InputExecute
        {
            get;
            protected set;
        }

        public AbilityGraphNode(string Title)
            : base(Title)
        {

        }

    }
}
