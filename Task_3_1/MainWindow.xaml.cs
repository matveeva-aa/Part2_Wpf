using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Task_3_1
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем согласие
            if (ConsentCheck.IsChecked != true)
            {
                MessageBox.Show("Необходимо согласие на обработку данных!", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var name = (NameBox.Text ?? "").Trim();
            var faculty = (FacultyBox.Text ?? "").Trim();

            // Получаем выбранные курсы
            var courses = CoursesList.SelectedItems
                                     .Cast<ListBoxItem>()
                                     .Select(li => li.Content?.ToString())
                                     .Where(s => !string.IsNullOrWhiteSpace(s))
                                     .ToArray();

            var mode = RbFull.IsChecked == true ? "очно" : "заочно";
            var hours = (int)Hours.Value;

            var msg = new StringBuilder()
                .AppendLine("Данные отправлены")
                .AppendLine()
                .AppendLine($"Студент: {name}")
                .AppendLine($"Факультет: {faculty}")
                .AppendLine($"Курсы: {(courses.Length > 0 ? string.Join(", ", courses) : "не выбрано")}")
                .AppendLine($"Форма: {mode}")
                .AppendLine($"Нагрузка: {hours} ч./нед.")
                .ToString();

            MessageBox.Show(msg, "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}