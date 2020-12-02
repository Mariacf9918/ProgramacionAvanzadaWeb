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
    public class GradosWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public GradosWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: GradosWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.Grados.Include(g => g.IdInstitucionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: GradosWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grado = await _context.Grados
                .Include(g => g.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdGrado == id);
            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        // GET: GradosWEF/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: GradosWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrado,Descripcion,IdInstitucion")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", grado.IdInstitucion);
            return View(grado);
        }

        // GET: GradosWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grado = await _context.Grados.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", grado.IdInstitucion);
            return View(grado);
        }

        // POST: GradosWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrado,Descripcion,IdInstitucion")] Grado grado)
        {
            if (id != grado.IdGrado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradoExists(grado.IdGrado))
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
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", grado.IdInstitucion);
            return View(grado);
        }

        // GET: GradosWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grado = await _context.Grados
                .Include(g => g.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdGrado == id);
            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        // POST: GradosWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grado = await _context.Grados.FindAsync(id);
            _context.Grados.Remove(grado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradoExists(int id)
        {
            return _context.Grados.Any(e => e.IdGrado == id);
        }
    }
}
