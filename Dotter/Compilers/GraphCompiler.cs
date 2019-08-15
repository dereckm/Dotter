using System.Text;
using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class GraphCompiler : BaseCompiler, ICompiler<Graph>
    {
        private readonly ICompiler<NodeCollection> _nodesCompiler;
        private readonly ICompiler<SubGraph> _subGraphCompiler;

        public GraphCompiler() : base(0)
        {
            _nodesCompiler = new NodeCollectionCompiler(Depth);
            _subGraphCompiler = new SubGraphCompiler(Depth + 1);
        }

        public void Compile(Graph obj, ContentBuilder contentBuilder)
        {
            var content = new StringBuilder();
            if (obj.IsDirected)
            {
                content.Append("di");
            }
            content.Append($"graph {obj.Name} {{");

            contentBuilder.Add(content.ToString(), Depth);

            foreach (var subGraph in obj.SubGraphs)
            {
                _subGraphCompiler.Compile(subGraph, contentBuilder);
            }

            _nodesCompiler.Compile(obj.NodeCollection, contentBuilder);

            contentBuilder.Add("}", Depth);
        }
    }
}