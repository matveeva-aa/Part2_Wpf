using System.Windows;
using System.Windows.Media;

namespace Task_1_2
{
    public partial class MainWindow : Window
    {
        private int _state = 0;
        public MainWindow()
        {
            InitializeComponent();
            UpdateLights();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _state = (_state + 1) % 3;
            UpdateLights();
        }

        private void UpdateLights()
        {
            // все серые
            RedLamp.Fill = Brushes.Gray;
            YellowLamp.Fill = Brushes.Gray;
            GreenLamp.Fill = Brushes.Gray;

            // включаем активный
            switch (_state)
            {
                case 0: RedLamp.Fill = Brushes.Red; break;
                case 1: YellowLamp.Fill = Brushes.Yellow; break;
                case 2: GreenLamp.Fill = Brushes.Green; break;
            }
        }
    }
}