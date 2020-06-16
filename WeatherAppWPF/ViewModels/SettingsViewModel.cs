using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    class SettingsViewModel:BaseViewModel
    {
        private ICommand _navigateMenuCommand;
        private ICommand _saveSettingsCommand;
        private ICommand _loadSettingsCommand;
        private string _city;
        private string _continent;
        private string _country;

       
        public SettingsViewModel()
        {
            City = App.City;
            Country = App.Country;
            Continent = App.Continent;
        }

     
       
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                App.Country = value;
                RaisePropertyChanged(nameof(Country));
            }
        }

        public string Continent
        {
            get => _continent;
            set
            {
                _continent = value;
                App.Continent = value;
                RaisePropertyChanged(nameof(Continent));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                App.City = value;
                RaisePropertyChanged(nameof(City));
            }
        }

       
        public ICommand SaveSettingsCommand => _saveSettingsCommand ?? (_saveSettingsCommand = new CommandHandler( () => SaveSettings(), true));

   
        public ICommand LoadSettingsCommand => _loadSettingsCommand ?? (_loadSettingsCommand = new CommandHandler(() => LoadSettings(), true));

       
        public ICommand NavigateMenuCommand => _navigateMenuCommand ?? (_navigateMenuCommand = new CommandHandler(() => NavigateMenu(), true));

        private void SaveSettings()
        {
            var settingModel = new SettingModel()
            {
                City = this.City,
                Continent = this.Continent,
                Country = this.Country
            };

            var serializedObject = JsonConvert.SerializeObject(settingModel);

            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Txt files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                File.WriteAllText(fileName, serializedObject);
                MessageBox.Show("Zapisano pomyślnie");
                return;
            }

            MessageBox.Show("Błąd zapisu");
        }

        private void LoadSettings()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                var json = File.ReadAllText(fileName);
                try
                {
                    var settings = JsonConvert.DeserializeObject<SettingModel>(json);
                    City = settings.City;
                    Continent = settings.Continent;
                    Country = settings.Country;
                    MessageBox.Show("Wczytano pomyślnie");
                }
                catch
                {
                    MessageBox.Show("Błąd odczytu!");
                }
            }
        }

        private void NavigateMenu()
        {
            App.MainFrame.Navigate(new MainPage());         
        }
    }
}
