using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Grados.Models;

namespace ProyectoProgra5.Grados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradosController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public GradosController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/Grados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grado>>> GetGrados()
        {
            return await _context.Grados.ToListAsync();
        }

        // GET: api/Grados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grado>> GetGrado(int id)
        {
            var grado = await _context.Grados.FindAsync(id);

            if (grado == null)
            {
                return NotFound();
            }

            return grado;
        }

        // PUT: api/Grados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado(int id, Grado grado)
        {
            if (id != grado.IdGrado)
            {
                return BadRequest();
            }

            _context.Entry(grado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoExists(id))
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

        // POST: api/Grados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Grado>> PostGrado(Grado grado)
        {
            _context.Grados.Add(grado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrado", new { id = grado.IdGrado }, grado);
        }

        // DELETE: api/Grados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grado>> DeleteGrado(int id)
        {
            var grado = await _context.Grados.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }

            _context.Grados.Remove(grado);
            await _context.SaveChangesAsync();

            return grado;
        }

        private bool GradoExists(int id)
        {
            return _context.Grados.Any(e => e.IdGrado == id);
        }
    }
}
