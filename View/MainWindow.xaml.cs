using CourseWork.ViewModel;
using System.Windows;

namespace CourseWork.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }
    }
}
