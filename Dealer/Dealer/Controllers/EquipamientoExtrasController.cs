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
    public class EquipamientoExtrasController : Controller
    {
        private readonly DEALERContext _context;

        public EquipamientoExtrasController(DEALERContext context)
        {
            _context = context;
        }

        // GET: EquipamientoExtras
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.EquipamientoExtras.Include(e => e.IdModeloNavigation);
            return View(await dEALERContext.ToListAsync());
        }

        // GET: EquipamientoExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipamientoExtras == null)
            {
                return NotFound();
            }

            var equipamientoExtra = await _context.EquipamientoExtras
                .Include(e => e.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipamientoExtra == id);
            if (equipamientoExtra == null)
            {
                return NotFound();
            }

            return View(equipamientoExtra);
        }

        // GET: EquipamientoExtras/Create
        public IActionResult Create()
        {
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo");
            return View();
        }

        // POST: EquipamientoExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipamientoExtra,IdModelo,NombreEquipamientoExtra,Precio,Img")] EquipamientoExtra equipamientoExtra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamientoExtra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", equipamientoExtra.IdModelo);
            return View(equipamientoExtra);
        }

        // GET: EquipamientoExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipamientoExtras == null)
            {
                return NotFound();
            }

            var equipamientoExtra = await _context.EquipamientoExtras.FindAsync(id);
            if (equipamientoExtra == null)
            {
                return NotFound();
            }
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo", equipamientoExtra.IdModelo);
            return View(equipamientoExtra);
        }

        // POST: EquipamientoExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipamientoExtra,IdModelo,NombreEquipamientoExtra,Precio,Img")] EquipamientoExtra equipamientoExtra)
        {
            if (id != equipamientoExtra.IdEquipamientoExtra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamientoExtra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamientoExtraExists(equipamientoExtra.IdEquipamientoExtra))
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
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", equipamientoExtra.IdModelo);
            return View(equipamientoExtra);
        }

        // GET: EquipamientoExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipamientoExtras == null)
            {
                return NotFound();
            }

            var equipamientoExtra = await _context.EquipamientoExtras
                .Include(e => e.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipamientoExtra == id);
            if (equipamientoExtra == null)
            {
                return NotFound();
            }

            return View(equipamientoExtra);
        }

        // POST: EquipamientoExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipamientoExtras == null)
            {
                return Problem("Entity set 'DEALERContext.EquipamientoExtras'  is null.");
            }
            var equipamientoExtra = await _context.EquipamientoExtras.FindAsync(id);
            if (equipamientoExtra != null)
            {
                _context.EquipamientoExtras.Remove(equipamientoExtra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamientoExtraExists(int id)
        {
          return (_context.EquipamientoExtras?.Any(e => e.IdEquipamientoExtra == id)).GetValueOrDefault();
        }
    }
}
