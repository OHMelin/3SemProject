using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL.Exceptions
{
    public class RollbackException : Exception
    {
        public RollbackException() { }

        public RollbackException(string transactionName) : base($"Rollback Exception: Failed to rollback \"{transactionName}\".") { }

        public RollbackException(string transactionName, Exception inner) : base($"Rollback Exception: Failed to rollback \"{transactionName}\".", inner) { }

        public override string Message => "Rollback Exception: Failed to rollback.";

        public override string? HelpLink
        {
            get
            {
                return "Get more information here: https://github.com/AndreasAhlbeck/UCN3-FlyBooking";
            }
        }
    }
}
