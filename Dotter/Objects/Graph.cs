using System.Collections.Generic;

namespace Dotter.Objects
{
    public class Graph
    {
        public string Name { get; set; }
        public bool IsDirected { get; set; }
        public List<SubGraph> SubGraphs { get; set; } = new List<SubGraph>();
        public NodeCollection NodeCollection { get; set; } = new NodeCollection();
    }
}