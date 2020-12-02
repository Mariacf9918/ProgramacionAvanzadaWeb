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
    public class InstitucionesWEFController : Controller
    {
        private readonly ProyectoProgramacionWebContext _context;

        public InstitucionesWEFController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: InstitucionesWEF
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituciones.ToListAsync());
        }

        // GET: InstitucionesWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucione = await _context.Instituciones
                .FirstOrDefaultAsync(m => m.IdInstitucion == id);
            if (institucione == null)
            {
                return NotFound();
            }

            return View(institucione);
        }

        // GET: InstitucionesWEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitucionesWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstitucion,NombreInstitucion,Descripcion,Telefono,Encargado,Direccion,Provincia,Canton,Distrito")] Institucione institucione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institucione);
        }

        // GET: InstitucionesWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucione = await _context.Instituciones.FindAsync(id);
            if (institucione == null)
            {
                return NotFound();
            }
            return View(institucione);
        }

        // POST: InstitucionesWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstitucion,NombreInstitucion,Descripcion,Telefono,Encargado,Direccion,Provincia,Canton,Distrito")] Institucione institucione)
        {
            if (id != institucione.IdInstitucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucioneExists(institucione.IdInstitucion))
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
            return View(institucione);
        }

        // GET: InstitucionesWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucione = await _context.Instituciones
                .FirstOrDefaultAsync(m => m.IdInstitucion == id);
            if (institucione == null)
            {
                return NotFound();
            }

            return View(institucione);
        }

        // POST: InstitucionesWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institucione = await _context.Instituciones.FindAsync(id);
            _context.Instituciones.Remove(institucione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucioneExists(int id)
        {
            return _context.Instituciones.Any(e => e.IdInstitucion == id);
        }
    }
}
