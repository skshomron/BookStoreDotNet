using BookFair.Commands;
using BookFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookFair.Viewmodels
{
    public class ConnectionVm:NotifiableObject
    {

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    RaisePropertyChanged(nameof(Login));
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged(nameof(Password));
                }
            }
        }

        private ICommand _connectCmd;
        public ICommand ConnectCmd => _connectCmd ?? (_connectCmd = new RelayCommand(ConnectCmdExecute, ConnectCmdCanExecute));
        private void ConnectCmdExecute(object obj)
        {
            
        }
        private bool ConnectCmdCanExecute(object obj)
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

    }
}
