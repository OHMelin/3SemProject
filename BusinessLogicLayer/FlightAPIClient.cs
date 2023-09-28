using ClassLibraryModelLayer;
using FlyBooking.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace FlyBooking.APIClient
{
    public class FlightAPIClient : IFlightAPIClient
    {
        RestClient _client;
        public FlightAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public int AddFlight(Flight flight)
        {
            var request = new RestRequest().AddBody(flight);
            return _client.Post<int>(request);
        }

        public bool DeleteFlight(int id)
        {
            var request = new RestRequest($"{id}");
            return _client.Delete<bool>(request);
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            var request = new RestRequest();
            return _client.Get<IEnumerable<Flight>>(request);
        }

        public Flight GetFlightById(int id)
        {
            var request = new RestRequest($"{id}");
            return _client.Get<Flight>(request);
        }

        public bool UpdateFlight(Flight flight)
        {
            var request = new RestRequest().AddBody(flight);
            return _client.Put<bool>(request);
        }
    }
}
