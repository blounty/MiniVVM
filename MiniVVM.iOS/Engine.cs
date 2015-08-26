using System;
using System.Reflection;
using System.Linq;
using System.Diagnostics;


namespace MiniVVM
{
    public static class Engine
    {
        public static void Minify()
        {
           
            ViewRegister.RegisterAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //ViewRegister.RegisterAssemblies(AppDomain.CurrentDomain.GetAssemblies ());
        }


    }
}

