using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IronDomeV2.Data;
using IronDomeV2.Models;

namespace IronDomeV2.Controllers
{
    public class CountermeasuresController : Controller
    {
        private readonly IronDomeV2Context _context;

        public CountermeasuresController(IronDomeV2Context context)
        {
            _context = context;
        }

        // GET: Countermeasures
        public async Task<IActionResult> Index()
        {
            var ironDomeV2Context = _context.Countermeasure.Include(c => c.Defender).Include(c => c.MethodOfAttack);
            return View(await ironDomeV2Context.ToListAsync());
        }

        // GET: Countermeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countermeasure = await _context.Countermeasure
                .Include(c => c.Defender)
                .Include(c => c.MethodOfAttack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countermeasure == null)
            {
                return NotFound();
            }

            return View(countermeasure);
        }

        // GET: Countermeasures/Create
        public IActionResult Create()
        {
            ViewData["DefenderId"] = new SelectList(_context.Defender, "Id", "Id");
            ViewData["MethodOfAttackId"] = new SelectList(_context.MethodOfAttack, "Id", "Id");
            return View();
        }

        // POST: Countermeasures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Range,DefenderId,Velocity,LaunchTime,MethodOfAttackId")] Countermeasure countermeasure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countermeasure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DefenderId"] = new SelectList(_context.Defender, "Id", "Id", countermeasure.DefenderId);
            ViewData["MethodOfAttackId"] = new SelectList(_context.MethodOfAttack, "Id", "Id", countermeasure.MethodOfAttackId);
            return View(countermeasure);
        }

        // GET: Countermeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countermeasure = await _context.Countermeasure.FindAsync(id);
            if (countermeasure == null)
            {
                return NotFound();
            }
            ViewData["DefenderId"] = new SelectList(_context.Defender, "Id", "Id", countermeasure.DefenderId);
            ViewData["MethodOfAttackId"] = new SelectList(_context.MethodOfAttack, "Id", "Id", countermeasure.MethodOfAttackId);
            return View(countermeasure);
        }

        // POST: Countermeasures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Range,DefenderId,Velocity,LaunchTime,MethodOfAttackId")] Countermeasure countermeasure)
        {
            if (id != countermeasure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countermeasure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountermeasureExists(countermeasure.Id))
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
            ViewData["DefenderId"] = new SelectList(_context.Defender, "Id", "Id", countermeasure.DefenderId);
            ViewData["MethodOfAttackId"] = new SelectList(_context.MethodOfAttack, "Id", "Id", countermeasure.MethodOfAttackId);
            return View(countermeasure);
        }

        // GET: Countermeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countermeasure = await _context.Countermeasure
                .Include(c => c.Defender)
                .Include(c => c.MethodOfAttack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countermeasure == null)
            {
                return NotFound();
            }

            return View(countermeasure);
        }

        // POST: Countermeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countermeasure = await _context.Countermeasure.FindAsync(id);
            if (countermeasure != null)
            {
                _context.Countermeasure.Remove(countermeasure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountermeasureExists(int id)
        {
            return _context.Countermeasure.Any(e => e.Id == id);
        }
    }
}
