using System;

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

