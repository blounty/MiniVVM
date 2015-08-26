using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniVVM
{
    public static class Engine
    {
        public static void Minify(Assembly[] assemblies)
        {
            ViewRegister.RegisterAssemblies(assemblies);
        }


    }
}
