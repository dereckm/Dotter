using System.Text;
using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class SubGraphCompiler : BaseCompiler, ICompiler<SubGraph>
    {
        public SubGraphCompiler(int depth) : base(depth)
        {
            _styleCompiler = new StyleCompiler(depth + 1);
            _colorCompiler = new ColorCompiler(depth + 1);
            _nodesCompiler = new NodeCollectionCompiler(depth + 1);
            _labelCompiler = new LabelCompiler(depth + 1);
        }

        private readonly ICompiler<Style> _styleCompiler;
        private readonly ICompiler<Color> _colorCompiler;
        private readonly ICompiler<NodeCollection> _nodesCompiler;
        private readonly ICompiler<Label> _labelCompiler;

        public void Compile(SubGraph obj, ContentBuilder contentBuilder)
        {
            contentBuilder.Add($"subgraph {obj.Name} {{", Depth);

            if (obj.Style != null)
            {
                _styleCompiler.Compile(obj.Style, contentBuilder);
            }

            if (obj.Color != null)
            {
                _colorCompiler.Compile(obj.Color, contentBuilder); 
            }

            if (obj.Nodes != null)
            {
                _nodesCompiler.Compile(obj.Nodes, contentBuilder);
            }

            if (obj.Label != null)
            {
                _labelCompiler.Compile(obj.Label, contentBuilder);
            }

            contentBuilder.Add("}", Depth);
        }
    }
}