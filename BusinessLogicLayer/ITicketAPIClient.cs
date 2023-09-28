using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
	public interface ITicketAPIClient
	{
		public IEnumerable<Ticket> GetAllTicketsFromUser(int id);
	}
}
