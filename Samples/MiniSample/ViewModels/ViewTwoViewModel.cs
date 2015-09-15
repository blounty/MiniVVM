using MiniVVM;
using Xamarin.Forms;
using Media.Plugin;

namespace MiniSample.ViewModels
{
    public class ViewTwoViewModel
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
            }
        }

        public Command GetImageCommand {
            get;
            set;
        }

        public ViewTwoViewModel()
        {
            GetImageCommand = new Command(async _ => 
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        //hud.ShowError(":( No camera avaialble.");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Media.Plugin.Abstractions.StoreCameraMediaOptions
                        {

                            Directory = "Sample",
                            Name = "test.jpg"
                        });

                    if (file == null)
                        return;

                    //hud.Show(CurrentImageFile.Path);

                    /*
                    image.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });*/ 
                });
        }
    }
}

