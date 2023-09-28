namespace ClassLibraryModelLayer
{
    public class Seat
    {
        public int? SeatID { get; set; }
        public int? SeatRow { get; set;}
        public string? SeatColumn { get; set;}
        public int? PlaneModelID { get; set;}
        public bool? IsBooked { get; set;}
    }
}
