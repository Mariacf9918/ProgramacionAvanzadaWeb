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
    public class CalificacionesWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public CalificacionesWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: CalificacionesWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.Calificaciones.Include(c => c.CedulaNavigation).Include(c => c.IdGrupoNavigation).Include(c => c.IdMateriaNavigation).Include(c => c.IdPeriodoNavigation).Include(c => c.IdTipoOperacionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: CalificacionesWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones
                .Include(c => c.CedulaNavigation)
                .Include(c => c.IdGrupoNavigation)
                .Include(c => c.IdMateriaNavigation)
                .Include(c => c.IdPeriodoNavigation)
                .Include(c => c.IdTipoOperacionNavigation)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // GET: CalificacionesWEF/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Cedula");
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo");
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "IdMateria");
            ViewData["IdPeriodo"] = new SelectList(_context.TipoPeriodos, "IdPeriodo", "IdPeriodo");
            ViewData["IdTipoOperacion"] = new SelectList(_context.TipoOperaciones, "IdTipoOperacion", "IdTipoOperacion");
            return View();
        }

        // POST: CalificacionesWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalificacion,IdGrupo,Cedula,IdTipoOperacion,IdMateria,IdPeriodo,Nota,Fecha")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Cedula", calificacione.Cedula);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", calificacione.IdGrupo);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "IdMateria", calificacione.IdMateria);
            ViewData["IdPeriodo"] = new SelectList(_context.TipoPeriodos, "IdPeriodo", "IdPeriodo", calificacione.IdPeriodo);
            ViewData["IdTipoOperacion"] = new SelectList(_context.TipoOperaciones, "IdTipoOperacion", "IdTipoOperacion", calificacione.IdTipoOperacion);
            return View(calificacione);
        }

        // GET: CalificacionesWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Cedula", calificacione.Cedula);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", calificacione.IdGrupo);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "IdMateria", calificacione.IdMateria);
            ViewData["IdPeriodo"] = new SelectList(_context.TipoPeriodos, "IdPeriodo", "IdPeriodo", calificacione.IdPeriodo);
            ViewData["IdTipoOperacion"] = new SelectList(_context.TipoOperaciones, "IdTipoOperacion", "IdTipoOperacion", calificacione.IdTipoOperacion);
            return View(calificacione);
        }

        // POST: CalificacionesWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalificacion,IdGrupo,Cedula,IdTipoOperacion,IdMateria,IdPeriodo,Nota,Fecha")] Calificacione calificacione)
        {
            if (id != calificacione.IdCalificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacioneExists(calificacione.IdCalificacion))
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
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Cedula", calificacione.Cedula);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", calificacione.IdGrupo);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "IdMateria", calificacione.IdMateria);
            ViewData["IdPeriodo"] = new SelectList(_context.TipoPeriodos, "IdPeriodo", "IdPeriodo", calificacione.IdPeriodo);
            ViewData["IdTipoOperacion"] = new SelectList(_context.TipoOperaciones, "IdTipoOperacion", "IdTipoOperacion", calificacione.IdTipoOperacion);
            return View(calificacione);
        }

        // GET: CalificacionesWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones
                .Include(c => c.CedulaNavigation)
                .Include(c => c.IdGrupoNavigation)
                .Include(c => c.IdMateriaNavigation)
                .Include(c => c.IdPeriodoNavigation)
                .Include(c => c.IdTipoOperacionNavigation)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // POST: CalificacionesWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacione = await _context.Calificaciones.FindAsync(id);
            _context.Calificaciones.Remove(calificacione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacioneExists(int id)
        {
            return _context.Calificaciones.Any(e => e.IdCalificacion == id);
        }
    }
}
