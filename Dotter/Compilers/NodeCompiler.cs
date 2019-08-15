using System.Text;
using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class NodeCompiler : BaseCompiler, ICompiler<Node>
    {
        public NodeCompiler(int depth) : base(depth)
        {
        }

        public void Compile(Node obj, ContentBuilder contentBuilder)
        {
            var content = new StringBuilder();

            content.Append($"{obj.Name}");

            if (obj.Shape != null)
            {
                content.Append(" [");
                content.Append($"shape={obj.Shape.Name};");
                content.Append("]");
            }

            content.Append(";");

            contentBuilder.Add(content.ToString(), Depth);
        }
    }
}