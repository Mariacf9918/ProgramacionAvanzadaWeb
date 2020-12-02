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
    public class GruposWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public GruposWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: GruposWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.Grupos.Include(g => g.IdGradoNavigation).Include(g => g.IdInstitucionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: GruposWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdGradoNavigation)
                .Include(g => g.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: GruposWEF/Create
        public IActionResult Create()
        {
            ViewData["IdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado");
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: GruposWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,IdGrado,IdInstitucion")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", grupo.IdGrado);
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", grupo.IdInstitucion);
            return View(grupo);
        }

        // GET: GruposWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["IdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", grupo.IdGrado);
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", grupo.IdInstitucion);
            return View(grupo);
        }

        // POST: GruposWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,IdGrado,IdInstitucion")] Grupo grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.IdGrupo))
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
            ViewData["IdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", grupo.IdGrado);
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", grupo.IdInstitucion);
            return View(grupo);
        }

        // GET: GruposWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdGradoNavigation)
                .Include(g => g.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: GruposWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.IdGrupo == id);
        }
    }
}
