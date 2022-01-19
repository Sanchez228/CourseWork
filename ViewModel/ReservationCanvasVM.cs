using CourseWork.Model;
using System.Windows.Controls;
using CourseWork.View.UserControls;

namespace CourseWork.ViewModel
{
    public class ReservationCanvasVM : BaseVM
    {
        #region PROPERTIES

        private readonly string _nickname = AuthVM.Nickname;
        public static string UserIconPath { get => "/Resources/img/UserIcon.png"; }
        public string UserNickname { get => _nickname ?? "Default user"; }

        private UserControl currentUserControl = new ReservationGridContentUC();

        public UserControl CurrentUserControl
        {
            get { return currentUserControl; }
            set { currentUserControl = value; NotifyPropertyChanged(nameof(CurrentUserControl)); }
        }

        private UserControl prevUserControl;

        public UserControl PrevUserControl
        {
            get { return prevUserControl; }
            set { prevUserControl = value; NotifyPropertyChanged(nameof(PrevUserControl)); }
        }



        private bool isEnabledPrevBtn = true;

        public bool IsEnabledPrevBtn
        {
            get { return isEnabledPrevBtn; }
            set { isEnabledPrevBtn = value; NotifyPropertyChanged(nameof(IsEnabledPrevBtn)); }
        }
        private bool isEnabledNextBtn = true;

        public bool IsEnabledNextBtn
        {
            get { return isEnabledNextBtn; }
            set { isEnabledNextBtn = value; NotifyPropertyChanged(nameof(IsEnabledNextBtn)); }
        }

        #endregion
        #region COMMANDS

        private RelayCommand userControlLoaded;


        private RelayCommand nextBtnClick;
        public RelayCommand NextBtnClick { get => nextBtnClick ?? new(o => _NextBtnClick()); }

        private RelayCommand prevBtnClick;
        public RelayCommand PrevBtnClick { get => prevBtnClick ?? new(o => _PrevBtnClick()); }

        #endregion
        #region METHODS
        private void _NextBtnClick()
        {
            switch (CurrentUserControl)
            {
                case ReservationGridContentUC:
                    PrevUserControl = CurrentUserControl;
                    CurrentUserControl = new ReservationGridContentNextUC();
                    IsEnabledNextBtn = false;
                    break;
                case ReservationGridContentPastUC:
                    PrevUserControl = CurrentUserControl;
                    CurrentUserControl = new ReservationGridContentUC();
                    IsEnabledNextBtn = true;
                    IsEnabledPrevBtn = true;
                    break;
            }
        }

        private void _PrevBtnClick()
        {
            switch (CurrentUserControl)
            {
                case ReservationGridContentUC:
                    PrevUserControl = CurrentUserControl;
                    CurrentUserControl = new ReservationGridContentPastUC();
                    IsEnabledPrevBtn = false;
                    break;
                case ReservationGridContentNextUC:
                    PrevUserControl = CurrentUserControl;
                    CurrentUserControl = new ReservationGridContentUC();
                    IsEnabledPrevBtn = true;
                    IsEnabledNextBtn = true;
                    break;
            }
        }
        #endregion
    }
}