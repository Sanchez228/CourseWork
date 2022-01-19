using CourseWork.ViewModel;
using System.Windows;

namespace CourseWork.View
{
    public partial class AddNewReservationWindow : Window
    {
        public AddNewReservationWindow()
        {
            InitializeComponent();
            DataContext = new ReservationVM();
        }
    }
}
