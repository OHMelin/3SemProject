using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModelLayer;

namespace FlyBooking.APIClient
{
    public class PlaneModelAPIClient : IPlaneModelAPIClient
    {
        RestClient _client;
        public PlaneModelAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public IEnumerable<PlaneModel> GetAllPlaneModels()
        {
            var request = new RestRequest();
            return _client.Get<IEnumerable<PlaneModel>>(request);
        }
    }
}
