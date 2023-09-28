using FlyBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.APIClient
{
    public interface IDestinationAPIClient
    {
        public IEnumerable<Destination> GetAllDestinations();
    }
}
