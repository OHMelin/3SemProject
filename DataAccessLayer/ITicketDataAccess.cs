using ClassLibraryModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
	public interface ITicketDataAccess
	{
		public IEnumerable<Ticket> GetAllTicketsFromUser(int id);
	}
}
