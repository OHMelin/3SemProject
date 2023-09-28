using FlyBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.DAL
{
    public interface IDestinationDataAccess
    {
        public IEnumerable<Destination> GetAllDestinations();
    }
}
