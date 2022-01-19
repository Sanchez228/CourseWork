using System.Windows.Controls;
using CourseWork.Utils;

namespace CourseWork.View.UserControls
{
    public partial class ReservationGridContentPastUC : UserControl
    {
        
        public ReservationGridContentPastUC()
        {
            InitializeComponent();
            FillUtil.FillDaysOfWeek(contentHeaderGrid, -7, 0);
            FillUtil.FillContentGrid(contentGrid, "past");
        }
    }
}