using FlyBooking.Model;

namespace ClassLibraryModelLayer
{
	public class Flight
	{
		public int? FlightId { get; set; }
		public DateTime? DepartureDate { get; set;}
		public DateTime? ArrivalDate { get; set;}
		public int? PlaneId { get; set;}
		public int? DestinationId { get; set;}
		public Destination? Destination { get; set;}
		public Plane? Plane { get; set;}
		public FlightPrice? Price { get; set;}
		
        public override string ToString()
        {
		return $"Flight ID: {FlightId}, Plane ID: {PlaneId}";
        }
	}
}
