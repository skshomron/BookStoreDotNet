using System.Collections.ObjectModel;

namespace BookFair
{
    public interface IViewModel
    {

    }
    public class MainViewModel:NotifiableObject
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

        public MainViewModel()
        {
            _viewModels = new ObservableCollection<IViewModel>();
            _viewModels.Add(new BooksManager());
            SelectedVm = _viewModels[0];
        }
    }
}
