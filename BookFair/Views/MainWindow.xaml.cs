using BookFair.Viewmodels;
using System.Windows;

namespace BookFair.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public BooksManagerVm BookManager { get; set; }
        public MainWindow()
        {
            DataContext = new BooksManagerVm();            
            InitializeComponent();
        }
    }
}
