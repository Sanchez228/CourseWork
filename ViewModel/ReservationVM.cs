using CourseWork.Model;
using CourseWork.Model.Data;
using CourseWork.Model.Data.Service;
using CourseWork.Utils;
using System;
using System.Windows;

namespace CourseWork.ViewModel
{
    public class ReservationVM : BaseVM
    {
        private string nickname = AuthVM.Nickname;
        #region PROPERTIES
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        private TimeSpan timeFrom = ReservationService
                                                    .GetReservationInfo(FillUtil.ROW, FillUtil.COLUMN, FillUtil.PAGE, AuthVM.Nickname)
                                                    .TimeFrom;
        public TimeSpan TimeFrom
        {
            get { return timeFrom; }
            set { timeFrom = value; NotifyPropertyChanged(nameof(TimeFrom)); }
        }

        private TimeSpan timeTo = ReservationService
                                                .GetReservationInfo(FillUtil.ROW, FillUtil.COLUMN, FillUtil.PAGE, AuthVM.Nickname)
                                                .TimeTo;
        public TimeSpan TimeTo
        {
            get { return timeTo; }
            set { timeTo = value; NotifyPropertyChanged(nameof(TimeTo)); }
        }

        private string members = ReservationService.GetReservationInfo(FillUtil.ROW, FillUtil.COLUMN, FillUtil.PAGE, AuthVM.Nickname).Members;

        public string Members
        {
            get { return members; }
            set { members = value; NotifyPropertyChanged(nameof(Members)); }
        }
        #endregion

        #region METHODS
        private void _AddNewReservation()
        {
            bool isIntersect = IsIntersect();
            if (Math.Abs(TimeFrom.TotalMinutes - TimeTo.TotalMinutes) > 30 & !isIntersect)
            {
                ReservationService.CreateReservation(FillUtil.ROW,
                                                     FillUtil.COLUMN,
                                                     FillUtil.PAGE,
                                                     AuthVM.Nickname,
                                                     Members ?? "No members",
                                                     TimeFrom,
                                                     TimeTo);
                MessageBox.Show("Reservation has been successfully created. You can close this window", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else MessageBox.Show("The time interval should be more than 30 minutes\n" +
                "or is this time already taken", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }



        private void _EditReservation()
        {
            bool isIntersect = IsIntersect();
            if (Math.Abs(TimeFrom.TotalMinutes - TimeTo.TotalMinutes) > 30 && !isIntersect)
            {
                ReservationService.EditReservation(FillUtil.ROW,
                                         FillUtil.COLUMN,
                                         FillUtil.PAGE,
                                         AuthVM.Nickname,
                                         Members,
                                         TimeFrom,
                                         TimeTo);
                MessageBox.Show("Reservation has been successfully edit. You can close this window", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else MessageBox.Show("The time interval should be more than 30 minutes\n" +
                "or is this time already taken", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void _DeleteReservation()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ReservationService.DeleteReservation(FillUtil.ROW,
                                       FillUtil.COLUMN,
                                       FillUtil.PAGE,
                                       AuthVM.Nickname);
                MessageBox.Show("Reservation has been successfully delete. You can close this window", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
        private void _OnClosed()
        {
            FillUtil.FillContentGrid(FillUtil.CONTENT_GRID, FillUtil.PAGE);
        }
        private bool IsIntersect()
        {
            bool isIntersect = false;
            foreach (Reservation reservation in ReservationService.GetAllReservations())
            {
                if ((TimeFrom >= reservation.TimeFrom && TimeFrom <= reservation.TimeTo

                    || reservation.TimeFrom >= TimeFrom && reservation.TimeFrom <= TimeTo)

                    && FillUtil.PAGE == reservation.Page && FillUtil.COLUMN == reservation.GridColumn)
                {
                    isIntersect = true;
                    break;
                }
            }

            return isIntersect;
        }
        #endregion

        #region COMMANDS

        private readonly RelayCommand addNewReservation;
        public RelayCommand AddNewReservation { get => addNewReservation ?? new(o => _AddNewReservation()); }


        private readonly RelayCommand onClosed;
        public RelayCommand OnClosed { get => onClosed ?? new(o => _OnClosed()); }


        private readonly RelayCommand editReservation;
        public RelayCommand EditReservation { get => editReservation ?? new(o => _EditReservation()); }

        private readonly RelayCommand deleteReservation;
        public RelayCommand DeleteReservation { get => deleteReservation ?? new(o => _DeleteReservation()); }
        #endregion  
    }
}