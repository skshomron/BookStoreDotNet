using BookFair.Commands;
using BookFair.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BookFair.Viewmodels
{
    public class AlbumVm : NotifiableObject
    {

        private ICommand _nextCmd;
        public ICommand NextCmd => _nextCmd ?? (_nextCmd = new RelayCommand(NextCmdExecute, NextCmdCanExecute));
        private void NextCmdExecute(object obj)
        {
            Next();
        }
        private bool NextCmdCanExecute(object obj)
        {
            return SelectedIndex.HasValue && SelectedIndex.Value < ImagePathes.Count - 1;
        }


        private ICommand _previousCmd;
        public ICommand PreviousCmd => _previousCmd ?? (_previousCmd = new RelayCommand(PreviousCmdExecute, PreviousCmdCanExecute));
        private void PreviousCmdExecute(object obj)
        {
            Previous();
        }
        private bool PreviousCmdCanExecute(object obj)
        {
            return SelectedIndex.HasValue && SelectedIndex.Value > 0;
        }


        private int? _selectedIndex;
        public int? SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    RaisePropertyChanged(nameof(SelectedIndex));
                    RaisePropertyChanged(nameof(SelectedImagePath));
                }
            }
        }

        public string SelectedImagePath => SelectedIndex.HasValue ? ImagePathes[SelectedIndex.Value] : string.Empty;

        private ObservableCollection<string> _imagePathes;
        public ObservableCollection<string> ImagePathes
        {
            get { return _imagePathes; }
            set
            {
                if (_imagePathes != value)
                {
                    _imagePathes = value;
                    RaisePropertyChanged(nameof(ImagePathes));
                }
            }
        }

        public void Next()
        {
            Move(1);
        }

        public void Previous()
        {
            Move(-1);
        }

        private void Move(int step)
        {
            if (ImagePathes != null && ImagePathes?.Count > 0) // check if imagePatches?.Count>0 does the same
            {
                SelectedIndex = (SelectedIndex + step) % ImagePathes.Count;
            }
            else
            {
                SelectedIndex = null;
            }
        }
        public AlbumVm(IEnumerable<string> imagePathes)
        {
            ImagePathes = imagePathes != null ?
                                        new ObservableCollection<string>(imagePathes) :
                                        new ObservableCollection<string>(new[] { @"C:\Users\sksph\Dropbox\Photos\Sample Album\Costa Rican Frog.jpg", @"C:\Users\sksph\Dropbox\Photos\Sample Album\Boston City Flow.jpg" });
            SelectedIndex = ImagePathes.Count > 0 ? 0 : (int?)null;
        }


    }
}
