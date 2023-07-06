using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Sacrament
    {
        public int SacramentId { get; set; }

        // Foreign Keys.
        public int PeopleId { get; set; }

        public int HymnId { get; set; }

        // Things specific to the meeting.
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Topic { get; set; }

        [Required]
        [StringLength(150)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Ward { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // Navigation.
        public People People { get; set; }

        public Hymn Hymn { get; set; }

        public ICollection<Speaker>? Speakers { get; set; }
    }
}
