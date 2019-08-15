using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class ArrowCompiler : BaseCompiler, ICompiler<Arrow>
    {
        public ArrowCompiler(int depth) : base(depth)
        {
        }

        public void Compile(Arrow obj, ContentBuilder contentBuilder)
        {
            contentBuilder.Add($"{obj.Origin.Name} -> {obj.Destination.Name}", Depth);
        }
    }
}