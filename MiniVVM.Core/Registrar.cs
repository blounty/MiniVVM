using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace MiniVVM
{
    static class Registrar
    {
        private static List<ExportedView> exportedViews = new List<ExportedView>();

        public static List<ExportedView> ExportedViews
        {
            get
            {
                return exportedViews;
            }
        }

        internal static void RegisterAll (Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var attributes = assembly.GetCustomAttributes(typeof(ExportViewAttribute)).ToArray();
                if (attributes.Length == 0)
                    continue;
                foreach (ExportViewAttribute attribute in attributes)
                {
                    exportedViews.Add(new ExportedView(attribute.ViewType, attribute.ViewModelType, attribute.TargetIdiom));
                }
            }
        }

        internal static List<ExportedView> GetViewsByViewModel<TViewModel>() where TViewModel : ViewModel
        {
            return ExportedViews.Where(x => x.ViewModelType == typeof(TViewModel)).ToList();
        }

    }
}

