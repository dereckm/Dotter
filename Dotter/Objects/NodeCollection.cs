using System.Collections.Generic;

namespace Dotter.Objects
{
    public class NodeCollection
    {
        private readonly List<Node> _nodes = new List<Node>();
        private readonly List<Arrow> _arrows = new List<Arrow>();

        public void AddNodes(params Node[] nodes)
        {
            _nodes.AddRange(nodes);
        }

        public void AddArrows(params Arrow[] arrows)
        {
            _arrows.AddRange(arrows);
        }

        public IEnumerable<Node> Nodes => _nodes;
        public IEnumerable<Arrow> Arrows => _arrows;
        public Style Style { get; set; }
        public Color Color { get; set; } 
    }
}