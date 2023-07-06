using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;
using System;
using System.Linq;

namespace SacramentMeetingPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any already made Sacrament Meetings.
                if (context.Sacraments.Any())
                {
                    return; //DB has been seeded.
                }

                // Create the seed data in the tables.

                // TestSacrament Data.
                Sacrament testSacrament = new Sacrament { HymnId = 1, PeopleId = 1, Topic = "Beta", Date = DateTime.Parse("2001-01-01"), Ward = "Beta 2nd Ward" };

                // Add Changes.
                context.Sacraments.Add(testSacrament);

                // TestPeople Data.
                People testPeople = new People { Presiding = "Test Bishop", Conducting = "Brother Test", OpeningPrayer = "Sister Test", ClosingPrayer = "Brother Beta" };

                // Add Changes.
                context.Peoples.Add(testPeople);

                // TestSpeaker Data.
                var speakers = new Speaker[]
                {
                new Speaker{SacramentId = 1, SpeakerType = "Youth Speaker", SpeakerName = "Sister Beta", SpeakerTopic = "Beta"},
                new Speaker{SacramentId = 1, SpeakerType = "Speaker", SpeakerName = "Brother Alpha", SpeakerTopic = "Beta"},
                new Speaker{SacramentId = 1, SpeakerType = "Speaker", SpeakerName = "Sister Alpha", SpeakerTopic = "Beta"}
                };

                // Add Changes.
                foreach (Speaker s in speakers)
                {
                    context.Speakers.Add(s);
                }

                // TestHymn Data.
                Hymn testHymn = new Hymn { OpeningHymn = 100, SacramentHymn = 101, ClosingHymn = 102, SpecialMusicalNum = "If You Could Hie to Kolob", Preformer = "Sister Bravo" };

                // Add Changes.
                context.Hymns.Add(testHymn);

                // Save Changes.
                context.SaveChanges();
            }
        }
    }
}
