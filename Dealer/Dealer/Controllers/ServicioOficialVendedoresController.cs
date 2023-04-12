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
    public class ServicioOficialVendedoresController : Controller
    {
        private readonly DEALERContext _context;

        public ServicioOficialVendedoresController(DEALERContext context)
        {
            _context = context;
        }

        // GET: ServicioOficialVendedores
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.ServicioOficialVendedores.Include(s => s.IdServicioOficialNavigation);
            return View(await dEALERContext.ToListAsync());
        }

        // GET: ServicioOficialVendedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioOficialVendedores == null)
            {
                return NotFound();
            }

            var servicioOficialVendedore = await _context.ServicioOficialVendedores
                .Include(s => s.IdServicioOficialNavigation)
                .FirstOrDefaultAsync(m => m.IdVendedor == id);
            if (servicioOficialVendedore == null)
            {
                return NotFound();
            }

            return View(servicioOficialVendedore);
        }

        // GET: ServicioOficialVendedores/Create
        public IActionResult Create()
        {
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "NombreServicioOficial");
            return View();
        }

        // POST: ServicioOficialVendedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVendedor,IdServicioOficial,NombreVendedor,CedulaVendedor,Domicilio")] ServicioOficialVendedore servicioOficialVendedore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioOficialVendedore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "IdServicioOficial", servicioOficialVendedore.IdServicioOficial);
            return View(servicioOficialVendedore);
        }

        // GET: ServicioOficialVendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioOficialVendedores == null)
            {
                return NotFound();
            }

            var servicioOficialVendedore = await _context.ServicioOficialVendedores.FindAsync(id);
            if (servicioOficialVendedore == null)
            {
                return NotFound();
            }
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "NombreServicioOficial", servicioOficialVendedore.IdServicioOficial);
            return View(servicioOficialVendedore);
        }

        // POST: ServicioOficialVendedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVendedor,IdServicioOficial,NombreVendedor,CedulaVendedor,Domicilio")] ServicioOficialVendedore servicioOficialVendedore)
        {
            if (id != servicioOficialVendedore.IdVendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioOficialVendedore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioOficialVendedoreExists(servicioOficialVendedore.IdVendedor))
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
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "IdServicioOficial", servicioOficialVendedore.IdServicioOficial);
            return View(servicioOficialVendedore);
        }

        // GET: ServicioOficialVendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioOficialVendedores == null)
            {
                return NotFound();
            }

            var servicioOficialVendedore = await _context.ServicioOficialVendedores
                .Include(s => s.IdServicioOficialNavigation)
                .FirstOrDefaultAsync(m => m.IdVendedor == id);
            if (servicioOficialVendedore == null)
            {
                return NotFound();
            }

            return View(servicioOficialVendedore);
        }

        // POST: ServicioOficialVendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioOficialVendedores == null)
            {
                return Problem("Entity set 'DEALERContext.ServicioOficialVendedores'  is null.");
            }
            var servicioOficialVendedore = await _context.ServicioOficialVendedores.FindAsync(id);
            if (servicioOficialVendedore != null)
            {
                _context.ServicioOficialVendedores.Remove(servicioOficialVendedore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioOficialVendedoreExists(int id)
        {
          return (_context.ServicioOficialVendedores?.Any(e => e.IdVendedor == id)).GetValueOrDefault();
        }
    }
}
