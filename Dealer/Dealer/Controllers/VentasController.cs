using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dealer.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dealer.Controllers
{
    public class VentasController : Controller
    {
        private readonly DEALERContext _context;

        public VentasController(DEALERContext context)
        {
            _context = context;
        }


        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.Ventas.Include(v => v.IdClienteNavigation).Include(v => v.IdConcesionarioNavigation).Include(v => v.IdMarcaNavigation).Include(v => v.IdModeloNavigation).Include(v => v.IdServicioOficialNavigation).Include(v => v.IdVendedorNavigation).Include(v => v.MetodoPagoNavigation).Include(v => v.PrecioVehiculoPersonalizadoNavigation).Include(v => v.PrecioVehiculoStockNavigation).Include(v => v.VinVehiculoPersonalizadoNavigation).Include(v => v.VinVehiculoStockNavigation).Include(vs => vs.VinVehiculoStockNavigation.IdModeloNavigation);

            return View(await dEALERContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdConcesionarioNavigation)
                .Include(v => v.IdMarcaNavigation)
                .Include(v => v.IdModeloNavigation)
                .Include(v => v.IdServicioOficialNavigation)
                .Include(v => v.IdVendedorNavigation)
                .Include(v => v.MetodoPagoNavigation)
                .Include(v => v.PrecioVehiculoPersonalizadoNavigation)
                .Include(v => v.PrecioVehiculoStockNavigation)
                .Include(v => v.VinVehiculoPersonalizadoNavigation)
                .Include(v => v.VinVehiculoStockNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            // Obtén la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Agrega 6 meses y 15 días a la fecha actual
            DateTime fechaEntrega = fechaActual.AddMonths(6).AddDays(15);

            // Asigna la fecha resultante al modelo
            Venta venta = new Venta { FechaEntrega = fechaEntrega };

            ViewData["IdCliente"] = new SelectList(_context.ServicioOficialClientes, "IdCliente", "NombreCliente");
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "NombreConcesionario");
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca");
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo");
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "NombreServicioOficial");
            ViewData["IdVendedor"] = new SelectList(_context.ServicioOficialVendedores, "IdVendedor", "NombreVendedor");
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "MetodoPago1");
            ViewData["PrecioVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "Precio");
            ViewData["PrecioVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "Precio");
            ViewData["VinVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "Vin");
            ViewData["VinVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "Vin");
            return View(venta);
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,Fecha,Registro,IdConcesionario,IdServicioOficial,IdCliente,IdVendedor,VinVehiculoStock,VinVehiculoPersonalizado,IdMarca,IdModelo,PrecioVehiculoStock,PrecioVehiculoPersonalizado,FechaEntrega,MetodoPago")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.ServicioOficialClientes, "IdCliente", "IdCliente", venta.IdCliente);
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", venta.IdConcesionario);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", venta.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", venta.IdModelo);
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "IdServicioOficial", venta.IdServicioOficial);
            ViewData["IdVendedor"] = new SelectList(_context.ServicioOficialVendedores, "IdVendedor", "IdVendedor", venta.IdVendedor);
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", venta.MetodoPago);
            ViewData["PrecioVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "IdConstruccionVehiculo", venta.PrecioVehiculoPersonalizado);
            ViewData["PrecioVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "IdVehiculoStock", venta.PrecioVehiculoStock);
            ViewData["VinVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "IdConstruccionVehiculo", venta.VinVehiculoPersonalizado);
            ViewData["VinVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "IdVehiculoStock", venta.VinVehiculoStock);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.ServicioOficialClientes, "IdCliente", "IdCliente", venta.IdCliente);
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", venta.IdConcesionario);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", venta.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", venta.IdModelo);
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "IdServicioOficial", venta.IdServicioOficial);
            ViewData["IdVendedor"] = new SelectList(_context.ServicioOficialVendedores, "IdVendedor", "IdVendedor", venta.IdVendedor);
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", venta.MetodoPago);
            ViewData["PrecioVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "IdConstruccionVehiculo", venta.PrecioVehiculoPersonalizado);
            ViewData["PrecioVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "IdVehiculoStock", venta.PrecioVehiculoStock);
            ViewData["VinVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "IdConstruccionVehiculo", venta.VinVehiculoPersonalizado);
            ViewData["VinVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "IdVehiculoStock", venta.VinVehiculoStock);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,Fecha,Registro,IdConcesionario,IdServicioOficial,IdCliente,IdVendedor,VinVehiculoStock,VinVehiculoPersonalizado,IdMarca,IdModelo,PrecioVehiculoStock,PrecioVehiculoPersonalizado,FechaEntrega,MetodoPago")] Venta venta)
        {
            if (id != venta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.IdVenta))
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
            ViewData["IdCliente"] = new SelectList(_context.ServicioOficialClientes, "IdCliente", "IdCliente", venta.IdCliente);
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", venta.IdConcesionario);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", venta.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", venta.IdModelo);
            ViewData["IdServicioOficial"] = new SelectList(_context.ServicioOficials, "IdServicioOficial", "IdServicioOficial", venta.IdServicioOficial);
            ViewData["IdVendedor"] = new SelectList(_context.ServicioOficialVendedores, "IdVendedor", "IdVendedor", venta.IdVendedor);
            ViewData["MetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", venta.MetodoPago);
            ViewData["PrecioVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "IdConstruccionVehiculo", venta.PrecioVehiculoPersonalizado);
            ViewData["PrecioVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "IdVehiculoStock", venta.PrecioVehiculoStock);
            ViewData["VinVehiculoPersonalizado"] = new SelectList(_context.VehiculoPersonalizados, "IdConstruccionVehiculo", "IdConstruccionVehiculo", venta.VinVehiculoPersonalizado);
            ViewData["VinVehiculoStock"] = new SelectList(_context.VehiculosStocks, "IdVehiculoStock", "IdVehiculoStock", venta.VinVehiculoStock);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdConcesionarioNavigation)
                .Include(v => v.IdMarcaNavigation)
                .Include(v => v.IdModeloNavigation)
                .Include(v => v.IdServicioOficialNavigation)
                .Include(v => v.IdVendedorNavigation)
                .Include(v => v.MetodoPagoNavigation)
                .Include(v => v.PrecioVehiculoPersonalizadoNavigation)
                .Include(v => v.PrecioVehiculoStockNavigation)
                .Include(v => v.VinVehiculoPersonalizadoNavigation)
                .Include(v => v.VinVehiculoStockNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ventas == null)
            {
                return Problem("Entity set 'DEALERContext.Ventas'  is null.");
            }
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return (_context.Ventas?.Any(e => e.IdVenta == id)).GetValueOrDefault();
        }
    }
}
