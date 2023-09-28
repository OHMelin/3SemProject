using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModelLayer;

namespace FlyBooking.APIClient
{
    public interface IPlaneModelAPIClient
    {
        public IEnumerable<PlaneModel> GetAllPlaneModels();
    }
}
