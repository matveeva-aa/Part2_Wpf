using System.Windows;

namespace Part2_Wpf
{
    public partial class MainWindow : Window
    {
        private int _count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            CounterText.Text = _count.ToString();
        }
    }
}