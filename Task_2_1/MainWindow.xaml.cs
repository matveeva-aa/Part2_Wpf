using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Task_2_1
{
    public partial class MainWindow : Window
    {
        private string? _currentFilePath;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                _currentFilePath = dlg.FileName;
                Editor.Text = File.ReadAllText(_currentFilePath);
                StatusText.Text = $"Открыт файл: {_currentFilePath}";
                Title = $"Простой текстовый редактор — {System.IO.Path.GetFileName(_currentFilePath)}";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                var sdlg = new SaveFileDialog
                {
                    Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                    FileName = "Документ.txt"
                };
                if (sdlg.ShowDialog() == true)
                {
                    _currentFilePath = sdlg.FileName;
                }
                else
                {
                    return;
                }
            }

            File.WriteAllText(_currentFilePath, Editor.Text);
            StatusText.Text = $"Файл сохранён: {_currentFilePath}";
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AboutWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            wnd.ShowDialog();
        }

        private void Window_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Выйти из программы?", "Подтверждение",
                                         MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
