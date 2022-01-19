using CourseWork.ViewModel;
using System.Windows;

namespace CourseWork.View
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = new AuthVM();
        }
    }
}
