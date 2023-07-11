using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Migrations;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ProgramContext _context;

        public ActivitiesController(ProgramContext context)
        {
            _context = context;
        }

        // Class dictonary.
        private Dictionary<string, int> _activitiesOrder = new Dictionary<string, int>() 
        {
            {"Presiding", 1},
            {"Conducting", 2},
            {"Opening Hymn", 3},
            {"Invocation", 4},
            {"Ward Buisness", 5},
            {"Sacrament Hymn", 6},
            {"Passing of the Sacrament", 7},
            {"Speaker", 8},
            {"Youth Speaker", 8},
            {"Article of Faith", 8},
            {"Testimonies", 9},
            {"Intermediate Hymn", 10},
            {"Musical Number", 11},
            {"Closing Hymn", 12},
            {"Benediction", 13}
        };

        // GET: Activities
        public async Task<IActionResult> Index()
        {
              return _context.Activities != null ? 
                          View(await _context.Activities.ToListAsync()) :
                          Problem("Entity set 'ProgramContext.Activities'  is null.");
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ActivityID == id);
            if (activity == null)
            {
                return NotFound();
            }

            foreach (Meeting m in _context.Meetings) 
            {
                if (m.Id == activity.MeetingID)
                {
                    ViewData["ViewWard"] = m.WardName;
                    ViewData["MeetingDate"] = m.Date.ToShortDateString();
                }
                else
                {
                    ViewData["ViewWard"] = "None";
                    ViewData["MeetingDate"] = "None";
                }
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            PopulateMeetingsDropDownList();

            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityID,MeetingID,EventName,EventInfo,EventFooter,Order")] Activity activity, int selectedMeeting)
        {
            // Custom Valid check, if falied it returns to the activity.
            bool testResult = ValidateActivity(activity, selectedMeeting);

            if (testResult == true) 
            {
                PopulateMeetingsDropDownList();

                // Returns true return to the view with error message.
                ViewData["ErrorMessage"] = "You already have this Activity in that meeting.";

                return View(activity);
            }

            // Second test call.
            testResult = ValidateActivityInfo(activity);

            if (testResult == false)
            {
                PopulateMeetingsDropDownList();

                // Returns true return to the view with error message.
                ViewData["NullMessage"] = $"You must have this field blank while '{activity.EventName}' is selected.";

                return View(activity);
            }

            if (ModelState.IsValid)
            {
                // Set the values.
                activity.MeetingID = selectedMeeting;

                // Set the order based on a dictonary.
                activity.Order = _activitiesOrder[activity.EventName];

                _context.Add(activity);
                await _context.SaveChangesAsync();

                // Then return to the index.
                return RedirectToAction(nameof(Index));
            }

            PopulateMeetingsDropDownList();

            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            // Populate Dropdown.
            PopulateMeetingsDropDownList();
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityID,MeetingID,EventName,EventInfo,EventFooter,Order")] Activity activity, int selectedMeeting)
        {
            if (id != activity.ActivityID)
            {
                return NotFound();
            }

            // Custom Valid check, if falied it returns to the activity.
            bool testResult = ValidateActivity(activity, selectedMeeting, id);

            if (testResult == true)
            {
                PopulateMeetingsDropDownList();

                // Returns true return to the view with error message.
                ViewData["ErrorMessage"] = "You already have this Activity in that meeting.";

                return View(activity);
            }

            // Second test call.
            testResult = ValidateActivityInfo(activity);

            if (testResult == false)
            {
                PopulateMeetingsDropDownList();

                // Returns true return to the view with error message.
                ViewData["NullMessage"] = $"You must have this field blank while '{activity.EventName}' is selected.";

                return View(activity);
            }

            if (ModelState.IsValid)
            {

                activity.MeetingID = selectedMeeting;

                // Set the order based on a dictonary.
                if (_activitiesOrder.TryGetValue(activity.EventName, out int output))
                {
                    activity.Order = output;

                    var activityToUpdate = await _context.Activities.FirstOrDefaultAsync(s => s.ActivityID == id);
                    if (await TryUpdateModelAsync<Activity>(
                        activityToUpdate,
                        "",
                        s => s.EventName, s => s.EventInfo, s => s.EventFooter, s => s.MeetingID, s => s.Order))
                    {
                        try
                        {
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        catch (DbUpdateException /* ex */)
                        {
                            //Log the error (uncomment ex variable name and write a log.)
                            ModelState.AddModelError("", "Unable to save changes. " +
                                "Try again, and if the problem persists, " +
                                "see your system administrator.");
                        }
                    }
                }
            }

            PopulateMeetingsDropDownList();

            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.ActivityID == id);
            if (activity == null)
            {
                return NotFound();
            }

            foreach (Meeting m in _context.Meetings)
            {
                if (m.Id == activity.MeetingID)
                {
                    ViewData["ViewWard"] = m.WardName;
                    ViewData["MeetingDate"] = m.Date.ToShortDateString();
                }
                else
                {
                    ViewData["ViewWard"] = "None";
                    ViewData["MeetingDate"] = "None";
                }
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Activities == null)
            {
                return Problem("Entity set 'ProgramContext.Activities'  is null.");
            }
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(int id)
        {
          return (_context.Activities?.Any(e => e.ActivityID == id)).GetValueOrDefault();
        }

        // LOAD: Department info for the drop-down list.
        private void PopulateMeetingsDropDownList(object? selectedDepartment = null)
        {
            var meetingsQuery = from m in _context.Meetings
                                   orderby m.WardName
                                   select m;
            ViewBag.MeetingsID = new SelectList(meetingsQuery.AsNoTracking(), "Id", "WardName", selectedDepartment);
        }

        // VALIDATE: Custom validation for the Create/Edit pages. This checks to see if we have duplicate activites in one
        // meeting.
        private bool ValidateActivity(Activity activity, int meetingId, int? id = null) 
        {
            // First test, check to see if this is not a speaker.
            if (activity.EventName != "Speaker" && activity.EventName != "Youth Speaker" && activity.EventName != "Article of Faith")
            {
                // Test to see if an id is passed in by Edit.
                if (id != null) 
                {
                    // Test the relationship, is this trying to edit the same thing? Or become something new that already exsists.
                    int countActivity = 0;

                    foreach (Activity a in _context.Activities) 
                    {
                        if (a.EventName == activity.EventName) 
                        {
                            countActivity += 1;
                        }
                    }

                    // Now test if the activity's are equal if so, return false, if not return true.
                    if (countActivity == 0) 
                    {
                        // Green Thumbs up! Lets go!
                        return false;
                    }
                }
                // Test the Activity to see if others aready exsist in the DB in the same meeting.
                foreach (Activity a in _context.Activities)
                {

                    if (a.MeetingID == meetingId && a.EventName == activity.EventName)
                    {
                        return true;
                    }

                }
            }
            // If all checks out return false.
            return false;
        }

        // VALIDATE: Second Validation Check. This checks to see if the EventInfo is null when it needs to be.
        private bool ValidateActivityInfo(Activity activity)
        {
            // Create a check to see if values in EventInfo that should be null are not null.
            // Second Test, see if this object's info needs to be null.
            if (activity.EventName == "Ward Buisness")
            {
                if (activity.EventInfo != null)
                {
                    // Test Failed return true.
                    return false;
                }
            }

            else if (activity.EventName == "Passing of the Sacrament")
            {
                if (activity.EventInfo != null)
                {
                    // Test Failed return true.
                    return false;
                }
            }

            else if (activity.EventName == "Testimonies")
            {
                if (activity.EventInfo != null)
                {
                    // Test Failed return true.
                    return false;
                }
            }

            // If we are ok send back a true because we passed!
            return true;
        }

        // PRINT: Code for the Print page.
        public async Task<IActionResult> Print(int printMeeting) 
        {
            var meeting = new Meeting();

            if (_context.Meetings == null)
            {
                return Problem("Entity set 'MvcMovieContext.Meetings' is null.");
            }

            // Get the meeting.
            foreach (Meeting m in _context.Meetings) 
            {
                if (m.Id == printMeeting) 
                {
                    meeting = m;
                }
            }

            // Get the Activites.

            var meetingActivities = new List<Activity>();

            foreach (Activity a in _context.Activities) 
            {
                if(a.MeetingID == printMeeting) 
                {
                    meetingActivities.Add(a);
                }
            }

            meetingActivities = meetingActivities.OrderBy(a => a.Order).ToList();

            // Add the title of the meeting.
            ViewData["MeetingWard"] = meeting.WardName;
            if (printMeeting == 0) 
            {
                ViewData["MeetingDate"] = "";
            }
            else 
            {
                ViewData["MeetingDate"] = meeting.Date.ToShortDateString();
            }
            ViewData["MeetingAddress"] = meeting.Address;

            // Create the meeting body, with dynamic views.
            // Convert the list into the strings we need to use.
            // This will also handle the order in which each thing will appear as well.
            var meetingActivitiesString = new List<string>();

            foreach (Activity ma in meetingActivities) 
            {
                // This varible is the character length. This is how long each string entry is going to be.
                int length = 100;

                    // Create the padding length.
                    if (ma.EventInfo != null)
                    {
                        int activityStringLen = ma.EventName.Length + ma.EventInfo.Length;

                        // Now generate the padding.
                        int padding = length - activityStringLen;

                        string stringPad = new string('.', padding);

                        // Now Create Finished String.
                        string finishedString = (ma.EventName + " " + stringPad + " " + ma.EventInfo + $"\n{ma.EventFooter}");

                        // Put them inside the list.
                        meetingActivitiesString.Add(finishedString);
                    }

                    // If they are null, have the footer be a combo with the EventName on a new line.
                    else 
                    {
                        // Create a string with the footer.
                        string finishedString = ($"{ma.EventName} \n{ma.EventFooter}");

                        meetingActivitiesString.Add(finishedString);
                    }
            }

            ViewBag.PrintList = meetingActivitiesString;

            PopulateMeetingsDropDownList();
            return View();
        }
    }
}
