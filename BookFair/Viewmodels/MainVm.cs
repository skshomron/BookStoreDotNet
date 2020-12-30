using BookFair.Models;
using System.Collections.ObjectModel;

namespace BookFair.Viewmodels
{
    public interface IViewModel
    {

    }
    public class MainVm : NotifiableObject
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

        public MainVm()
        {
            _viewModels = new ObservableCollection<IViewModel>();
            _viewModels.Add(new BooksManagerVm());
            SelectedVm = _viewModels[0];
        }
    }
}
