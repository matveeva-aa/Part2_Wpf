using System;
using System.Windows;
using System.Windows.Controls;

namespace Task_1_3
{
        public partial class MainWindow : Window
    {
        private readonly Random _rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => CenterButton();
        }
        private void CenterButton()
        {
            double x = (Playground.ActualWidth - RunButton.Width) / 2;
            double y = (Playground.ActualHeight - RunButton.Height) / 2;

            Canvas.SetLeft(RunButton, x);
            Canvas.SetTop(RunButton, y);
        }

        private void RunButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MoveButtonRandom();
        }

        private void MoveButtonRandom()
        {
            double maxX = Playground.ActualWidth - RunButton.Width;
            double maxY = Playground.ActualHeight - RunButton.Height;

            if (maxX <= 0 || maxY <= 0) return;

            double x = _rng.NextDouble() * maxX;
            double y = _rng.NextDouble() * maxY;

            Canvas.SetLeft(RunButton, x);
            Canvas.SetTop(RunButton, y);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}