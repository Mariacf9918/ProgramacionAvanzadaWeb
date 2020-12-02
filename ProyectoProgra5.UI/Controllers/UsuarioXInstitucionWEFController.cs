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
    public class UsuarioXInstitucionWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public UsuarioXInstitucionWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: UsuarioXInstitucionWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.UsuarioXInstitucions.Include(u => u.CedulaNavigation).Include(u => u.IdInstitucionNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: UsuarioXInstitucionWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXInstitucion = await _context.UsuarioXInstitucions
                .Include(u => u.CedulaNavigation)
                .Include(u => u.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioXinstitucion == id);
            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }

            return View(usuarioXInstitucion);
        }

        // GET: UsuarioXInstitucionWEF/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena");
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: UsuarioXInstitucionWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarioXinstitucion,Cedula,IdInstitucion")] UsuarioXInstitucion usuarioXInstitucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioXInstitucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena", usuarioXInstitucion.Cedula);
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", usuarioXInstitucion.IdInstitucion);
            return View(usuarioXInstitucion);
        }

        // GET: UsuarioXInstitucionWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXInstitucion = await _context.UsuarioXInstitucions.FindAsync(id);
            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena", usuarioXInstitucion.Cedula);
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", usuarioXInstitucion.IdInstitucion);
            return View(usuarioXInstitucion);
        }

        // POST: UsuarioXInstitucionWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarioXinstitucion,Cedula,IdInstitucion")] UsuarioXInstitucion usuarioXInstitucion)
        {
            if (id != usuarioXInstitucion.IdUsuarioXinstitucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioXInstitucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioXInstitucionExists(usuarioXInstitucion.IdUsuarioXinstitucion))
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
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena", usuarioXInstitucion.Cedula);
            ViewData["IdInstitucion"] = new SelectList(_context.Instituciones, "IdInstitucion", "IdInstitucion", usuarioXInstitucion.IdInstitucion);
            return View(usuarioXInstitucion);
        }

        // GET: UsuarioXInstitucionWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXInstitucion = await _context.UsuarioXInstitucions
                .Include(u => u.CedulaNavigation)
                .Include(u => u.IdInstitucionNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioXinstitucion == id);
            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }

            return View(usuarioXInstitucion);
        }

        // POST: UsuarioXInstitucionWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioXInstitucion = await _context.UsuarioXInstitucions.FindAsync(id);
            _context.UsuarioXInstitucions.Remove(usuarioXInstitucion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioXInstitucionExists(int id)
        {
            return _context.UsuarioXInstitucions.Any(e => e.IdUsuarioXinstitucion == id);
        }
    }
}
