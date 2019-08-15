using Dotter.Compilers.Contents;

namespace Dotter.Compilers
{
    public interface ICompiler<in T>
    {
        void Compile(T obj, ContentBuilder contentBuilder);
    }
}