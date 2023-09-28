using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModelLayer;

namespace FlyBooking.DAL
{
    public interface IPlaneModelDataAccess
    {
        public IEnumerable<PlaneModel> GetAllPlaneModels();
    }
}
