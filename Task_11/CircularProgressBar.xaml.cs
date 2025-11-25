using System.Windows;
using System.Windows.Controls;

namespace UserControlExample
{
    /// <summary>
    /// Логика взаимодействия для CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(100.0, OnValueChanged));

        // Read-only: Dependency Properties
        private static readonly DependencyPropertyKey PercentageTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(PercentageText),
                typeof(string),
                typeof(CircularProgressBar),
                new PropertyMetadata("0%"));

        public static readonly DependencyProperty PercentageTextProperty =
            PercentageTextPropertyKey.DependencyProperty;

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            private set => SetValue(PercentageTextPropertyKey, value);
        }

        private const double CenterX = 50.0;
        private const double CenterY = 50.0;
        private const double Radius = 45.0;
        private const double StartAngleDeg = -90.0;

        public CircularProgressBar()
        {
            InitializeComponent();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = (CircularProgressBar)d;
            progressBar.UpdateProgress();
        }

        private void UpdateProgress()
        {
            // Ограничиваем значения
            if (Maximum <= 0)
                Maximum = 100;

            if (Value < 0)
                Value = 0;

            if (Value > Maximum)
                Value = Maximum;

            // Вычисляем прогресс
            double percentage = Maximum == 0 ? 0 : Value / Maximum;

            PercentageText = $"{percentage * 100:F0}%";

            double angle = 360.0 * percentage;
            angle = Math.Max(0.0, Math.Min(359.999, angle));

            double endAngleDeg = StartAngleDeg + angle;
            double endAngleRad = endAngleDeg * Math.PI / 180.0;

            double x = CenterX + Radius * Math.Cos(endAngleRad);
            double y = CenterY + Radius * Math.Sin(endAngleRad);

            PART_Arc.Size = new Size(Radius, Radius);
            PART_Arc.Point = new Point(x, y);
            PART_Arc.IsLargeArc = angle > 180.0;
        }
    }
}
