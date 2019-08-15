using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class ColorCompiler : BaseCompiler, ICompiler<Color>
    {
        public ColorCompiler(int depth) : base(depth)
        {
        }

        public void Compile(Color obj, ContentBuilder contentBuilder)
        {
            contentBuilder.Add($"color={obj.Name};", Depth);
        }
    }
}