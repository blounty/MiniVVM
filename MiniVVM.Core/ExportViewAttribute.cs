﻿using System;
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

        public TargetIdiom TargetIdiom
        {
            get;
            private set;
        }

        public ExportViewAttribute(Type viewType, Type viewModelType, TargetIdiom targetIdiom)
        {
            TargetIdiom = targetIdiom;
            ViewModelType = viewModelType;
            ViewType = viewType;
        }

        public ExportViewAttribute(Type viewType, Type viewModelType)
            : this(viewType, viewModelType, TargetIdiom.Phone)
        {
        }
    }
}

