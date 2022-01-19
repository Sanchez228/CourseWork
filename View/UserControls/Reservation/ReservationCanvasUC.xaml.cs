using CourseWork.Utils;
using CourseWork.ViewModel;
using System.Windows.Controls;

namespace CourseWork.View.UserControls
{
    public partial class ReservationCanvasUC : UserControl
    {
        public ReservationCanvasUC()
        {
            InitializeComponent();
            DataContext = new ReservationCanvasVM();
            FillUtil.FillHoursStackPanel(hours);
        }
    }
}
