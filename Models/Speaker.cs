namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {

        // Key.
        public int SpeakerId { get; set; }

        // Foreign Key.
        public int PeopleId { get; set; }

        // Information on Speaker.
        // Make SpeakerType a dropdown in view, that way
        // it will make sense to the user. 
        public string SpeakerType { get; set; }

        public string SpeakerName { get; set; }

        public string SpeakerTopic { get; set; }

        // Navigation.
        public People People { get; set; }

    }
}
