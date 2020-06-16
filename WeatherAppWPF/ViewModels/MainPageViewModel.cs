using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Navigation;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        private ICommand _navigateSettingsCommand;
        private ICommand _navigateWeatherCommand;
        private ICommand _pickImageCommand;
        private string _imageSource;
        private bool _canExecute;  
        private NavigationService _navigation;
        
      
        public MainPageViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _canExecute = true;
            ImageSource = @"C:\img.png";
        }

    
        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                RaisePropertyChanged(nameof(ImageSource));
            }
        }

      
        public ICommand NavigateWeatherCommand => _navigateWeatherCommand ?? (_navigateWeatherCommand = new CommandHandler(() => NavigateWeather(), _canExecute));

        public ICommand NavigateSettingsCommand => _navigateSettingsCommand ?? (_navigateSettingsCommand = new CommandHandler(() => NavigateSettings(), _canExecute));


   
        public ICommand PickImageCommand
        {
            get
            {
                return _pickImageCommand ?? (_pickImageCommand = new CommandHandler(() => OpenFileDialog(), _canExecute));
            }
        }

        private void NavigateWeather()
        {
            App.MainFrame.NavigationService.Navigate(new WeatherPage());
        }

        private void NavigateSettings()
        {
            App.MainFrame.NavigationService.Navigate(new SettingsPage());
        }

      
        public void OpenFileDialog()
        {
            _canExecute = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageSource = openFileDialog.FileName;
            }
            _canExecute = true;
        }
    }
}
