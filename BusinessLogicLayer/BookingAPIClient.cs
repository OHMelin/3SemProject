using ClassLibraryModelLayer;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public class BookingAPIClient : IBookingAPIClient
    {
        RestClient _client;
        public BookingAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public int AddBooking(Booking booking)
        {
            var request = new RestRequest().AddBody(booking);
            return _client.Post<int>(request);
        }
        public bool DeleteBooking(int id)
        {
            var request = new RestRequest($"{id}");
            return _client.Delete<bool>(request);
        }
        public IEnumerable<Booking> GetBookingsByAccountID(int id) 
        {
            var requst = new RestRequest($"Accounts/{id}");
            return _client.Get<IEnumerable<Booking>>(requst);
        }
    }
}
