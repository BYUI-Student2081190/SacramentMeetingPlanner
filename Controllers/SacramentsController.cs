using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SacramentsController : Controller
    {
        private readonly SacramentContext _context;

        public SacramentsController(SacramentContext context)
        {
            _context = context;
        }

        // GET: Sacraments
        public async Task<IActionResult> Index()
        {
            var sacramentContext = _context.Sacraments.Include(s => s.Hymn).Include(s => s.People);
            return View(await sacramentContext.ToListAsync());
        }

        // GET: Sacraments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sacraments == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacraments
                .Include(s => s.Hymn)
                .Include(s => s.People)
                .FirstOrDefaultAsync(m => m.SacramentId == id);
            if (sacrament == null)
            {
                return NotFound();
            }

            return View(sacrament);
        }

        // GET: Sacraments/Create
        public IActionResult Create()
        {
            ViewData["HymnId"] = new SelectList(_context.Hymns, "HymnId", "HymnId");
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "PeopleId", "PeopleId");
            return View();
        }

        // POST: Sacraments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SacramentId,PeopleId,HymnId,Topic,Date")] Sacrament sacrament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sacrament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HymnId"] = new SelectList(_context.Hymns, "HymnId", "HymnId", sacrament.HymnId);
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "PeopleId", "PeopleId", sacrament.PeopleId);
            return View(sacrament);
        }

        // GET: Sacraments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sacraments == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacraments.FindAsync(id);
            if (sacrament == null)
            {
                return NotFound();
            }
            ViewData["HymnId"] = new SelectList(_context.Hymns, "HymnId", "HymnId", sacrament.HymnId);
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "PeopleId", "PeopleId", sacrament.PeopleId);
            return View(sacrament);
        }

        // POST: Sacraments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SacramentId,PeopleId,HymnId,Topic,Date")] Sacrament sacrament)
        {
            if (id != sacrament.SacramentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacrament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentExists(sacrament.SacramentId))
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
            ViewData["HymnId"] = new SelectList(_context.Hymns, "HymnId", "HymnId", sacrament.HymnId);
            ViewData["PeopleId"] = new SelectList(_context.Peoples, "PeopleId", "PeopleId", sacrament.PeopleId);
            return View(sacrament);
        }

        // GET: Sacraments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sacraments == null)
            {
                return NotFound();
            }

            var sacrament = await _context.Sacraments
                .Include(s => s.Hymn)
                .Include(s => s.People)
                .FirstOrDefaultAsync(m => m.SacramentId == id);
            if (sacrament == null)
            {
                return NotFound();
            }

            return View(sacrament);
        }

        // POST: Sacraments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sacraments == null)
            {
                return Problem("Entity set 'SacramentContext.Sacraments'  is null.");
            }
            var sacrament = await _context.Sacraments.FindAsync(id);
            if (sacrament != null)
            {
                _context.Sacraments.Remove(sacrament);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentExists(int id)
        {
          return (_context.Sacraments?.Any(e => e.SacramentId == id)).GetValueOrDefault();
        }
    }
}
