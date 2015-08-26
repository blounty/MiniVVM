using System;

using Xamarin.Forms;

namespace MiniSample.Views
{
    public class ViewTwo : ContentPage
    {
        public ViewTwo()
        {
            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, new Binding("UsersName"));
            Content = new StackLayout
            { 
                Children =
                {
                    new Label { Text = "Hello" },
                    nameLabel
                }
            };
        }
    }
}


