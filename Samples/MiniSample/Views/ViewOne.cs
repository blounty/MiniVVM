using System;

using Xamarin.Forms;

namespace MiniSample.Views
{
    public class ViewOne : ContentPage
    {
        public ViewOne()
        {
            var entry = new Entry();
            entry.SetBinding(Entry.TextProperty, new Binding("UsersName", mode: BindingMode.OneWayToSource));

            var button = new Button();
            button.Text = "Go to View 2";
            button.SetBinding(Button.CommandProperty, new Binding("NavigateTo2Command"));


            Content = new StackLayout
            { 
                Children =
                {
                    new Label { Text = "Hello, enter your name:" },
                    entry,
                    button
                }
            };
        }
    }
}


