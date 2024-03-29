﻿using System;
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
    public class DetalleVentasController : Controller
    {
        private readonly SupermercadoContext _context;

        public DetalleVentasController(SupermercadoContext context)
        {
            _context = context;
        }

        // GET: DetalleVentas
        public async Task<IActionResult> Index()
        {
            var supermercadoContext = _context.DetalleVenta.Include(d => d.Producto).Include(d => d.Venta);
            return View(await supermercadoContext.ToListAsync());
        }

        // GET: DetalleVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVenta = await _context.DetalleVenta
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.IdDetalleVenta == id);
            if (detalleVenta == null)
            {
                return NotFound();
            }

            return View(detalleVenta);
        }

        // GET: DetalleVentas/Create
        public IActionResult Create()
        {
            ViewData["idProducto"] = new SelectList(_context.Set<Producto>(), "IdProducto", "Categoria");
            ViewData["idVenta"] = new SelectList(_context.Set<Venta>(), "idVenta", "idVenta");
            return View();
        }

        // POST: DetalleVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleVenta,IVA,Cantidad,PrecioUnidad,FechaRegistro,Descuento,idProducto,idVenta")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idProducto"] = new SelectList(_context.Set<Producto>(), "IdProducto", "Categoria", detalleVenta.idProducto);
            ViewData["idVenta"] = new SelectList(_context.Set<Venta>(), "idVenta", "idVenta", detalleVenta.idVenta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound();
            }
            ViewData["idProducto"] = new SelectList(_context.Set<Producto>(), "IdProducto", "Categoria", detalleVenta.idProducto);
            ViewData["idVenta"] = new SelectList(_context.Set<Venta>(), "idVenta", "idVenta", detalleVenta.idVenta);
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleVenta,IVA,Cantidad,PrecioUnidad,FechaRegistro,Descuento,idProducto,idVenta")] DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.IdDetalleVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentaExists(detalleVenta.IdDetalleVenta))
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
            ViewData["idProducto"] = new SelectList(_context.Set<Producto>(), "IdProducto", "Categoria", detalleVenta.idProducto);
            ViewData["idVenta"] = new SelectList(_context.Set<Venta>(), "idVenta", "idVenta", detalleVenta.idVenta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVenta = await _context.DetalleVenta
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.IdDetalleVenta == id);
            if (detalleVenta == null)
            {
                return NotFound();
            }

            return View(detalleVenta);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleVenta == null)
            {
                return Problem("Entity set 'SupermercadoContext.DetalleVenta'  is null.");
            }
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta != null)
            {
                _context.DetalleVenta.Remove(detalleVenta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVentaExists(int id)
        {
          return (_context.DetalleVenta?.Any(e => e.IdDetalleVenta == id)).GetValueOrDefault();
        }
    }
}
