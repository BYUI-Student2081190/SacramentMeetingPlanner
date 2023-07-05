namespace SacramentMeetingPlanner.Models
{
    public class Sacrament
    {
        public int SacramentId { get; set; }

        // Foreign Keys.
        public int PeopleId { get; set; }

        public int HymnId { get; set; }

        // Things specific to the meeting.
        public string Topic { get; set; }

        public DateTime Date { get; set; }

        // Navigation.
        public People People { get; set; }

        public Hymn Hymn { get; set; }

    }
}
