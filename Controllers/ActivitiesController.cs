using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using SacramentMeetingPlanner.Data;
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

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Create([Bind("Id,EventName,EventInfo,EventFooter")] Activity activity, int selectedMeeting)
        {
            // Custom Valid check, if falied it returns to the activity.
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();

                // Now bind the Meeting to the Activity.
                //BindActivityToMeeting(activity, selectedMeeting);

                // Then return to the index.
                return RedirectToAction(nameof(Index));
            }
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
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,EventInfo,EventFooter")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
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
          return (_context.Activities?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // LOAD: Department info for the drop-down list.
        private void PopulateMeetingsDropDownList(object selectedDepartment = null)
        {
            var meetingsQuery = from m in _context.Meetings
                                   orderby m.WardName
                                   select m;
            ViewBag.MeetingsID = new SelectList(meetingsQuery.AsNoTracking(), "Id", "WardName", selectedDepartment);
        }

        // BIND: Bind the Activity to the Meeting using MeetingProgram.
        //private async void BindActivityToMeeting(Activity activity, int selectedMeeting) 
        //{
        //    // Create new object.
        //    var meetingProgram = new MeetingProgram();

        //    // Now Set the id values to equal their respected values.
        //    meetingProgram.MeetingID = selectedMeeting;
        //    meetingProgram.ActivityID = activity.Id;

        //    // Set the order based on a dictonary.
        //    string eventName = activity.EventName;
        //    meetingProgram.Order = _activitiesOrder[eventName];

        //    // Now add to the DB.
        //    _context.MeetingPrograms.Add(meetingProgram);
        //    await _context.SaveChangesAsync();
        //}

        // VALIDATE: Custom validation for the Create/Edit pages. This checks to see if we have duplicate activites in one
        // meeting.

    }
}
