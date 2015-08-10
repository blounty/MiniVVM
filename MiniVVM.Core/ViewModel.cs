using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;


namespace MiniVVM
{
    public class ViewModel 
        : INotifyPropertyChanged
    {
        public INavigation Navigation
        {
            get;
            set;
        }

        public virtual void Init(Dictionary<string, object> data = null)
        {
            
        }

        protected async Task Push<T>(Dictionary<string, object> data = null)
            where T : ViewModel
        {

            try
            {
                var view = ViewFactory.Current.ResolveView<T>();

                if(data != null){
                    ((ViewModel)view.BindingContext).Init(data);
                }
                await Navigation.PushAsync(view);
            }
            catch (Exception)
            {

            }
           
        }

        protected async Task Pop()
        {
            await Navigation.PopAsync();
        }

        List<KeyValuePair<string, List<Action>>> PropertyWatchers = new List<KeyValuePair<string, List<Action>>>();

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void RaiseAndUpdate<T>(ref T field, T value, [CallerMemberName] string propertyName = null){

            field = value;
            if(!string.IsNullOrEmpty(propertyName) && PropertyChanged != null){
                PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
            }

            var watchers = PropertyWatchers.FirstOrDefault(pw => pw.Key == propertyName);
            if (watchers.Equals(default(KeyValuePair<string, List<Action>>)))
                return;

            foreach (Action watcher in watchers.Value)
            {
                watcher();
            }
        }

        public void WatchProperty(string propertyName, Action action)
        {
            if (PropertyWatchers.All(pw => pw.Key != propertyName))
            {
                PropertyWatchers.Add(new KeyValuePair<string, List<Action>>(propertyName, new List<Action>()));
            }

            PropertyWatchers.First(pw => pw.Key == propertyName).Value.Add(action);
        }

        public void ClearWatchers()
        {
            PropertyWatchers.Clear();
        }

    }
}

