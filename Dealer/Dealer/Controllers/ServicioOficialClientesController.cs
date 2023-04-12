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
    public class ServicioOficialClientesController : Controller
    {
        private readonly DEALERContext _context;

        public ServicioOficialClientesController(DEALERContext context)
        {
            _context = context;
        }

        // GET: ServicioOficialClientes
        public async Task<IActionResult> Index()
        {
              return _context.ServicioOficialClientes != null ? 
                          View(await _context.ServicioOficialClientes.ToListAsync()) :
                          Problem("Entity set 'DEALERContext.ServicioOficialClientes'  is null.");
        }

        // GET: ServicioOficialClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioOficialClientes == null)
            {
                return NotFound();
            }

            var servicioOficialCliente = await _context.ServicioOficialClientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (servicioOficialCliente == null)
            {
                return NotFound();
            }

            return View(servicioOficialCliente);
        }

        // GET: ServicioOficialClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioOficialClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdServicioOficial,NombreCliente,CedulaCliente,TelefonoCliente")] ServicioOficialCliente servicioOficialCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioOficialCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioOficialCliente);
        }

        // GET: ServicioOficialClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioOficialClientes == null)
            {
                return NotFound();
            }

            var servicioOficialCliente = await _context.ServicioOficialClientes.FindAsync(id);
            if (servicioOficialCliente == null)
            {
                return NotFound();
            }
            return View(servicioOficialCliente);
        }

        // POST: ServicioOficialClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,IdServicioOficial,NombreCliente,CedulaCliente,TelefonoCliente")] ServicioOficialCliente servicioOficialCliente)
        {
            if (id != servicioOficialCliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioOficialCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioOficialClienteExists(servicioOficialCliente.IdCliente))
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
            return View(servicioOficialCliente);
        }

        // GET: ServicioOficialClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioOficialClientes == null)
            {
                return NotFound();
            }

            var servicioOficialCliente = await _context.ServicioOficialClientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (servicioOficialCliente == null)
            {
                return NotFound();
            }

            return View(servicioOficialCliente);
        }

        // POST: ServicioOficialClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioOficialClientes == null)
            {
                return Problem("Entity set 'DEALERContext.ServicioOficialClientes'  is null.");
            }
            var servicioOficialCliente = await _context.ServicioOficialClientes.FindAsync(id);
            if (servicioOficialCliente != null)
            {
                _context.ServicioOficialClientes.Remove(servicioOficialCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioOficialClienteExists(int id)
        {
          return (_context.ServicioOficialClientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}
