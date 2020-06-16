using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WeatherApp.ViewModels;
using WeatherApp.Views;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {            
            InitializeComponent();           
            MainFrame.Content = new MainPage();
            App.MainFrame = MainFrame;
        }
    }
}
