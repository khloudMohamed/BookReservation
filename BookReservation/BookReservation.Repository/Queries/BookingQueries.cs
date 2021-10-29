using BookReservation.Repository.Entities;
using BookReservation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Queries
{
    public class BookingQueries: IBookingQueries
    {

        private BookReservationDbContext bookReservationContext;

        public BookingQueries(BookReservationDbContext _bookReservationDbContext)
        {
            bookReservationContext = _bookReservationDbContext;
        }

        public Boolean SaveNewBooking(Booking newbooking)
        {
            try {
                int totalQuantity = 0;
                var MaxQuantity = newbooking.Resource.Quantity;
                var tempBookings = bookReservationContext.Bookings.Where(f => (f.DateFrom <= newbooking.DateFrom) && (f.DateTo > newbooking.DateTo)).ToList();
                foreach (Booking booking in tempBookings)
                {
                    //tempQuantity = tempQuantity - booking.BookingQuantity;
                    totalQuantity += booking.BookingQuantity;
                }
                if (ValidateNewBooking(totalQuantity, newbooking.BookingQuantity)) {
                    bookReservationContext.Bookings.Add(newbooking);
                }

                return true;
            }
            catch(Exception e) {
                return false;
            }
           
        }

        public Boolean ValidateNewBooking(int totalQuantity,int MaxQuantity)
        {
            try {
                if ((totalQuantity - MaxQuantity) < 0)
                    return false;
                return true;
            }
            catch(Exception e) {
                return false;
            }
           
        }
    }
}
