using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dealer.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Dealer.Controllers
{
    public class VehiculoPersonalizadosController : Controller
    {
        private readonly DEALERContext _context;

        public VehiculoPersonalizadosController(DEALERContext context)
        {
            _context = context;
        }

        // GET: VehiculoPersonalizados
        public async Task<IActionResult> Index()
        {
            var dEALERContext = _context.VehiculoPersonalizados.Include(v => v.ColorExteriorNavigation).Include(v => v.ColorInteriorNavigation).Include(v => v.Extra01Navigation).Include(v => v.Extra02Navigation).Include(v => v.Extra03Navigation).Include(v => v.Extra04Navigation).Include(v => v.Extra05Navigation).Include(v => v.Extra06Navigation).Include(v => v.Extra07Navigation).Include(v => v.Extra08Navigation).Include(v => v.Extra09Navigation).Include(v => v.Extra10Navigation).Include(v => v.Extra11Navigation).Include(v => v.Extra12Navigation).Include(v => v.Extra13Navigation).Include(v => v.Extra14Navigation).Include(v => v.Extra15Navigation).Include(v => v.Extra16Navigation).Include(v => v.Extra17Navigation).Include(v => v.Extra18Navigation).Include(v => v.Extra19Navigation).Include(v => v.Extra20Navigation).Include(v => v.IdMarcaNavigation).Include(v => v.IdModeloNavigation);
            return View(await dEALERContext.ToListAsync());
        }

        // GET: VehiculoPersonalizados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehiculoPersonalizados == null)
            {
                return NotFound();
            }

            var vehiculoPersonalizado = await _context.VehiculoPersonalizados
                .Include(v => v.ColorExteriorNavigation)
                .Include(v => v.ColorInteriorNavigation)
                .Include(v => v.Extra01Navigation)
                .Include(v => v.Extra02Navigation)
                .Include(v => v.Extra03Navigation)
                .Include(v => v.Extra04Navigation)
                .Include(v => v.Extra05Navigation)
                .Include(v => v.Extra06Navigation)
                .Include(v => v.Extra07Navigation)
                .Include(v => v.Extra08Navigation)
                .Include(v => v.Extra09Navigation)
                .Include(v => v.Extra10Navigation)
                .Include(v => v.Extra11Navigation)
                .Include(v => v.Extra12Navigation)
                .Include(v => v.Extra13Navigation)
                .Include(v => v.Extra14Navigation)
                .Include(v => v.Extra15Navigation)
                .Include(v => v.Extra16Navigation)
                .Include(v => v.Extra17Navigation)
                .Include(v => v.Extra18Navigation)
                .Include(v => v.Extra19Navigation)
                .Include(v => v.Extra20Navigation)
                .Include(v => v.IdMarcaNavigation)
                .Include(v => v.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdConstruccionVehiculo == id);
            if (vehiculoPersonalizado == null)
            {
                return NotFound();
            }

            return View(vehiculoPersonalizado);
        }

        // GET: VehiculoPersonalizados/Create
        public IActionResult Create(int? idModelo)
        {
            /*ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "ColorExterior1");*/
            /*ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "ColorInterior1");*/
            /*            ViewData["Extra01"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra02"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra03"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra04"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra05"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra06"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra07"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra08"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra09"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra10"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra11"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra12"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra13"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra14"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra15"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra16"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra17"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra18"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra19"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["Extra20"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra");
                        ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca");*/

            /*ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo");*/

            List<colorPrecioViewModel> precioColorExteriorList = _context.ColorExteriors.Select(v => new colorPrecioViewModel
            {
                IdColor = v.IdColorExterior,
                Colorprecio = v.ColorExterior1 + " - " + "US$ " + v.PrecioColorExterior
            }).ToList();


            List<colorPrecioViewModel> precioColorInteriorList = _context.ColorInteriors.Select(v => new colorPrecioViewModel
            {
                IdColor = v.IdColorInterior,
                Colorprecio = v.ColorInterior1 + " - " + "US$ " + v.PrecioColorInterior
            }).ToList();


            List<extraPrecioViewModel> extra1List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra2List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra3List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra4List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra5List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra6List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra7List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra8List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();

            List<extraPrecioViewModel> extra9List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra10List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra11List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra12List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra13List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra14List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra15List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra16List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra17List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra18List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra19List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();


            List<extraPrecioViewModel> extra20List = _context.EquipamientoExtras.Select(v => new extraPrecioViewModel
            {
                IdEquipamientoExtra = v.IdEquipamientoExtra,
                extraPrecio = v.NombreEquipamientoExtra + " - " + "US$ " + v.Precio
            }).ToList();




            ViewData["ColorExterior"] = new SelectList(precioColorExteriorList, "IdColor", "Colorprecio");
            ViewData["ColorInterior"] = new SelectList(precioColorInteriorList, "IdColor", "Colorprecio");
            ViewData["Extra01"] = new SelectList(extra1List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra02"] = new SelectList(extra2List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra03"] = new SelectList(extra3List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra04"] = new SelectList(extra4List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra05"] = new SelectList(extra5List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra06"] = new SelectList(extra6List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra07"] = new SelectList(extra7List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra08"] = new SelectList(extra8List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra09"] = new SelectList(extra9List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra10"] = new SelectList(extra10List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra11"] = new SelectList(extra11List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra12"] = new SelectList(extra12List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra13"] = new SelectList(extra13List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra14"] = new SelectList(extra14List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra15"] = new SelectList(extra15List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra16"] = new SelectList(extra16List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra17"] = new SelectList(extra17List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra18"] = new SelectList(extra18List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra19"] = new SelectList(extra19List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["Extra20"] = new SelectList(extra20List, "IdEquipamientoExtra", "extraPrecio");
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca");
            var modelo = _context.Modelos.FirstOrDefault(m => m.IdModelo == idModelo);
            ViewBag.Modelo = modelo;

            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "NombreModelo", idModelo);

            return View();
        }

        // POST: VehiculoPersonalizados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConstruccionVehiculo,IdMarca,IdModelo,Vin,ColorExterior,ColorInterior,Extra01,Extra02,Extra03,Extra04,Extra05,Extra06,Extra07,Extra08,Extra09,Extra10,Extra11,Extra12,Extra13,Extra14,Extra15,Extra16,Extra17,Extra18,Extra19,Extra20,Precio")] VehiculoPersonalizado vehiculoPersonalizado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculoPersonalizado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "IdColorExterior", vehiculoPersonalizado.ColorExterior);
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "IdColorInterior", vehiculoPersonalizado.ColorInterior);
            ViewData["Extra01"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra01);
            ViewData["Extra02"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra02);
            ViewData["Extra03"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra03);
            ViewData["Extra04"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra04);
            ViewData["Extra05"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra05);
            ViewData["Extra06"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra06);
            ViewData["Extra07"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra07);
            ViewData["Extra08"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra08);
            ViewData["Extra09"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra09);
            ViewData["Extra10"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra10);
            ViewData["Extra11"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra11);
            ViewData["Extra12"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra12);
            ViewData["Extra13"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra13);
            ViewData["Extra14"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra14);
            ViewData["Extra15"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra15);
            ViewData["Extra16"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra16);
            ViewData["Extra17"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra17);
            ViewData["Extra18"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra18);
            ViewData["Extra19"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra19);
            ViewData["Extra20"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra20);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", vehiculoPersonalizado.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", vehiculoPersonalizado.IdModelo);
            return View(vehiculoPersonalizado);
        }

        /*        [HttpGet]
                public IActionResult CalcularPrecioTotal(int idModelo, int? idColorExterior, int? idColorInterior)
                {
                    var precioBase = _context.Modelos.Where(m => m.IdModelo == idModelo).Select(m => m.PrecioBase).FirstOrDefault();
                    var precioColorExterior = idColorExterior.HasValue ? _context.ColorExteriors.Where(c => c.IdColorExterior == idColorExterior.Value).Select(c => c.PrecioColorExterior).FirstOrDefault() ?? 0 : 0;
                    var precioColorInterior = idColorInterior.HasValue ? _context.ColorInteriors.Where(c => c.IdColorInterior == idColorInterior.Value).Select(c => c.PrecioColorInterior).FirstOrDefault() ?? 0 : 0;

                    var precioTotal = precioBase + precioColorExterior + precioColorInterior;


                    return Json(precioTotal);
                }*/
        [HttpGet]
        public IActionResult CalcularPrecioTotal(int idModelo, int? idColorExterior, int? idColorInterior, int? idExtra01, int? idExtra02, int? idExtra03, int? idExtra04, int? idExtra05, int? idExtra06, int? idExtra07, int? idExtra08, int? idExtra09, int? idExtra10, int? idExtra11, int? idExtra12, int? idExtra13, int? idExtra14, int? idExtra15, int? idExtra16, int? idExtra17, int? idExtra18, int? idExtra19, int? idExtra20)
        {
            var precioBase = _context.Modelos.Where(m => m.IdModelo == idModelo).Select(m => m.PrecioBase).FirstOrDefault();
            var precioColorExterior = idColorExterior.HasValue ? _context.ColorExteriors.Where(c => c.IdColorExterior == idColorExterior.Value).Select(c => c.PrecioColorExterior).FirstOrDefault() ?? 0 : 0;
            var precioColorInterior = idColorInterior.HasValue ? _context.ColorInteriors.Where(c => c.IdColorInterior == idColorInterior.Value).Select(c => c.PrecioColorInterior).FirstOrDefault() ?? 0 : 0;

            var precioExtra01 = idExtra01.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra01.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra02 = idExtra02.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra02.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra03 = idExtra03.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra03.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra04 = idExtra04.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra04.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra05 = idExtra05.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra05.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra06 = idExtra06.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra06.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra07 = idExtra07.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra07.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra08 = idExtra08.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra08.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra09 = idExtra09.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra09.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra10 = idExtra10.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra10.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra11 = idExtra11.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra11.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra12 = idExtra12.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra12.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra13 = idExtra13.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra13.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra14 = idExtra14.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra14.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra15 = idExtra15.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra15.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra16 = idExtra16.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra16.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra17 = idExtra17.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra17.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra18 = idExtra18.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra18.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra19 = idExtra19.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra19.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;
            var precioExtra20 = idExtra20.HasValue ? _context.EquipamientoExtras.Where(c => c.IdEquipamientoExtra == idExtra20.Value).Select(c => c.Precio).FirstOrDefault() ?? 0 : 0;


            var precioTotal = precioBase + precioColorExterior + precioColorInterior + precioExtra01 + precioExtra02 + precioExtra03 + precioExtra04 + precioExtra05 + precioExtra06 + precioExtra07 + precioExtra08 + precioExtra09 + precioExtra10 + precioExtra11 + precioExtra12 + precioExtra13 + precioExtra14 + precioExtra15 + precioExtra16 + precioExtra17 + precioExtra18 + precioExtra19 + precioExtra20;
            var precioTotalExtras = precioColorExterior + precioColorInterior + precioExtra01 + precioExtra02 + precioExtra03 + precioExtra04 + precioExtra05 + precioExtra06 + precioExtra07 + precioExtra08 + precioExtra09 + precioExtra10 + precioExtra11 + precioExtra12 + precioExtra13 + precioExtra14 + precioExtra15 + precioExtra16 + precioExtra17 + precioExtra18 + precioExtra19 + precioExtra20;

            return Json(new { precioTotal, precioTotalExtras });
        }



        // GET: VehiculoPersonalizados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehiculoPersonalizados == null)
            {
                return NotFound();
            }

            var vehiculoPersonalizado = await _context.VehiculoPersonalizados.FindAsync(id);
            if (vehiculoPersonalizado == null)
            {
                return NotFound();
            }
            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "ColorExterior1", vehiculoPersonalizado.ColorExterior);
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "ColorInterior1", vehiculoPersonalizado.ColorInterior);
            ViewData["Extra01"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra01);
            ViewData["Extra02"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra02);
            ViewData["Extra03"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra03);
            ViewData["Extra04"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra04);
            ViewData["Extra05"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra05);
            ViewData["Extra06"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra06);
            ViewData["Extra07"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra07);
            ViewData["Extra08"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra08);
            ViewData["Extra09"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra09);
            ViewData["Extra10"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra10);
            ViewData["Extra11"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra11);
            ViewData["Extra12"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra12);
            ViewData["Extra13"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra13);
            ViewData["Extra14"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra14);
            ViewData["Extra15"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra15);
            ViewData["Extra16"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra16);
            ViewData["Extra17"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra17);
            ViewData["Extra18"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra18);
            ViewData["Extra19"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra19);
            ViewData["Extra20"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "NombreEquipamientoExtra", vehiculoPersonalizado.Extra20);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", vehiculoPersonalizado.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", vehiculoPersonalizado.IdModelo);
            return View(vehiculoPersonalizado);
        }

        // POST: VehiculoPersonalizados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConstruccionVehiculo,IdMarca,IdModelo,Vin,ColorExterior,ColorInterior,Extra01,Extra02,Extra03,Extra04,Extra05,Extra06,Extra07,Extra08,Extra09,Extra10,Extra11,Extra12,Extra13,Extra14,Extra15,Extra16,Extra17,Extra18,Extra19,Extra20,Precio")] VehiculoPersonalizado vehiculoPersonalizado)
        {
            if (id != vehiculoPersonalizado.IdConstruccionVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoPersonalizado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoPersonalizadoExists(vehiculoPersonalizado.IdConstruccionVehiculo))
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
            ViewData["ColorExterior"] = new SelectList(_context.ColorExteriors, "IdColorExterior", "IdColorExterior", vehiculoPersonalizado.ColorExterior);
            ViewData["ColorInterior"] = new SelectList(_context.ColorInteriors, "IdColorInterior", "IdColorInterior", vehiculoPersonalizado.ColorInterior);
            ViewData["Extra01"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra01);
            ViewData["Extra02"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra02);
            ViewData["Extra03"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra03);
            ViewData["Extra04"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra04);
            ViewData["Extra05"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra05);
            ViewData["Extra06"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra06);
            ViewData["Extra07"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra07);
            ViewData["Extra08"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra08);
            ViewData["Extra09"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra09);
            ViewData["Extra10"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra10);
            ViewData["Extra11"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra11);
            ViewData["Extra12"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra12);
            ViewData["Extra13"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra13);
            ViewData["Extra14"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra14);
            ViewData["Extra15"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra15);
            ViewData["Extra16"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra16);
            ViewData["Extra17"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra17);
            ViewData["Extra18"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra18);
            ViewData["Extra19"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra19);
            ViewData["Extra20"] = new SelectList(_context.EquipamientoExtras, "IdEquipamientoExtra", "IdEquipamientoExtra", vehiculoPersonalizado.Extra20);
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", vehiculoPersonalizado.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", vehiculoPersonalizado.IdModelo);
            return View(vehiculoPersonalizado);
        }

        // GET: VehiculoPersonalizados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehiculoPersonalizados == null)
            {
                return NotFound();
            }

            var vehiculoPersonalizado = await _context.VehiculoPersonalizados
                .Include(v => v.ColorExteriorNavigation)
                .Include(v => v.ColorInteriorNavigation)
                .Include(v => v.Extra01Navigation)
                .Include(v => v.Extra02Navigation)
                .Include(v => v.Extra03Navigation)
                .Include(v => v.Extra04Navigation)
                .Include(v => v.Extra05Navigation)
                .Include(v => v.Extra06Navigation)
                .Include(v => v.Extra07Navigation)
                .Include(v => v.Extra08Navigation)
                .Include(v => v.Extra09Navigation)
                .Include(v => v.Extra10Navigation)
                .Include(v => v.Extra11Navigation)
                .Include(v => v.Extra12Navigation)
                .Include(v => v.Extra13Navigation)
                .Include(v => v.Extra14Navigation)
                .Include(v => v.Extra15Navigation)
                .Include(v => v.Extra16Navigation)
                .Include(v => v.Extra17Navigation)
                .Include(v => v.Extra18Navigation)
                .Include(v => v.Extra19Navigation)
                .Include(v => v.Extra20Navigation)
                .Include(v => v.IdMarcaNavigation)
                .Include(v => v.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.IdConstruccionVehiculo == id);
            if (vehiculoPersonalizado == null)
            {
                return NotFound();
            }

            return View(vehiculoPersonalizado);
        }

        // POST: VehiculoPersonalizados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehiculoPersonalizados == null)
            {
                return Problem("Entity set 'DEALERContext.VehiculoPersonalizados'  is null.");
            }
            var vehiculoPersonalizado = await _context.VehiculoPersonalizados.FindAsync(id);
            if (vehiculoPersonalizado != null)
            {
                _context.VehiculoPersonalizados.Remove(vehiculoPersonalizado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoPersonalizadoExists(int id)
        {
            return (_context.VehiculoPersonalizados?.Any(e => e.IdConstruccionVehiculo == id)).GetValueOrDefault();
        }
    }
}
