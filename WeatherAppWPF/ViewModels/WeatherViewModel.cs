using QuickType;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel:BaseViewModel
    {
        private NavigationService _nav;
        private string _city;
        private string _tempMin;
        private string _tempMax;
        private ICommand _navigateSettingsCommand;
        private ICommand _navigateMenuCommand;

       
        public WeatherViewModel(NavigationService nav)
        {
            _nav = nav;
            Initialize();
        }


        public ICommand NavigateSettingsCommand => _navigateSettingsCommand ?? (_navigateSettingsCommand = new CommandHandler(() => NavigateSettings(), true));

  
        public ICommand NavigateMenuCommand => _navigateMenuCommand ?? (_navigateMenuCommand = new CommandHandler(() => NavigateMenu(), true));

  
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged(nameof(City));
            }
        }

     
        public string TempMin
        {
            get => _tempMin;
            set
            {
                _tempMin = value;
                RaisePropertyChanged(nameof(TempMin));
            }
        }

        public string TempMax
        {
            get => _tempMax;
            set
            {
                _tempMax = value;
                RaisePropertyChanged(nameof(TempMax));
            }
        }      

      
        public async Task<WeatherModel> GetWeatherModel()
        {

            using (var client = new HttpClient())
            {
                try
                {

                    HttpResponseMessage httpResponse = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={App.City}&mode=json&units=metric&APPID=9f468df31a5f889ef8a48eb29638606c");
                    var obtainedResponse = await httpResponse.Content?.ReadAsStringAsync();

                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    var weatherModel = WeatherModel.FromJson(obtainedResponse);

                    if (weatherModel != null)
                    {
                        return weatherModel;
                    }
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        private void NavigateSettings()
        {
            App.MainFrame.NavigationService.Navigate(new SettingsPage());
        }
        private void NavigateMenu()
        {
            App.MainFrame.Navigate(new MainPage());
        }

        private async void Initialize()
        {
            var weatherModel = await GetWeatherModel();

            if (weatherModel != null)
            {
                City = $"{App.City},{weatherModel.Sys.Country}";
                TempMax = weatherModel.Main.TempMax.ToString();
                TempMin = weatherModel.Main.TempMin.ToString();
            }
            else
            {
                MessageBox.Show($"Nie znaleziono prognozy dla miasta: {App.City}. Sprawdź miasto wprowadzone w ustawieniach.");
            }
        }

    }    
}
