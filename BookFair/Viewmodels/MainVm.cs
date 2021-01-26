using BookFair.Interfaces;
using BookFair.Models;
using System.Collections.ObjectModel;

namespace BookFair.Viewmodels
{
    public class MainVm : ViewModelBase
    {

        private IViewModel _selectedVm;
        public IViewModel SelectedVm
        {
            get { return _selectedVm; }
            set
            {
                if (_selectedVm != value)
                {
                    _selectedVm = value;
                    RaisePropertyChanged(nameof(SelectedVm));
                }
            }
        }


        private ObservableCollection<IViewModel> _viewModels;
        public ObservableCollection<IViewModel> ViewModels
        {
            get { return _viewModels; }
            set
            {
                if (_viewModels != value)
                {
                    _viewModels = value;
                    RaisePropertyChanged(nameof(ViewModels));
                }
            }
        }
        ConnectionVm _conVm = new ConnectionVm();
        BooksManagerVm _bmVm = new BooksManagerVm();
        public MainVm()
        {
            
            _viewModels = new ObservableCollection<IViewModel>
            {
                _conVm,_bmVm
            };
            SelectedVm = _viewModels[0];

            _conVm.ConnectionChanged += ConVm_ConnectionChanged;
        }

        private void ConVm_ConnectionChanged(object sender, EventArgs<bool> e)
        {
            if (e.Param)
                SelectedVm = _bmVm;
            else
                SelectedVm = _conVm;
        }
    }
}
