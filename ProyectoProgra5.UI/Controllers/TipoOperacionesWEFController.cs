using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.UI.Models;

namespace ProyectoProgra5.UI.Controllers
{
    public class TipoOperacionesWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public TipoOperacionesWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: TipoOperacionesWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.TipoOperaciones.Include(t => t.IdInstitucionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: TipoOperacionesWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOperacione = await _context.TipoOperaciones
                .Include(t => t.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoOperacion == id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            return View(tipoOperacione);
        }

        // GET: TipoOperacionesWEF/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: TipoOperacionesWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoOperacion,Descripcion,Porcentaje,IdInstitucion")] TipoOperacione tipoOperacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoOperacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", tipoOperacione.IdInstitucion);
            return View(tipoOperacione);
        }

        // GET: TipoOperacionesWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOperacione = await _context.TipoOperaciones.FindAsync(id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", tipoOperacione.IdInstitucion);
            return View(tipoOperacione);
        }

        // POST: TipoOperacionesWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoOperacion,Descripcion,Porcentaje,IdInstitucion")] TipoOperacione tipoOperacione)
        {
            if (id != tipoOperacione.IdTipoOperacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoOperacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoOperacioneExists(tipoOperacione.IdTipoOperacion))
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
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", tipoOperacione.IdInstitucion);
            return View(tipoOperacione);
        }

        // GET: TipoOperacionesWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOperacione = await _context.TipoOperaciones
                .Include(t => t.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoOperacion == id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            return View(tipoOperacione);
        }

        // POST: TipoOperacionesWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoOperacione = await _context.TipoOperaciones.FindAsync(id);
            _context.TipoOperaciones.Remove(tipoOperacione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoOperacioneExists(int id)
        {
            return _context.TipoOperaciones.Any(e => e.IdTipoOperacion == id);
        }
    }
}
