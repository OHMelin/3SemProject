using ClassLibraryModelLayer;
using FlyBooking.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public class DestinationAPIClient : IDestinationAPIClient
    {
        RestClient _client;
        public DestinationAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public IEnumerable<Destination> GetAllDestinations()
        {
            var request = new RestRequest();
            return _client.Get<IEnumerable<Destination>>(request);
        }
    }
}
