using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL.Exceptions
{
    public class CommitException : Exception
    {
        public CommitException() { }

        public CommitException(string transactionType, string transactionName) : base($"Commit Exception: Could not {transactionType} transaction \"{transactionName}\".") { }

        public CommitException(string transactionType, string transactionName, Exception inner) : base($"Commit Exception: Could not {transactionType} transaction \"{transactionName}\".", inner) { }

        public override string Message => "Commit Exception: Could not commit transaction.";

        public override string? HelpLink
        {
            get
            {
                return "Get more information here: https://github.com/AndreasAhlbeck/UCN3-FlyBooking";
            }
        }
    }
}
