using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.WFORM.Models
{
    internal class FlightListItem
    {
        public int? Id { get; private set; }
        public string? PlaneName { get; private set; }
        public string? CityName { get; private set; }
        public DateTime? ArrivalDate { get; private set; }
        public DateTime? DepatureDate { get; private set; }

		public FlightListItem(int? id, string? planeName, DateTime? arrivalDate, DateTime? depatureDate, string cityName)
        {
            Id = id;
            PlaneName = planeName;
            CityName = cityName;
            ArrivalDate = arrivalDate;
            DepatureDate = depatureDate;
        }

        public override string ToString() 
        {
            return $"ID: {Id}, Plane: {PlaneName}, From: Aalborg Lufthavn, To: {CityName}, Depature: {DepatureDate}, Arrival: {ArrivalDate}";
        }
    }
}
