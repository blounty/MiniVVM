using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MiniVVM
{
    public class ViewFactory
    {

        static Lazy<ViewFactory> current =
            new Lazy<ViewFactory>(() => new ViewFactory(), true);

        Dictionary<Type, Type> viewMappings = new Dictionary<Type, Type>();

        public static ViewFactory Current
        {
            get
            {
                return current.Value;
            }
        }

        internal void RegisterView<TViewModel, TView>() 
            where TViewModel : ViewModel 
            where TView : VisualElement
        {
            viewMappings.Add(typeof(TViewModel), typeof(TView));
        }

        public ContentPage ResolveView<TViewModel>(Dictionary<string, object> data = null) where TViewModel : ViewModel
        {
            var views = Registrar.GetViewsByViewModel<TViewModel>();

            ExportedView exportedView = views.Any(v => v.TargetIdom == Device.Idiom) 
                ? views.Single(v => v.TargetIdom == Device.Idiom) 
                : views.Single(v => v.TargetIdom == TargetIdiom.Phone);


            ContentPage view = Activator.CreateInstance(exportedView.ViewType) as ContentPage;
            ViewModel viewModel = Activator.CreateInstance(exportedView.ViewModelType) as ViewModel;             

            EventHandler appearingAction = (sender, e) => 
                {
                    view.BindingContext = viewModel;
                };

            EventHandler disappearingAction = (sender, e) => 
                {
                    view.BindingContext = null;
                };
            
            view.Appearing += appearingAction;
            view.Disappearing += disappearingAction;


            viewModel.Navigation = view.Navigation;
            view.BindingContext = viewModel;

            if(data != null)
                PopulateViewModel(viewModel, data);

            viewModel.Init(data);
            return view;
        }

        void PopulateViewModel(ViewModel viewModel, Dictionary<string, object> data)
        {
            var viewModelType = viewModel.GetType();

            var properties = viewModelType.GetRuntimeProperties().ToList();

            foreach (var key in data.Keys)
            {
                var property = properties.FirstOrDefault(x => x.Name == key);
                if (property == null)
                    continue;

                var val = data[key];
                if (property.PropertyType == val.GetType())
                {
                    property.SetValue(viewModel, val);
                }
            }

        }
    }
}

