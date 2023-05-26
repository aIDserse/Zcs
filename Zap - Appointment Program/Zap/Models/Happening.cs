namespace Zap.Models
{
    public class Happening
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int MaxPlaces { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Organizer { get; set; }
    }
}
