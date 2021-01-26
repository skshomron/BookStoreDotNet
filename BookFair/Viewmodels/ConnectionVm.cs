using BookFair.BookFairService;
using BookFair.Commands;
using System;
using System.Windows.Input;

namespace BookFair.Viewmodels
{
    public class EventArgs<T> : EventArgs
    {
        public T Param { get; }
        public EventArgs(T param)
        {
            Param = param;
        }
    }
    public delegate void ConnectionChangedDelegate(object sender, EventArgs<bool> e  ); 
    public class ConnectionVm: ViewModelBase
    {
        public event ConnectionChangedDelegate ConnectionChanged;
        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    RaisePropertyChanged(nameof(IsConnected));
                    
                    ConnectionChanged?.Invoke(this, new EventArgs<bool>(value));
                }
            }
        }

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

        private string _password = "phenix_6";
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
        private async void ConnectCmdExecute(object obj)
        {
            var client = new ServiceClient();
            IsConnected = await client.ConnectAsync(Login, Password);
            
        }
        private bool ConnectCmdCanExecute(object obj)
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

    }
}
