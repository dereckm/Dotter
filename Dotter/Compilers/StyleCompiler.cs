using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class StyleCompiler : BaseCompiler, ICompiler<Style>
    {
        public StyleCompiler(int depth) : base(depth)
        {
        }

        public void Compile(Style obj, ContentBuilder contentBuilder)
        {
            contentBuilder.Add($"style={obj.Name};", Depth);
        }
    }
}