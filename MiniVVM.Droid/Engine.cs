using System;

namespace MiniVVM
{
    public static class Engine
    {
        public static void Minify()
        {
            ViewRegister.RegisterAssemblies(AppDomain.CurrentDomain.GetAssemblies ());
        }
    }

}

