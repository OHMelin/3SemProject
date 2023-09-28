using ClassLibraryModelLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public class SeatAPIClient : ISeatAPIClient
    {
        RestClient _client;
        public SeatAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public IEnumerable<Seat> GetAllFlightSeatsWhereID(int id)
        {
            var request = new RestRequest($"flights/{id}");
            return _client.Get<IEnumerable<Seat>>(request);
        }
        public IEnumerable<Seat> GetAvailableSeatsWhereFlightId(int id)
        {
            var request = new RestRequest($"flights/{id}/available");
            return _client.Get<IEnumerable<Seat>>(request);
        }
    }
}
