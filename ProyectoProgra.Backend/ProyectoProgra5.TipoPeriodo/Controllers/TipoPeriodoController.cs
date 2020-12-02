using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.TipoPeriodo.Models;
using data = ProyectoProgra5.TipoPeriodo.Models;

namespace ProyectoProgra5.TipoPeriodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPeriodoController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public TipoPeriodoController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/TipoPeriodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.TipoPeriodo>>> GetTipoPeriodos()
        {
            return await _context.TipoPeriodos.ToListAsync();
        }

        // GET: api/TipoPeriodo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.TipoPeriodo>> GetTipoPeriodo(int id)
        {
            var tipoPeriodo = await _context.TipoPeriodos.FindAsync(id);

            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            return tipoPeriodo;
        }

        // PUT: api/TipoPeriodo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPeriodo(int id, data.TipoPeriodo tipoPeriodo)
        {
            if (id != tipoPeriodo.IdPeriodo)
            {
                return BadRequest();
            }

            _context.Entry(tipoPeriodo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPeriodoExists(id))
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

        // POST: api/TipoPeriodo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.TipoPeriodo>> PostTipoPeriodo(data.TipoPeriodo tipoPeriodo)
        {
            _context.TipoPeriodos.Add(tipoPeriodo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPeriodo", new { id = tipoPeriodo.IdPeriodo }, tipoPeriodo);
        }

        // DELETE: api/TipoPeriodo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.TipoPeriodo>> DeleteTipoPeriodo(int id)
        {
            var tipoPeriodo = await _context.TipoPeriodos.FindAsync(id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            _context.TipoPeriodos.Remove(tipoPeriodo);
            await _context.SaveChangesAsync();

            return tipoPeriodo;
        }

        private bool TipoPeriodoExists(int id)
        {
            return _context.TipoPeriodos.Any(e => e.IdPeriodo == id);
        }
    }
}
