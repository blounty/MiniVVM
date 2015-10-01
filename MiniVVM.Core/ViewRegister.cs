using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace MiniVVM
{
    static class ViewRegister
    {
        private static List<ExportedView> exportedViews = new List<ExportedView>();

        public static List<ExportedView> ExportedViews
        {
            get
            {
                return exportedViews;
            }
        }

        internal static List<ExportedView> GetViewsByViewModel<TViewModel>() where TViewModel : ViewModel
        {
            return ExportedViews.Where(x => x.ViewModelType == typeof(TViewModel)).ToList();
        }

    }
}

