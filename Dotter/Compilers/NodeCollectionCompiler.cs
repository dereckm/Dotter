using System.Text;
using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class NodeCollectionCompiler : BaseCompiler, ICompiler<NodeCollection>
    {
        private readonly ICompiler<Arrow> _arrowCompiler;
        private readonly ICompiler<Node> _nodeCompiler;

        public NodeCollectionCompiler(int depth) : base(depth)
        {
            _arrowCompiler = new ArrowCompiler(depth + 1);
            _nodeCompiler = new NodeCompiler(depth + 1);
        }

        public void Compile(NodeCollection obj, ContentBuilder contentBuilder)
        {
            var content = new StringBuilder();

            if (obj.Style != null || obj.Color != null)
            {
                content.Append($"node [");

                if (obj.Style != null)
                {
                    content.Append($"style={obj.Style.Name}");
                }

                if (obj.Style != null & obj.Color != null)
                {
                    content.Append(", ");
                }

                if (obj.Color != null)
                {
                    content.Append($"color={obj.Color.Name}");
                }

                content.Append("];");
            }

            contentBuilder.Add(content.ToString(), Depth);

            foreach (var node in obj.Nodes)
            {
                _nodeCompiler.Compile(node, contentBuilder);
            }

            foreach (var arrow in obj.Arrows)
            {
                _arrowCompiler.Compile(arrow, contentBuilder);
            }
        }
    }
}