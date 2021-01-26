using BookFair.Viewmodels;
using System.Windows;

namespace BookFair.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainVm();            
            InitializeComponent();
        }
    }
}
