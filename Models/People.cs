using System;
using System.Collections.Generic;

namespace SacramentMeetingPlanner.Models
{
    public class People
    {
        // Model Key.
        public int PeopleId { get; set; }

        // Things specific to the model.
        public string Presiding { get; set; }

        public string Conducting { get; set; }

        public string OpeningPrayer { get; set; }

        public string ClosingPrayer { get; set; }

        // Navigation.
        ICollection<Speaker> Speakers { get; set; }

    }
}
