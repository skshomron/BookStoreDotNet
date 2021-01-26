using BookFair.Commands;
using BookFair.Interfaces;
using BookFair.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookFair.Viewmodels
{
    public class BooksManagerVm : ViewModelBase
    {
        private ICommand _deleteBookCmd;
        public ICommand DeleteBookCmd => _deleteBookCmd ?? (_deleteBookCmd = new RelayCommand(DeleteBookExecute, DeleteBookCanExecute));

        private ICommand _createBookCmd;
        public ICommand CreateBookCmd => _createBookCmd ?? (_createBookCmd = new RelayCommand(CreateBookExecute, CreateBookCanExecute));

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    RaisePropertyChanged(nameof(Books));
                }
            }
        }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                if (_selectedBook != value)
                {
                    _selectedBook = value;
                    RaisePropertyChanged(nameof(SelectedBook));
                }
            }
        }

        public BooksManagerVm()
        {
            Books = new ObservableCollection<Book>();
        }

        private bool CreateBookCanExecute(object obj)
        {
            return true;
        }
        private void CreateBookExecute(object obj)
        {
            var newBook = new Book();
            Books.Add(newBook);
            SelectedBook = newBook;
        }

        private bool DeleteBookCanExecute(object obj)
        {
            var book = obj as Book;
            return Books.Contains(book);
        }
        private void DeleteBookExecute(object obj)
        {
            var book = obj as Book;
            var index = Books.IndexOf(book);
            Books.Remove(book);
            SelectedBook = Books.Count > index ? Books[index] : Books.Count == 0 ? null : Books[index - 1];
        }
    }
}
