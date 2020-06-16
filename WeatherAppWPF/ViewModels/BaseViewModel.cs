using System.ComponentModel;

namespace WeatherApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
