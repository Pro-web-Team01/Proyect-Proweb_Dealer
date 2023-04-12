using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dealer.Models;

namespace Dealer.Controllers
{
    public class ColorInteriorsController : Controller
    {
        private readonly DEALERContext _context;

        public ColorInteriorsController(DEALERContext context)
        {
            _context = context;
        }

        // GET: ColorInteriors
        public async Task<IActionResult> Index()
        {
              return _context.ColorInteriors != null ? 
                          View(await _context.ColorInteriors.ToListAsync()) :
                          Problem("Entity set 'DEALERContext.ColorInteriors'  is null.");
        }

        // GET: ColorInteriors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ColorInteriors == null)
            {
                return NotFound();
            }

            var colorInterior = await _context.ColorInteriors
                .FirstOrDefaultAsync(m => m.IdColorInterior == id);
            if (colorInterior == null)
            {
                return NotFound();
            }

            return View(colorInterior);
        }

        // GET: ColorInteriors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColorInteriors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdColorInterior,ColorInterior1,PrecioColorInterior")] ColorInterior colorInterior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorInterior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorInterior);
        }

        // GET: ColorInteriors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ColorInteriors == null)
            {
                return NotFound();
            }

            var colorInterior = await _context.ColorInteriors.FindAsync(id);
            if (colorInterior == null)
            {
                return NotFound();
            }
            return View(colorInterior);
        }

        // POST: ColorInteriors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdColorInterior,ColorInterior1,PrecioColorInterior")] ColorInterior colorInterior)
        {
            if (id != colorInterior.IdColorInterior)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colorInterior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorInteriorExists(colorInterior.IdColorInterior))
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
            return View(colorInterior);
        }

        // GET: ColorInteriors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ColorInteriors == null)
            {
                return NotFound();
            }

            var colorInterior = await _context.ColorInteriors
                .FirstOrDefaultAsync(m => m.IdColorInterior == id);
            if (colorInterior == null)
            {
                return NotFound();
            }

            return View(colorInterior);
        }

        // POST: ColorInteriors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ColorInteriors == null)
            {
                return Problem("Entity set 'DEALERContext.ColorInteriors'  is null.");
            }
            var colorInterior = await _context.ColorInteriors.FindAsync(id);
            if (colorInterior != null)
            {
                _context.ColorInteriors.Remove(colorInterior);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorInteriorExists(int id)
        {
          return (_context.ColorInteriors?.Any(e => e.IdColorInterior == id)).GetValueOrDefault();
        }
    }
}
