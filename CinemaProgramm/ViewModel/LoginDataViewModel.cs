using BLL.Service;
using CinemaProgramm.Infrastructure;
using DLL.Model;
using System.Windows;
using System.Windows.Input;

namespace CinemaProgramm.ViewModel
{
    public class LoginDataViewModel : BaseViewModel
    {
        private readonly LoginService _service;
        private readonly Employee _employee;
        private LoginData _authorizationData;

        public LoginData AuthorizationData
        {
            get { return _authorizationData; }
            set 
            { 
                _authorizationData = value; 
                OnPropertyChanged(nameof(AuthorizationData));
            }
        }

        public LoginDataViewModel(LoginService loginService, Employee emp, LoginData log)
        {
            _service = loginService;
            _employee = emp;
            _authorizationData = log;
        }

        RelayCommand _checkLogDataCommand;
        public ICommand CheckLogDataCommand
        {
            get
            {
                if (_checkLogDataCommand == null)
                    _checkLogDataCommand = new RelayCommand(EcexuteCheckPersonCommand, CanExecuteCheckLoginCommand);
                return _checkLogDataCommand;
            }
        }

        private async void EcexuteCheckPersonCommand(object? obj)
        {
            var employee = await _service.AutorizationAsync(AuthorizationData);
            if (employee == null)
            {
                MessageBox.Show("Not found! Try again!");
                return;
            }
            
            _employee.Birthday = employee.Birthday;
            _employee.LoginDataID = employee.LoginDataID;
            _employee.Name = employee.Name;
            _employee.Surname = employee.Surname;
            _employee.Role = employee.Role;
            _employee.Salary = employee.Salary;
            _employee.StartWork = employee.StartWork;
            _employee.Tickets = employee.Tickets;

            if (_employee.Role == "Admin")
            {
                //
            }
            else if (_employee.Role == "Employee")
            {
                //
            }
        }

        private bool CanExecuteCheckLoginCommand(object? obj) =>
            (string.IsNullOrEmpty(AuthorizationData.Login) || string.IsNullOrEmpty(AuthorizationData.Password)) ? false : true;
    }
}
