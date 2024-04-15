using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Holiday
    {
        public Holiday(Flight flight, Hotel hotel)
        {
            Flight = flight;
            Hotel = hotel;
        }
        public int TotalCost => Flight.Price + (Hotel.PricePerNight * Hotel.Nights);
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
    }
}
