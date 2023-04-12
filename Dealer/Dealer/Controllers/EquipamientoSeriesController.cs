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
    public class EquipamientoSeriesController : Controller
    {
        private readonly DEALERContext _context;

        public EquipamientoSeriesController(DEALERContext context)
        {
            _context = context;
        }

        // GET: EquipamientoSeries
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.EquipamientoSeries.Include(e => e.IdModeloNavigation);
            return View(await dEALERContext.ToListAsync());
        }

        // GET: EquipamientoSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipamientoSeries == null)
            {
                return NotFound();
            }

            var equipamientoSerie = await _context.EquipamientoSeries
                .Include(e => e.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipamientoSerie == id);
            if (equipamientoSerie == null)
            {
                return NotFound();
            }

            return View(equipamientoSerie);
        }

        // GET: EquipamientoSeries/Create
        public IActionResult Create()
        {
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo");
            return View();
        }

        // POST: EquipamientoSeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipamientoSerie,IdModelo,NombreEquipamientoExtra")] EquipamientoSerie equipamientoSerie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamientoSerie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", equipamientoSerie.IdModelo);
            return View(equipamientoSerie);
        }

        // GET: EquipamientoSeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipamientoSeries == null)
            {
                return NotFound();
            }

            var equipamientoSerie = await _context.EquipamientoSeries.FindAsync(id);
            if (equipamientoSerie == null)
            {
                return NotFound();
            }
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo", equipamientoSerie.IdModelo);
            return View(equipamientoSerie);
        }

        // POST: EquipamientoSeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipamientoSerie,IdModelo,NombreEquipamientoExtra")] EquipamientoSerie equipamientoSerie)
        {
            if (id != equipamientoSerie.IdEquipamientoSerie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamientoSerie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamientoSerieExists(equipamientoSerie.IdEquipamientoSerie))
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
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", equipamientoSerie.IdModelo);
            return View(equipamientoSerie);
        }

        // GET: EquipamientoSeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipamientoSeries == null)
            {
                return NotFound();
            }

            var equipamientoSerie = await _context.EquipamientoSeries
                .Include(e => e.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipamientoSerie == id);
            if (equipamientoSerie == null)
            {
                return NotFound();
            }

            return View(equipamientoSerie);
        }

        // POST: EquipamientoSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipamientoSeries == null)
            {
                return Problem("Entity set 'DEALERContext.EquipamientoSeries'  is null.");
            }
            var equipamientoSerie = await _context.EquipamientoSeries.FindAsync(id);
            if (equipamientoSerie != null)
            {
                _context.EquipamientoSeries.Remove(equipamientoSerie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamientoSerieExists(int id)
        {
          return (_context.EquipamientoSeries?.Any(e => e.IdEquipamientoSerie == id)).GetValueOrDefault();
        }
    }
}
