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
    public class UsuarioXGrupoWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public UsuarioXGrupoWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: UsuarioXGrupoWEF
        public async Task<IActionResult> Index()
        {
            var proyectoProgramacionWebContext = _context.UsuarioXGrupos.Include(u => u.CedulaNavigation).Include(u => u.IdGrupoNavigation);
            return View(await proyectoProgramacionWebContext.ToListAsync());
        }

        // GET: UsuarioXGrupoWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXGrupo = await _context.UsuarioXGrupos
                .Include(u => u.CedulaNavigation)
                .Include(u => u.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioXgrupo == id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioXGrupo);
        }

        // GET: UsuarioXGrupoWEF/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena");
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo");
            return View();
        }

        // POST: UsuarioXGrupoWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarioXgrupo,IdGrupo,Cedula")] UsuarioXGrupo usuarioXGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioXGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena", usuarioXGrupo.Cedula);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", usuarioXGrupo.IdGrupo);
            return View(usuarioXGrupo);
        }

        // GET: UsuarioXGrupoWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXGrupo = await _context.UsuarioXGrupos.FindAsync(id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena", usuarioXGrupo.Cedula);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", usuarioXGrupo.IdGrupo);
            return View(usuarioXGrupo);
        }

        // POST: UsuarioXGrupoWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarioXgrupo,IdGrupo,Cedula")] UsuarioXGrupo usuarioXGrupo)
        {
            if (id != usuarioXGrupo.IdUsuarioXgrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioXGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioXGrupoExists(usuarioXGrupo.IdUsuarioXgrupo))
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
            ViewData["Cedula"] = new SelectList(_context.Usuarios, "Cedula", "Contrasena", usuarioXGrupo.Cedula);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", usuarioXGrupo.IdGrupo);
            return View(usuarioXGrupo);
        }

        // GET: UsuarioXGrupoWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXGrupo = await _context.UsuarioXGrupos
                .Include(u => u.CedulaNavigation)
                .Include(u => u.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarioXgrupo == id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioXGrupo);
        }

        // POST: UsuarioXGrupoWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioXGrupo = await _context.UsuarioXGrupos.FindAsync(id);
            _context.UsuarioXGrupos.Remove(usuarioXGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioXGrupoExists(int id)
        {
            return _context.UsuarioXGrupos.Any(e => e.IdUsuarioXgrupo == id);
        }
    }
}
