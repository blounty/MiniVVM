using MiniVVM;

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
    }
}

