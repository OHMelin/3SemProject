using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public interface IAccountAPIClient
    {
        public int AddAccount(Account account);
        public Account GetUserByLogin(string password, string username);
        public bool LoginAccount(string password, string username);
        public Account GetUserByID(int id);
	}
}
