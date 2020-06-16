using System.Windows.Controls;
using System.Windows.Navigation;
using WeatherApp.ViewModels;

namespace WeatherApp.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private SettingsViewModel _vm;
        public SettingsPage()
        {            
            InitializeComponent();
            _vm = new SettingsViewModel();
            DataContext = _vm;
        }
    }
}
