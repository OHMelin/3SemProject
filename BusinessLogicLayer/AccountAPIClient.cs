using ClassLibraryModelLayer;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public class AccountAPIClient : IAccountAPIClient
    {

        RestClient _client;
        public AccountAPIClient(string baseApiUrl)
        {
            _client = new RestClient(baseApiUrl);
        }

        public int AddAccount(Account account)
        {
            var request = new RestRequest().AddBody(account);
            return _client.Post<int>(request);
        }

        public Account GetUserByLogin(string password, string username)
        {
			var request = new RestRequest("/GetUserByLogin", Method.Post);
			request.AddJsonBody(new { password = password, username = username });
			var response = _client.Execute(request);

			var content = response.Content;
			if (response.IsSuccessful)
            {
				var account = JsonConvert.DeserializeObject<Account>(content);
                return account;
            }
            else
            {
				throw new Exception($"Failed to get user by login");
			}
		}

        public Account GetUserByID(int id)
        {
            var request = new RestRequest($"{id}");
            return _client.Get<Account>(request);
        }


        public bool LoginAccount(string password, string username)
        {

			var request = new RestRequest("/Login", Method.Post);
            request.AddJsonBody(new { password = password, username = username} );
            var response = _client.Execute(request);
            if (response.Content == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
		}
	}
}
