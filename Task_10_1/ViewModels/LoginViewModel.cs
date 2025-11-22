using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Task_10.Models;

namespace Task_10.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                if (_username == value) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _statusMessage = "Введите учетные данные";
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage == value) return;
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _isSuccess;
        public bool IsSuccess
        {
            get => _isSuccess;
            set
            {
                if (_isSuccess == value) return;
                _isSuccess = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(OnLoginExecute, CanLoginExecute);
        }

        private void OnLoginExecute(object? parameter)
        {
            bool ok = AuthModel.Authenticate(Username, Password);

            IsSuccess = ok;
            StatusMessage = ok
                ? "Успешный вход! Добро пожаловать!"
                : "Введены неверные учетные данные";
        }

        private bool CanLoginExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Username)
                   && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
