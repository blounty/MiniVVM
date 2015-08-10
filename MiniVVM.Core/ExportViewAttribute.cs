using System;
using Xamarin.Forms;

namespace MiniVVM
{
    [AttributeUsage (AttributeTargets.Assembly, AllowMultiple = true)]
    public class ExportViewAttribute : Attribute
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

        public ExportViewAttribute(Type viewType, Type viewModelType, TargetIdiom targetIdom)
        {
            this.TargetIdom = targetIdom;
            this.ViewModelType = viewModelType;
            this.ViewType = viewType;
        }
    }
}

