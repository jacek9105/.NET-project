using System.Windows.Controls;
using WeatherApp.ViewModels;

namespace WeatherApp.Views
{
    /// <summary>
    /// Interaction logic for WeatherPage.xaml
    /// </summary>
    public partial class WeatherPage : Page
    {
        private WeatherViewModel _vm;
        public WeatherPage()
        {
            InitializeComponent();
            _vm = new WeatherViewModel(NavigationService);
            DataContext = _vm;
        }
    }
}
