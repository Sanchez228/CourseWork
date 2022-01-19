using CourseWork.Utils;
using System.Windows.Controls;

namespace CourseWork.View.UserControls
{
    public partial class ReservationGridContentNextUC : UserControl
    {
        public ReservationGridContentNextUC()
        {
            InitializeComponent();
            FillUtil.FillDaysOfWeek(contentHeaderGrid, 7, 14);
            FillUtil.FillContentGrid(contentGrid, "future");
        }
    }

}