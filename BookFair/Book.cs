using System.Collections.ObjectModel;

namespace BookFair
{

    public enum BookState
    {
        New,
        LikeNew,
        VeryGood,
        Good,
        Acceptable
    }

    public enum BookStatus
    {
        Registered,
        published,
        Sold,
        Deleted
    }
    public class Book : NotifiableObject
    {        
        private string  _title;
        public string  Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        private BookStatus _status;
        public BookStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged(nameof(Status));
                }
            }
        }

        private BookState _state;
        public BookState State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    RaisePropertyChanged(nameof(State));
                }
            }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChanged(nameof(Price));
                }
            }
        }

        private int _editionYear;
        public int EditionYear
        {
            get { return _editionYear; }
            set
            {
                if (_editionYear != value)
                {
                    _editionYear = value;
                    RaisePropertyChanged(nameof(EditionYear));
                }
            }
        }


        private Album _album;
        public Album Album
        {
            get { return _album; }
            set
            {
                if (_album != value)
                {
                    _album = value;
                    RaisePropertyChanged(nameof(Album));
                }
            }
        }        

        private ObservableCollection<Author> _authors;
        public ObservableCollection<Author> Authors
        {
            get { return _authors; }
            set
            {
                if (_authors != value)
                {
                    _authors = value;
                    RaisePropertyChanged(nameof(Authors));
                }
            }
        }


        private string  _isbn;
        public string  Isbn
        {
            get { return _isbn; }
            set
            {
                if (_isbn != value)
                {
                    _isbn = value;
                    RaisePropertyChanged(nameof(Isbn));
                }
            }
        }

        //private Isbn _isbn;
        //public Isbn Isbn
        //{
        //    get { return _isbn; }
        //    set
        //    {
        //        if (_isbn != value)
        //        {
        //            _isbn = value;
        //            RaisePropertyChanged(nameof(Isbn));
        //        }
        //    }
        //}

        public Book()
        {
            Album = new Album(null);
        }
    }
}
