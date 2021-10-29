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

        public Boolean Get(Booking newbooking)
        {
            var tempQuantity = newbooking.Resource.Quantity;
            var tempBookings = bookReservationContext.Bookings.Where(f =>(f.DateFrom <= newbooking.DateFrom)&&(f.DateTo > newbooking.DateTo)).ToList();
            foreach (Booking booking in tempBookings)
            {
                tempQuantity = tempQuantity - booking.BookingQuantity;
                if (tempQuantity < 0)
                {
                    return false;
                }
            }
            if ((tempQuantity - newbooking.BookingQuantity) < 0)
                return false;
            return true;
        }
    }
}
