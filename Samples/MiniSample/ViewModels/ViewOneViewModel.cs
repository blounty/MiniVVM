using System;
using MiniVVM;
using Xamarin.Forms;
using System.Collections.Generic;

namespace MiniSample.ViewModels
{
    public class ViewOneViewModel
    : ViewModel
    {

        string usersName;
        public string UsersName
        {
            get
            {
                return usersName;
            }
            set
            {
                RaiseAndUpdate(ref usersName, value);
                NavigateTo2Command.ChangeCanExecute();
            }
        }

        Command navigateTo2Command;
        public Command NavigateTo2Command
        {
            get
            {
                return navigateTo2Command;
            }
            set
            {
                RaiseAndUpdate(ref navigateTo2Command, value);
            }
        }

        public ViewOneViewModel()
        {
            NavigateTo2Command = new Command(NavigateTo2, () => !string.IsNullOrEmpty(UsersName));
        }

        void NavigateTo2()
        {
            Navigation.PushAsync(ViewFactory.Current.ResolveView<ViewTwoViewModel>(new Dictionary<string, object>{{"UsersName", UsersName}}));
        }
    }
}

