using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Calificaciones.Models;

namespace ProyectoProgra5.Calificaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public CalificacionesController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/Calificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacione>>> GetCalificaciones()
        {
            return await _context.Calificaciones.ToListAsync();
        }

        // GET: api/Calificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacione>> GetCalificacione(int id)
        {
            var calificacione = await _context.Calificaciones.FindAsync(id);

            if (calificacione == null)
            {
                return NotFound();
            }

            return calificacione;
        }

        // PUT: api/Calificaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacione(int id, Calificacione calificacione)
        {
            if (id != calificacione.IdGrupo)
            {
                return BadRequest();
            }

            _context.Entry(calificacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacioneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calificaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Calificacione>> PostCalificacione(Calificacione calificacione)
        {
            _context.Calificaciones.Add(calificacione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalificacioneExists(calificacione.IdGrupo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalificacione", new { id = calificacione.IdGrupo }, calificacione);
        }

        // DELETE: api/Calificaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calificacione>> DeleteCalificacione(int id)
        {
            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificacione);
            await _context.SaveChangesAsync();

            return calificacione;
        }

        private bool CalificacioneExists(int id)
        {
            return _context.Calificaciones.Any(e => e.IdGrupo == id);
        }
    }
}
