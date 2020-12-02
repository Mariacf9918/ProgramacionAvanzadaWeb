using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Instituciones.Models;

namespace ProyectoProgra5.Instituciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionesController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public InstitucionesController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/Instituciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institucione>>> GetInstituciones()
        {
            return await _context.Instituciones.ToListAsync();
        }

        // GET: api/Instituciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institucione>> GetInstitucione(int id)
        {
            var institucione = await _context.Instituciones.FindAsync(id);

            if (institucione == null)
            {
                return NotFound();
            }

            return institucione;
        }

        // PUT: api/Instituciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitucione(int id, Institucione institucione)
        {
            if (id != institucione.IdInstitucion)
            {
                return BadRequest();
            }

            _context.Entry(institucione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitucioneExists(id))
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

        // POST: api/Instituciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Institucione>> PostInstitucione(Institucione institucione)
        {
            _context.Instituciones.Add(institucione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitucione", new { id = institucione.IdInstitucion }, institucione);
        }

        // DELETE: api/Instituciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Institucione>> DeleteInstitucione(int id)
        {
            var institucione = await _context.Instituciones.FindAsync(id);
            if (institucione == null)
            {
                return NotFound();
            }

            _context.Instituciones.Remove(institucione);
            await _context.SaveChangesAsync();

            return institucione;
        }

        private bool InstitucioneExists(int id)
        {
            return _context.Instituciones.Any(e => e.IdInstitucion == id);
        }
    }
}
