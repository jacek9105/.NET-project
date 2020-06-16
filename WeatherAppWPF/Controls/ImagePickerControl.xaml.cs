using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeatherApp.Controls
{
    /// <summary>
    /// Interaction logic for ImagePickerControl.xaml
    /// </summary>
    public partial class ImagePickerControl : UserControl
    {
        /// <summary>
        /// The image source property
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register(nameof(ImageSource), typeof(string), typeof(ImagePickerControl), null);

        /// <summary>
        /// The button pressed command property
        /// </summary>
        public static readonly DependencyProperty ButtonPressedCommandProperty =
        DependencyProperty.Register(nameof(ButtonPressedCommand), typeof(ICommand), typeof(ImagePickerControl), null);

        public ImagePickerControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        /// <value>
        /// The image source.
        /// </value>
        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the button pressed command.
        /// </summary>
        /// <value>
        /// The button pressed command.
        /// </value>
        public ICommand ButtonPressedCommand
        {
            get => (ICommand)GetValue(ButtonPressedCommandProperty); 
            set { SetValue(ButtonPressedCommandProperty, value); }
        }
    }
}
