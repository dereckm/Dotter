namespace Dotter.Objects
{
    public class SubGraph
    {
        public string Name { get; set; }
        public Label Label { get; set; }
        public Color Color { get; set; }
        public Style Style { get; set; }
        public NodeCollection Nodes { get; set; }
    }
}