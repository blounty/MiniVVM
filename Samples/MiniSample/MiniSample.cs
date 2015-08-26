using System;

using Xamarin.Forms;
using MiniSample.Views;
using MiniSample.ViewModels;
using MiniVVM;

[assembly:MiniVVM.ExportView(typeof(ViewOne), typeof(ViewOneViewModel))]
[assembly:MiniVVM.ExportView(typeof(ViewTwo), typeof(ViewTwoViewModel))]


namespace MiniSample
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(ViewFactory.Current.ResolveView<ViewOneViewModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

