using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Model.Data.Service
{
    public class ReservationService
    {
        public static List<Reservation> GetAllReservations()
        {
            using ApplicationContext db = new();
            List<Reservation> reservations = db.Reservations.ToList();
            return reservations;
        }
        public static void CreateReservation(int gridRow,
                                         int gridColumn,
                                         string page,
                                         string user,
                                         string members,
                                         TimeSpan timeFrom,
                                         TimeSpan timeTo)
        {
            using ApplicationContext db = new();
            Reservation reservation = new()
            {
                GridColumn = gridColumn,
                GridRow = gridRow,
                Page = page,
                User = user,
                Members = members,
                TimeFrom = timeFrom,
                TimeTo = timeTo
            };
            db.Reservations.Add(reservation);
            db.SaveChanges();
        }
        public static void EditReservation(int gridRow,
                                           int gridColumn,
                                           string page,
                                           string user,
                                           string members,
                                           TimeSpan timeFrom,
                                             TimeSpan timeTo)
        {

            using (ApplicationContext db = new())
            {
#pragma warning disable CS8600
                Reservation reservation = db.Reservations.FirstOrDefault(r => r.GridRow == gridRow
                                                                            && r.GridColumn == gridColumn
                                                                            && r.Page.ToLower() == page.ToLower()
                                                                            && r.User == user);
                reservation.Members = members;
                reservation.TimeFrom = timeFrom;
                reservation.TimeTo = timeTo;
                db.SaveChanges();
            }
        }
        public static bool isReservationExist(int gridRow, int gridColumn, string page, string user)
        {
            using (ApplicationContext db = new())
            {
                bool isExist = db.Reservations.Any(r => r.GridRow == gridRow
                && r.GridColumn == gridColumn
                && r.Page.ToLower() == page.ToLower()
                && r.User == user);
                if (isExist) return true;
            }
            return false;
        }
        public static Reservation GetReservationInfo(int gridRow, int gridColumn, string page, string user)
        {
            using (ApplicationContext db = new())
            {
                Reservation reservation = db.Reservations.FirstOrDefault(r => r.GridRow == gridRow
                                                                             && r.GridColumn == gridColumn
                                                                             && r.Page.ToLower() == page.ToLower()
                                                                             && r.User == user);
                return reservation ?? new Reservation() { GridColumn = gridColumn, GridRow = gridRow, Page = page, User = user };
            }
        }
        public static void DeleteReservation(int gridRow, int gridColumn, string page, string user)
        {
            using (ApplicationContext db = new())
            {
                Reservation reservation = db.Reservations.FirstOrDefault(r => r.GridRow == gridRow
                                                                             && r.GridColumn == gridColumn
                                                                             && r.Page.ToLower() == page.ToLower()
                                                                             && r.User == user);
                db.Reservations.Remove(reservation);
                db.SaveChanges();
            }
        }
    }
}
