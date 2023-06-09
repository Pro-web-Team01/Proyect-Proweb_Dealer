﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dealer.Models;

namespace Dealer.Controllers
{
    public class VehiculosStocksController : Controller
    {
        private readonly DEALERContext _context;

        public VehiculosStocksController(DEALERContext context)
        {
            _context = context;
        }

        // GET: VehiculosStocks
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.VehiculosStocks.Include(v => v.ColorExteriorNavigation).Include(v => v.ColorInteriorNavigation).Include(v => v.CondicionNavigation).Include(v => v.IdMarcaNavigation).Include(v => v.IdModeloNavigation);
            return View(await dEALERContext.ToListAsync());
        }

        // GET: VehiculosStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehiculosStocks == null)
            {
                return NotFound();
            }

            var vehiculosStock = await _context.VehiculosStocks
                .Include(v => v.ColorExteriorNavigation)
                .Include(v => v.ColorInteriorNavigation)
                .Include(v => v.CondicionNavigation)
                .Include(v => v.IdMarcaNavigation)
                .Include(v => v.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdVehiculoStock == id);
            if (vehiculosStock == null)
            {
                return NotFound();
            }

            return View(vehiculosStock);
        }

        // GET: VehiculosStocks/Create
        public IActionResult Create()
        {
            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "IdColorExterior");
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "IdColorInterior");
            ViewData["Condicion"] = new SelectList(_context.CondicionVehiculos, "IdCondicion", "IdCondicion");
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca");
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo");
            return View();
        }

        // POST: VehiculosStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculoStock,IdMarca,IdModelo,Vin,ColorExterior,ColorInterior,Anio,DescripcionEquipamientoExtra,Precio,Img,Condicion")] VehiculosStock vehiculosStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculosStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "IdColorExterior", vehiculosStock.ColorExterior);
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "IdColorInterior", vehiculosStock.ColorInterior);
            ViewData["Condicion"] = new SelectList(_context.CondicionVehiculos, "IdCondicion", "IdCondicion", vehiculosStock.Condicion);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", vehiculosStock.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", vehiculosStock.IdModelo);
            return View(vehiculosStock);
        }

        // GET: VehiculosStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehiculosStocks == null)
            {
                return NotFound();
            }

            var vehiculosStock = await _context.VehiculosStocks.FindAsync(id);
            if (vehiculosStock == null)
            {
                return NotFound();
            }
            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "IdColorExterior", vehiculosStock.ColorExterior);
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "IdColorInterior", vehiculosStock.ColorInterior);
            ViewData["Condicion"] = new SelectList(_context.CondicionVehiculos, "IdCondicion", "IdCondicion", vehiculosStock.Condicion);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", vehiculosStock.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", vehiculosStock.IdModelo);
            return View(vehiculosStock);
        }

        // POST: VehiculosStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculoStock,IdMarca,IdModelo,Vin,ColorExterior,ColorInterior,Anio,DescripcionEquipamientoExtra,Precio,Img,Condicion")] VehiculosStock vehiculosStock)
        {
            if (id != vehiculosStock.IdVehiculoStock)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculosStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosStockExists(vehiculosStock.IdVehiculoStock))
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
            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "IdColorExterior", vehiculosStock.ColorExterior);
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "IdColorInterior", vehiculosStock.ColorInterior);
            ViewData["Condicion"] = new SelectList(_context.CondicionVehiculos, "IdCondicion", "IdCondicion", vehiculosStock.Condicion);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", vehiculosStock.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", vehiculosStock.IdModelo);
            return View(vehiculosStock);
        }

        // GET: VehiculosStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehiculosStocks == null)
            {
                return NotFound();
            }

            var vehiculosStock = await _context.VehiculosStocks
                .Include(v => v.ColorExteriorNavigation)
                .Include(v => v.ColorInteriorNavigation)
                .Include(v => v.CondicionNavigation)
                .Include(v => v.IdMarcaNavigation)
                .Include(v => v.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdVehiculoStock == id);
            if (vehiculosStock == null)
            {
                return NotFound();
            }

            return View(vehiculosStock);
        }

        // POST: VehiculosStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehiculosStocks == null)
            {
                return Problem("Entity set 'DEALERContext.VehiculosStocks'  is null.");
            }
            var vehiculosStock = await _context.VehiculosStocks.FindAsync(id);
            if (vehiculosStock != null)
            {
                _context.VehiculosStocks.Remove(vehiculosStock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosStockExists(int id)
        {
          return (_context.VehiculosStocks?.Any(e => e.IdVehiculoStock == id)).GetValueOrDefault();
        }
    }
}
