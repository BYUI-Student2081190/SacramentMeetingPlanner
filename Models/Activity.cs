using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Activity
    {

        // Key.
        public int Id { get; set; }

        // Foreign Key.
        public int MeetingID { get; set; }

        // Specific to Model.
        [Required]
        [StringLength(150)]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = "";

        [Required]
        [StringLength(100)]
        [Display(Name = "Event Info")]
        public string? EventInfo { get; set; }

        [StringLength(150)]
        [Display(Name = "Event Footer")]
        public string? EventFooter { get; set; }

        public int Order { get; set; }

        //public ICollection<MeetingProgram> MeetingPrograms { get; set; }
    }
}
