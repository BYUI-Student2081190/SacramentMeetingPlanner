using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {

        // Key.
        public int HymnId { get; set; }

        // Required Hymns.
        /* Why int? Because we can set a range on the Hymn Book. So someone cannot
            put a number less than the amount of Hymns inside the Hymn book,
            and they cannot put a number greater.*/
        public int OpeningHymn { get; set; }

        public int SacramentHymn { get; set; }

        public int ClosingHymn { get; set; }

        // Special Musical Number or Intermidiate Hymn.
        /* Make these nullable so if they come back null we can make sure they
            do not display on the program as empty fields.*/
        public string? SpecialMusicalNum { get; set; }

        public string? Preformer { get; set; }

        public int? IntermidiateHymn { get; set; }

    }
}
