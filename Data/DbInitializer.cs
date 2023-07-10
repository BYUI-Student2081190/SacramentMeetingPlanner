//using Microsoft.EntityFrameworkCore;
//using SacramentMeetingPlanner.Models;
//using System;
//using System.Linq;

//namespace SacramentMeetingPlanner.Data
//{
//    public class DbInitializer
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new SacramentContext(
//                serviceProvider.GetRequiredService<
//                    DbContextOptions<SacramentContext>>()))
//            {
//                context.Database.EnsureCreated();

//                // Look for any already made Sacrament Meetings.
//                if (context.Sacraments.Any())
//                {
//                    return; //DB has been seeded.
//                }

//                // Create the seed data in the tables.

//                // TestSacrament Data.
//                Meeting testSacrament = new Meeting { HymnId = 1, PeopleId = 1, Topic = "Beta", Date = DateTime.Parse("2001-01-01"), Ward = "Beta 2nd Ward" };

//                // Add Changes.
//                context.Sacraments.Add(testSacrament);

//                // TestPeople Data.
//                Models.Program testPeople = new Models.Program { Presiding = "Test Bishop", Conducting = "Brother Test", OpeningPrayer = "Sister Test", ClosingPrayer = "Brother Beta" };

//                // Add Changes.
//                context.Peoples.Add(testPeople);

//                // TestSpeaker Data.
//                var speakers = new Activity[]
//                {
//                new Activity{SacramentId = 1, SpeakerType = "Youth Speaker", SpeakerName = "Sister Beta", SpeakerTopic = "Beta"},
//                new Activity{SacramentId = 1, SpeakerType = "Speaker", SpeakerName = "Brother Alpha", SpeakerTopic = "Beta"},
//                new Activity{SacramentId = 1, SpeakerType = "Speaker", SpeakerName = "Sister Alpha", SpeakerTopic = "Beta"}
//                };

//                // Add Changes.
//                foreach (Activity s in speakers)
//                {
//                    context.Speakers.Add(s);
//                }

//                // TestHymn Data.
//                Hymn testHymn = new Hymn { OpeningHymn = 100, SacramentHymn = 101, ClosingHymn = 102, SpecialMusicalNum = "If You Could Hie to Kolob", Performer = "Sister Bravo" };

//                // Add Changes.
//                context.Hymns.Add(testHymn);

//                // Save Changes.
//                context.SaveChanges();
//            }
//        }
//    }
//}
