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
    public class TipoPeriodoWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public TipoPeriodoWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: TipoPeriodoWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.TipoPeriodos.Include(t => t.IdInstitucionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: TipoPeriodoWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPeriodo = await _context.TipoPeriodos
                .Include(t => t.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            return View(tipoPeriodo);
        }

        // GET: TipoPeriodoWEF/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: TipoPeriodoWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodo,Descripcion,IdInstitucion")] TipoPeriodo tipoPeriodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPeriodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", tipoPeriodo.IdInstitucion);
            return View(tipoPeriodo);
        }

        // GET: TipoPeriodoWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPeriodo = await _context.TipoPeriodos.FindAsync(id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", tipoPeriodo.IdInstitucion);
            return View(tipoPeriodo);
        }

        // POST: TipoPeriodoWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,Descripcion,IdInstitucion")] TipoPeriodo tipoPeriodo)
        {
            if (id != tipoPeriodo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPeriodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPeriodoExists(tipoPeriodo.IdPeriodo))
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
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", tipoPeriodo.IdInstitucion);
            return View(tipoPeriodo);
        }

        // GET: TipoPeriodoWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPeriodo = await _context.TipoPeriodos
                .Include(t => t.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            return View(tipoPeriodo);
        }

        // POST: TipoPeriodoWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPeriodo = await _context.TipoPeriodos.FindAsync(id);
            _context.TipoPeriodos.Remove(tipoPeriodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPeriodoExists(int id)
        {
            return _context.TipoPeriodos.Any(e => e.IdPeriodo == id);
        }
    }
}
