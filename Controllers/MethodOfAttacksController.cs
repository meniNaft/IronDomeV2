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
    public class MethodOfAttacksController : Controller
    {
        private readonly IronDomeV2Context _context;

        public MethodOfAttacksController(IronDomeV2Context context)
        {
            _context = context;
        }

        // GET: MethodOfAttacks
        public async Task<IActionResult> Index()
        {
            var ironDomeV2Context = _context.MethodOfAttack.Include(m => m.Volley);
            return View(await ironDomeV2Context.ToListAsync());
        }

        // GET: MethodOfAttacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodOfAttack = await _context.MethodOfAttack
                .Include(m => m.Volley)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodOfAttack == null)
            {
                return NotFound();
            }

            return View(methodOfAttack);
        }

        // GET: MethodOfAttacks/Create
        public IActionResult Create()
        {
            ViewData["VolleyId"] = new SelectList(_context.Volley, "Id", "Id");
            return View();
        }

        // POST: MethodOfAttacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Range,Velocity,Distance,TimeOfLaunch,VolleyId")] MethodOfAttack methodOfAttack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodOfAttack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VolleyId"] = new SelectList(_context.Volley, "Id", "Id", methodOfAttack.VolleyId);
            return View(methodOfAttack);
        }

        // GET: MethodOfAttacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodOfAttack = await _context.MethodOfAttack.FindAsync(id);
            if (methodOfAttack == null)
            {
                return NotFound();
            }
            ViewData["VolleyId"] = new SelectList(_context.Volley, "Id", "Id", methodOfAttack.VolleyId);
            return View(methodOfAttack);
        }

        // POST: MethodOfAttacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Range,Velocity,Distance,TimeOfLaunch,VolleyId")] MethodOfAttack methodOfAttack)
        {
            if (id != methodOfAttack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodOfAttack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodOfAttackExists(methodOfAttack.Id))
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
            ViewData["VolleyId"] = new SelectList(_context.Volley, "Id", "Id", methodOfAttack.VolleyId);
            return View(methodOfAttack);
        }

        // GET: MethodOfAttacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodOfAttack = await _context.MethodOfAttack
                .Include(m => m.Volley)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodOfAttack == null)
            {
                return NotFound();
            }

            return View(methodOfAttack);
        }

        // POST: MethodOfAttacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var methodOfAttack = await _context.MethodOfAttack.FindAsync(id);
            if (methodOfAttack != null)
            {
                _context.MethodOfAttack.Remove(methodOfAttack);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodOfAttackExists(int id)
        {
            return _context.MethodOfAttack.Any(e => e.Id == id);
        }
    }
}
