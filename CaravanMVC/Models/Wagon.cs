namespace CaravanMVC.Models
{
    public class Wagon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumWheels { get; set; }
        public bool IsCovered { get; set; }
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}
