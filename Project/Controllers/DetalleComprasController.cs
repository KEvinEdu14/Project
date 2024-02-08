using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using ProyectoFinal.Models;

namespace Project.Controllers
{
    public class DetalleComprasController : Controller
    {
        private readonly SupermercadoContext _context;

        public DetalleComprasController(SupermercadoContext context)
        {
            _context = context;
        }

        // GET: DetalleCompras
        public async Task<IActionResult> Index()
        {
            var supermercadoContext = _context.DetalleCompra.Include(d => d.Compra).Include(d => d.Empleado);
            return View(await supermercadoContext.ToListAsync());
        }

        // GET: DetalleCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleCompra == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompra
                .Include(d => d.Compra)
                .Include(d => d.Empleado)
                .FirstOrDefaultAsync(m => m.idDetalleCompra == id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            return View(detalleCompra);
        }

        // GET: DetalleCompras/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compra, "idCompra", "TipoComprobante");
            ViewData["EmpleadoId"] = new SelectList(_context.Set<Empleado>(), "idEmpleado", "ApellidoMaterno");
            return View();
        }

        // POST: DetalleCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDetalleCompra,FechaFactura,CostoTolal,Cantidad,IVA,EmpleadoId,CompraId,ProductoId")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compra, "idCompra", "TipoComprobante", detalleCompra.CompraId);
            ViewData["EmpleadoId"] = new SelectList(_context.Set<Empleado>(), "idEmpleado", "ApellidoMaterno", detalleCompra.EmpleadoId);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleCompra == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompra.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compra, "idCompra", "TipoComprobante", detalleCompra.CompraId);
            ViewData["EmpleadoId"] = new SelectList(_context.Set<Empleado>(), "idEmpleado", "ApellidoMaterno", detalleCompra.EmpleadoId);
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDetalleCompra,FechaFactura,CostoTolal,Cantidad,IVA,EmpleadoId,CompraId,ProductoId")] DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.idDetalleCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCompraExists(detalleCompra.idDetalleCompra))
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
            ViewData["CompraId"] = new SelectList(_context.Compra, "idCompra", "TipoComprobante", detalleCompra.CompraId);
            ViewData["EmpleadoId"] = new SelectList(_context.Set<Empleado>(), "idEmpleado", "ApellidoMaterno", detalleCompra.EmpleadoId);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleCompra == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompra
                .Include(d => d.Compra)
                .Include(d => d.Empleado)
                .FirstOrDefaultAsync(m => m.idDetalleCompra == id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            return View(detalleCompra);
        }

        // POST: DetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleCompra == null)
            {
                return Problem("Entity set 'SupermercadoContext.DetalleCompra'  is null.");
            }
            var detalleCompra = await _context.DetalleCompra.FindAsync(id);
            if (detalleCompra != null)
            {
                _context.DetalleCompra.Remove(detalleCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCompraExists(int id)
        {
          return (_context.DetalleCompra?.Any(e => e.idDetalleCompra == id)).GetValueOrDefault();
        }
    }
}
