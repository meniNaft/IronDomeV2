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
    public class MethodOfAttackTemplatesController : Controller
    {
        private readonly IronDomeV2Context _context;

        public MethodOfAttackTemplatesController(IronDomeV2Context context)
        {
            _context = context;
        }

        // GET: MethodOfAttackTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.MethodOfAttackTemplate.ToListAsync());
        }

        // GET: MethodOfAttackTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodOfAttackTemplate = await _context.MethodOfAttackTemplate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodOfAttackTemplate == null)
            {
                return NotFound();
            }

            return View(methodOfAttackTemplate);
        }

        // GET: MethodOfAttackTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MethodOfAttackTemplates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Range,Velocity")] MethodOfAttackTemplate methodOfAttackTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodOfAttackTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(methodOfAttackTemplate);
        }

        // GET: MethodOfAttackTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodOfAttackTemplate = await _context.MethodOfAttackTemplate.FindAsync(id);
            if (methodOfAttackTemplate == null)
            {
                return NotFound();
            }
            return View(methodOfAttackTemplate);
        }

        // POST: MethodOfAttackTemplates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Range,Velocity")] MethodOfAttackTemplate methodOfAttackTemplate)
        {
            if (id != methodOfAttackTemplate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodOfAttackTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodOfAttackTemplateExists(methodOfAttackTemplate.Id))
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
            return View(methodOfAttackTemplate);
        }

        // GET: MethodOfAttackTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodOfAttackTemplate = await _context.MethodOfAttackTemplate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodOfAttackTemplate == null)
            {
                return NotFound();
            }

            return View(methodOfAttackTemplate);
        }

        // POST: MethodOfAttackTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var methodOfAttackTemplate = await _context.MethodOfAttackTemplate.FindAsync(id);
            if (methodOfAttackTemplate != null)
            {
                _context.MethodOfAttackTemplate.Remove(methodOfAttackTemplate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodOfAttackTemplateExists(int id)
        {
            return _context.MethodOfAttackTemplate.Any(e => e.Id == id);
        }
    }
}
