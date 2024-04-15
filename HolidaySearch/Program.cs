using HolidaySearch.Models;

namespace HolidaySearch
{
    public class HolidaySearch
    {
        public static void Main(string[] args)
        {
            //Testing for Local
            var query = new Query
            {
                DepartingFrom = Airport.Man,
                TravelingTo = Airport.Agp,
                DepartureDate = new DateTime(2023, 07, 01),
                Duration = 7
            };

            var holidaySearch = new HolidaySearchEngine();

            var results = holidaySearch.PerformSearch(query);
        }
    }
}
