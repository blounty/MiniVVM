using System;
using System.Reflection;
using System.Linq;
using System.Diagnostics;


namespace MiniVVM
{
    public static class Engine
    {
        public static void Ignite()
        {
            Registrar.RegisterAll(AppDomain.CurrentDomain.GetAssemblies ());
        }


    }
}

