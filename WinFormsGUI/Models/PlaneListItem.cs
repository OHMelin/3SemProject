using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.WFORM.Models
{
    internal class PlaneListItem
    {
        public int PlaneID { get; set; }
        public string Model { get; set; }

        public PlaneListItem(int id, string model)
        {
            PlaneID = id;
            Model = model;
        }

        public override string ToString()
        {
            return $"{PlaneID}: {Model}";
        }
    }
}
