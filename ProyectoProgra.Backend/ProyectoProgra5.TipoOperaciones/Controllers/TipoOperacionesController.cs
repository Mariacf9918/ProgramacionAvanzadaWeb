using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.TipoOperaciones.Models;

namespace ProyectoProgra5.TipoOperaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoOperacionesController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public TipoOperacionesController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/TipoOperaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOperacione>>> GetTipoOperaciones()
        {
            return await _context.TipoOperaciones.ToListAsync();
        }

        // GET: api/TipoOperaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOperacione>> GetTipoOperacione(int id)
        {
            var tipoOperacione = await _context.TipoOperaciones.FindAsync(id);

            if (tipoOperacione == null)
            {
                return NotFound();
            }

            return tipoOperacione;
        }

        // PUT: api/TipoOperaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOperacione(int id, TipoOperacione tipoOperacione)
        {
            if (id != tipoOperacione.IdTipoOperacion)
            {
                return BadRequest();
            }

            _context.Entry(tipoOperacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoOperacioneExists(id))
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

        // POST: api/TipoOperaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoOperacione>> PostTipoOperacione(TipoOperacione tipoOperacione)
        {
            _context.TipoOperaciones.Add(tipoOperacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoOperacione", new { id = tipoOperacione.IdTipoOperacion }, tipoOperacione);
        }

        // DELETE: api/TipoOperaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoOperacione>> DeleteTipoOperacione(int id)
        {
            var tipoOperacione = await _context.TipoOperaciones.FindAsync(id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            _context.TipoOperaciones.Remove(tipoOperacione);
            await _context.SaveChangesAsync();

            return tipoOperacione;
        }

        private bool TipoOperacioneExists(int id)
        {
            return _context.TipoOperaciones.Any(e => e.IdTipoOperacion == id);
        }
    }
}
