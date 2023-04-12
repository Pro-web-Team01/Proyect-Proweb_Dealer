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
    public class ColorExteriorsController : Controller
    {
        private readonly DEALERContext _context;

        public ColorExteriorsController(DEALERContext context)
        {
            _context = context;
        }

        // GET: ColorExteriors
        public async Task<IActionResult> Index()
        {
              return _context.ColorExteriors != null ? 
                          View(await _context.ColorExteriors.ToListAsync()) :
                          Problem("Entity set 'DEALERContext.ColorExteriors'  is null.");
        }

        // GET: ColorExteriors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ColorExteriors == null)
            {
                return NotFound();
            }

            var colorExterior = await _context.ColorExteriors
                .FirstOrDefaultAsync(m => m.IdColorExterior == id);
            if (colorExterior == null)
            {
                return NotFound();
            }

            return View(colorExterior);
        }

        // GET: ColorExteriors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColorExteriors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdColorExterior,ColorExterior1,PrecioColorExterior,ColorHex")] ColorExterior colorExterior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorExterior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorExterior);
        }

        // GET: ColorExteriors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ColorExteriors == null)
            {
                return NotFound();
            }

            var colorExterior = await _context.ColorExteriors.FindAsync(id);
            if (colorExterior == null)
            {
                return NotFound();
            }
            return View(colorExterior);
        }

        // POST: ColorExteriors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdColorExterior,ColorExterior1,PrecioColorExterior,ColorHex")] ColorExterior colorExterior)
        {
            if (id != colorExterior.IdColorExterior)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colorExterior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExteriorExists(colorExterior.IdColorExterior))
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
            return View(colorExterior);
        }

        // GET: ColorExteriors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ColorExteriors == null)
            {
                return NotFound();
            }

            var colorExterior = await _context.ColorExteriors
                .FirstOrDefaultAsync(m => m.IdColorExterior == id);
            if (colorExterior == null)
            {
                return NotFound();
            }

            return View(colorExterior);
        }

        // POST: ColorExteriors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ColorExteriors == null)
            {
                return Problem("Entity set 'DEALERContext.ColorExteriors'  is null.");
            }
            var colorExterior = await _context.ColorExteriors.FindAsync(id);
            if (colorExterior != null)
            {
                _context.ColorExteriors.Remove(colorExterior);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorExteriorExists(int id)
        {
          return (_context.ColorExteriors?.Any(e => e.IdColorExterior == id)).GetValueOrDefault();
        }
    }
}
