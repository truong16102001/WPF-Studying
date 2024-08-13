using System.Windows;
using System.Windows.Media;


namespace ResourceStyles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["customButton"] = new SolidColorBrush(Colors.Black);
        }

        private void DynamicButton_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["ButtonBackgroundBrush"] = new SolidColorBrush(Colors.Blue);
        }
    }
}