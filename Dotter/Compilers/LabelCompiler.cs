using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter.Compilers
{
    public class LabelCompiler : BaseCompiler, ICompiler<Label>
    {
        public LabelCompiler(int depth) : base(depth)
        {
        }

        public void Compile(Label obj, ContentBuilder contentBuilder)
        {
            contentBuilder.Add($"label = \"{obj.Text}\";", Depth);
        }
    }
}