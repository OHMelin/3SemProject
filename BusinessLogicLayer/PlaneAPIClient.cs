using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModelLayer;

namespace FlyBooking.APIClient
{
    public class PlaneAPIClient : IPlaneAPIClient
    {
        RestClient _client;
        public PlaneAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public IEnumerable<Plane> GetAllPlanes()
        {
            var request = new RestRequest();
            return _client.Get<IEnumerable<Plane>>(request);
        }
    }
}
