# MiniVVM

## Define your views

<pre><code>
  [assembly:MiniVVM.ExportView(typeof(ViewOne), typeof(ViewOneViewModel))]
  [assembly:MiniVVM.ExportView(typeof(ViewTwo), typeof(ViewTwoViewModel))]
  
  [assembly:MiniVVM.ExportView(typeof(ViewTwoTablet), typeof(ViewTwoViewModel), TargetIdiom.Tablet)]
</code></pre>

## Initialize on each platform

<pre><code>
protected override void OnCreate(Bundle bundle)
{
    base.OnCreate(bundle);

    global::Xamarin.Forms.Forms.Init(this, bundle);
    global::MiniVVM.Engine.Minify();
    LoadApplication(new App());
}
</code></pre>

## Initialize your app

<pre><code>
public App()
  {
    // The root page of your application
    MainPage = new NavigationPage(ViewFactory.Current.ResolveView<ViewOneViewModel>());
  }
</code></pre>

## Setup your ViewModels

<pre><code>
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
    
</code></pre>

## Passing data between ViewModels

When calling ResolveView and passing a dictionary of data we will automatically match up the keys to properties on the requested ViewModel and set the properties for you.

<pre><code>
ViewFactory.Current.ResolveView<ViewTwoViewModel>(new Dictionary<string, object>{{"UsersName", UsersName}});
</code></pre>
