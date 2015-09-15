using System;

using Xamarin.Forms;

namespace MiniSample.Views
{
    public class ViewTwo : ContentPage
    {
        public ViewTwo()
        {
            var button = new Button{
                Text="Take Picture"
            };

            button.SetBinding(Button.CommandProperty, new Binding("GetImageCommand"));
            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, new Binding("UsersName"));
            Content = new StackLayout
            { 
                Children =
                {
                    new Label { Text = "Hello" },
                    nameLabel,
                    button
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}


