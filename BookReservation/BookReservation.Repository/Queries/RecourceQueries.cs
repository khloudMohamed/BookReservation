using BookReservation.Repository.Entities;
using BookReservation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Queries
{
    public class RecourceQueries: IRecourceQueries
    {
        
        private BookReservationDbContext bookReservationContext;

        public RecourceQueries(BookReservationDbContext _bookReservationDbContext)
        {
            bookReservationContext = _bookReservationDbContext;
        }
        public List<Resource> Get()
        {
            return bookReservationContext.Resources.ToList();
        }
        public List<Resource> Get(int id)
        {
            return bookReservationContext.Resources.Where(f => f.Id == id).ToList();
        }

    }
}
