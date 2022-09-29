namespace MotoGP.Models
{
    public class Race
    {
        public int RaceID { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Race(int raceID, int x, int y, string name)
        {
            RaceID = raceID;
            Name = name;
            X = x;
            Y = y;
        }

        public Race()
        {
        }
    }

}
