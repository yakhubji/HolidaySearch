using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonProperty(PropertyName = "price_per_night")]
        public int PricePerNight { get; set; }
        [JsonProperty(PropertyName = "local_airports")]
        public List<Airport> LocalAirports { get; set; }
        public Airport LocalAirportsCombined => (Airport)LocalAirports.Sum(x => (int)x);
        public int Nights { get; set; }
    }
}
