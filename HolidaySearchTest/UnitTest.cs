using HolidaySearch;
using HolidaySearch.Models;

namespace HolidaySearchTest
{
    public class Tests
    {
        [Test]
        public void UserStory1Test()
        {
            //Input Query
            //Departing from: Manchester Airport (MAN)
            //Traveling to: Malaga Airport (AGP)
            //Departure Date: 2023/07/01
            //Duration: 7 nights
            var query = new Query
            {
                DepartingFrom = Airport.Man,
                TravelingTo = Airport.Agp,
                DepartureDate = new DateTime(2023, 07, 01),
                Duration = 7
            };

            var holidaySearch = new HolidaySearchEngine();

            var results = holidaySearch.PerformSearch(query);

            //Expectation
            //Flight 2 and Hotel 9
            Assert.AreEqual(2, results.First().Flight.Id);
            Assert.AreEqual(9, results.First().Hotel.Id);
        }

        [Test]
        public void UserStory2Test()
        {
            //Input Query
            //Departing from: Any London Airport
            //Traveling to: Mallorca Airport (PMI)
            //Departure Date: 2023/06//15
            //Duration: 10 nights
            var query = new Query
            {
                DepartingFrom = Airport.AnyLondon,
                TravelingTo = Airport.Pmi,
                DepartureDate = new DateTime(2023, 06, 15),
                Duration = 10
            };

            var holidaySearch = new HolidaySearchEngine();

            var results = holidaySearch.PerformSearch(query);

            //Expectation
            //Flight 6 and Hotel 5
            Assert.AreEqual(6, results.First().Flight.Id);
            Assert.AreEqual(5, results.First().Hotel.Id);
        }

        [Test]
        public void UserStory3Test()
        {
            //Input Query
            //Departing from: Any Airport
            //Traveling to: Gran Canaria Airport (LPA)
            //Departure Date: 2022/11/10
            //Duration: 14 nights
            var query = new Query
            {
                DepartingFrom = Airport.AnyAirport,
                TravelingTo = Airport.Lpa,
                DepartureDate = new DateTime(2022, 11, 10),
                Duration = 14
            };

            var holidaySearch = new HolidaySearchEngine();

            var results = holidaySearch.PerformSearch(query);

            //Expectation
            //Flight 7 and Hotel 6
            Assert.AreEqual(7, results.First().Flight.Id);
            Assert.AreEqual(6, results.First().Hotel.Id);
        }
    }
}