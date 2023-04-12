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
    public class ServicioOficialsController : Controller
    {
        private readonly DEALERContext _context;

        public ServicioOficialsController(DEALERContext context)
        {
            _context = context;
        }

        // GET: ServicioOficials
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.ServicioOficials.Include(s => s.IdConcesionarioNavigation);
            return View(await dEALERContext.ToListAsync());
        }

        // GET: ServicioOficials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioOficials == null)
            {
                return NotFound();
            }

            var servicioOficial = await _context.ServicioOficials
                .Include(s => s.IdConcesionarioNavigation)
                .FirstOrDefaultAsync(m => m.IdServicioOficial == id);
            if (servicioOficial == null)
            {
                return NotFound();
            }

            return View(servicioOficial);
        }

        // GET: ServicioOficials/Create
        public IActionResult Create()
        {
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "NombreConcesionario");
            return View();
        }

        // POST: ServicioOficials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicioOficial,IdConcesionario,NombreServicioOficial,DomicilioServicioOficial,RncServicioOficial,ImgConcesionario")] ServicioOficial servicioOficial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioOficial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", servicioOficial.IdConcesionario);
            return View(servicioOficial);
        }

        // GET: ServicioOficials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioOficials == null)
            {
                return NotFound();
            }

            var servicioOficial = await _context.ServicioOficials.FindAsync(id);
            if (servicioOficial == null)
            {
                return NotFound();
            }
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "NombreConcesionario", servicioOficial.IdConcesionario);
            return View(servicioOficial);
        }

        // POST: ServicioOficials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicioOficial,IdConcesionario,NombreServicioOficial,DomicilioServicioOficial,RncServicioOficial,ImgConcesionario")] ServicioOficial servicioOficial)
        {
            if (id != servicioOficial.IdServicioOficial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioOficial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioOficialExists(servicioOficial.IdServicioOficial))
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
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", servicioOficial.IdConcesionario);
            return View(servicioOficial);
        }

        // GET: ServicioOficials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioOficials == null)
            {
                return NotFound();
            }

            var servicioOficial = await _context.ServicioOficials
                .Include(s => s.IdConcesionarioNavigation)
                .FirstOrDefaultAsync(m => m.IdServicioOficial == id);
            if (servicioOficial == null)
            {
                return NotFound();
            }

            return View(servicioOficial);
        }

        // POST: ServicioOficials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioOficials == null)
            {
                return Problem("Entity set 'DEALERContext.ServicioOficials'  is null.");
            }
            var servicioOficial = await _context.ServicioOficials.FindAsync(id);
            if (servicioOficial != null)
            {
                _context.ServicioOficials.Remove(servicioOficial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioOficialExists(int id)
        {
          return (_context.ServicioOficials?.Any(e => e.IdServicioOficial == id)).GetValueOrDefault();
        }
    }
}
