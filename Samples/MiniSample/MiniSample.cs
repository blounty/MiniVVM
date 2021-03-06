﻿using System;

using Xamarin.Forms;
using MiniSample.Views;
using MiniSample.ViewModels;
using MiniVVM;

namespace MiniSample
{
    public class App : Application
    {
        public App()
        {

            ViewFactory.Current.RegisterView<ViewOneViewModel, ViewOne>();
            ViewFactory.Current.RegisterView<ViewTwoViewModel, ViewTwo>();

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

