using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task_4_1
{
    public class ToggleButtonEx : Button
    {
        public static readonly DependencyProperty IsToggledProperty =
            DependencyProperty.Register(
                nameof(IsToggled),
                typeof(bool),
                typeof(ToggleButtonEx),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnIsToggledChanged));

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        public ToggleButtonEx()
        {
            UpdateVisual();

            Click += (_, __) => IsToggled = !IsToggled;
        }

        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleButtonEx)d).UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (IsToggled)
            {
                Content = "ON";
                Background = Brushes.Green;
                Foreground = Brushes.White;
                BorderBrush = Brushes.DarkGreen;
            }
            else
            {
                Content = "OFF";
                Background = Brushes.Red;
                Foreground = Brushes.White;
                BorderBrush = Brushes.DarkRed;
            }
        }
    }
}
