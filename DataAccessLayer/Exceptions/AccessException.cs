using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL.Exceptions
{
    public class AccessException : Exception
    {
        public AccessException() { }

        public AccessException(string transactionName) : base($"Access Exception: Could not open a connection to the database in \"{transactionName}\".") { }

        public AccessException(string transactionName, Exception inner) : base($"Access Exception: Could not open a connection to the database in \"{transactionName}\".", inner) { }

        public override string Message => "Access Exception: Could not open a connection to the database.";

        public override string? HelpLink 
        {
            get 
            {
                return "Get more information here: https://github.com/AndreasAhlbeck/UCN3-FlyBooking";
            }
        }
    }
}
