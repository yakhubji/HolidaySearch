using HolidaySearch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch
{
    public class HolidaySearchEngine
    {
        private readonly List<Flight> FlightResponse;
        private readonly List<Hotel> HotelResponse;

        public HolidaySearchEngine()
        {
            try
            {
                // Import data from files.
                var flightPath = File.ReadAllText(@".\Flight.json");
                var hotelPath = File.ReadAllText(@".\Hotel.json");

                // Deserialize JSON data into lists of Flight and Hotel objects.
                FlightResponse = JsonConvert.DeserializeObject<List<Flight>>(flightPath);
                HotelResponse = JsonConvert.DeserializeObject<List<Hotel>>(hotelPath);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during file reading or deserialization.
                Console.WriteLine("An error occurred while importing data:");
              
            }
        }

        public List<Holiday> PerformSearch(Query query)
        {
            //filter flights and hotels based on query terms.
            var flights = FindFlights(query.DepartingFrom, query.TravelingTo, query.DepartureDate);
            var hotels = FindHotels(query.TravelingTo, query.Duration, query.DepartureDate);

            var results = new List<Holiday>();

            //compile collection of every possible flight and hotel combination.
            foreach (var hotel in hotels)
            {
                results.AddRange(flights.Select(flight => new Holiday(flight, hotel)));
            }

            //sort the results by total cost to get best value first.
            results = results.OrderBy(x => x.TotalCost).ToList();

            return results;
        }

        private List<Hotel> FindHotels(Airport queryTravelingTo, int queryDuration, DateTime queryDepartureDate)
        {
            //return a filtered collection of hotels, using bitwise operation to determine airport match from Airport enum.
            return HotelResponse.Where(x => x.Nights == queryDuration
                                      && x.ArrivalDate == queryDepartureDate
                                      && (x.LocalAirportsCombined & queryTravelingTo) == queryTravelingTo).ToList();
        }

        private List<Flight> FindFlights(Airport queryDepartingFrom, Airport queryTravelingTo, DateTime queryDepartureDate)
        {
            //return a filtered collection of flights, using bitwise operation to determine airport match from Airport enum.
            return FlightResponse.Where(x => (x.From & queryDepartingFrom) == x.From
                                       && (x.To & queryTravelingTo) == x.To
                                       && x.DepartureDate == queryDepartureDate).ToList();
        }
    }
}
