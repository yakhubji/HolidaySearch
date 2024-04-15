using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Query
    {
        public Airport DepartingFrom { get; set; }
        public Airport TravelingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }
    }
}
