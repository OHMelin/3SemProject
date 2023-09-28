using ClassLibraryModelLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
	public class TicketAPIClient : ITicketAPIClient
	{
		RestClient _client;

		public TicketAPIClient(string baseAPIUrl)
		{
			_client = new RestClient(baseAPIUrl);
		}

		public IEnumerable<Ticket> GetAllTicketsFromUser(int id)
		{
			var request = new RestRequest($"{id}");
			return _client.Get<IEnumerable<Ticket>>(request);
		}
	}
}
