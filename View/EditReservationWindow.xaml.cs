using CourseWork.ViewModel;
using System.Windows;

namespace CourseWork.View
{
    public partial class EditReservationWindow : Window
    {
        public EditReservationWindow()
        {
            InitializeComponent();
            DataContext = new ReservationVM();
        }
    }
}
