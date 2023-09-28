using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public interface IAccountDataAccess
    {
        public int AddAccount(Account account);
        Account GetUserByLogin(string password, string username);
        public bool LoginAccount(string password, string username);
        Account GetUserByID(int id);
    }
}
