using System;
using System.Collections.Generic;
using System.Text;

namespace Dotter.Compilers
{
    public class BaseCompiler
    {
        public BaseCompiler(int depth)
        {
            Depth = depth;
        }

        public int Depth { get; }
    }
}
