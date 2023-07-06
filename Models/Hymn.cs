using SacramentMeetingPlanner.Models;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Range(0, 409)]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }

        [Required]
        [Range(0, 409)]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymn { get; set; }

        [Required]
        [Range(0, 409)]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymn { get; set; }

        // Special Musical Number or Intermidiate Hymn.
        /* Make these nullable so if they come back null we can make sure they
            do not display on the program as empty fields.*/
        [StringLength(150)]
        [Display(Name = "Special Musical Number")]
        public string? SpecialMusicalNum { get; set; }

        [StringLength(150)]
        [Display(Name = "Preformer")]
        public string? Preformer { get; set; }

        [Range(0, 409)]
        [Display(Name = "Intermidiate Hymn")]
        public int? IntermidiateHymn { get; set; }

    }
}
