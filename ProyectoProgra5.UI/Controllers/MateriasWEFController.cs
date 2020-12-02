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
    public class MateriasWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public MateriasWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: MateriasWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.Materias.Include(m => m.IdInstitucionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: MateriasWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: MateriasWEF/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: MateriasWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMateria,Descripcion,IdInstitucion")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", materia.IdInstitucion);
            return View(materia);
        }

        // GET: MateriasWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", materia.IdInstitucion);
            return View(materia);
        }

        // POST: MateriasWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMateria,Descripcion,IdInstitucion")] Materia materia)
        {
            if (id != materia.IdMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.IdMateria))
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
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", materia.IdInstitucion);
            return View(materia);
        }

        // GET: MateriasWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: MateriasWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.IdMateria == id);
        }
    }
}
