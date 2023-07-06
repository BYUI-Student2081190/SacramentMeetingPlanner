using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {

        // Key.
        public int SpeakerId { get; set; }

        // Foreign Key.
        public int SacramentId { get; set; }

        // Information on Speaker.
        // Make SpeakerType a dropdown in view, that way
        // it will make sense to the user.
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Type of Speaker")]
        public string SpeakerType { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Speaker Name")]
        public string SpeakerName { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Speaker Topic")]
        public string SpeakerTopic { get; set; }

        // Navigation.
        public Sacrament Sacrament { get; set; }

    }
}
