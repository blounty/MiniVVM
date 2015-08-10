using System;
using Xamarin.Forms;

namespace MiniVVM
{
    internal class ExportedView
    {
        public Type ViewType
        {
            get;
            private set;
        }

        public Type ViewModelType
        {
            get;
            private set;
        }

        public TargetIdiom TargetIdom
        {
            get;
            private set;
        }

        public ExportedView(Type viewType, Type viewModelType, TargetIdiom targetIdom)
        {
            this.TargetIdom = targetIdom;
            this.ViewModelType = viewModelType;
            this.ViewType = viewType;
        }
    }
}

