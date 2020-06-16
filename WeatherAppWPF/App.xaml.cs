using System.Windows;
using System.Windows.Controls;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Continent { get; set; }
        public static string Country { get; set; }
        public static string City { get; set; }
        public static Frame MainFrame { get; set; }
    }
}
