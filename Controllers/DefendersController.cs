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
    public class DefendersController : Controller
    {
        private readonly IronDomeV2Context _context;

        public DefendersController(IronDomeV2Context context)
        {
            _context = context;
        }

        // GET: Defenders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Defender.ToListAsync());
        }

        // GET: Defenders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defender = await _context.Defender
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defender == null)
            {
                return NotFound();
            }

            return View(defender);
        }

        // GET: Defenders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Defenders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Defender defender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defender);
        }

        // GET: Defenders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defender = await _context.Defender.FindAsync(id);
            if (defender == null)
            {
                return NotFound();
            }
            return View(defender);
        }

        // POST: Defenders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Defender defender)
        {
            if (id != defender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefenderExists(defender.Id))
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
            return View(defender);
        }

        // GET: Defenders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defender = await _context.Defender
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defender == null)
            {
                return NotFound();
            }

            return View(defender);
        }

        // POST: Defenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defender = await _context.Defender.FindAsync(id);
            if (defender != null)
            {
                _context.Defender.Remove(defender);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefenderExists(int id)
        {
            return _context.Defender.Any(e => e.Id == id);
        }
    }
}
