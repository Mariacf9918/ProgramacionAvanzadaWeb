using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.UsuarioXInstitucion.Models;
using data = ProyectoProgra5.UsuarioXInstitucion.Models;

namespace ProyectoProgra5.UsuarioXInstitucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioXInstitucionController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public UsuarioXInstitucionController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioXInstitucion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.UsuarioXInstitucion>>> GetUsuarioXInstitucions()
        {
            return await _context.UsuarioXInstitucions.ToListAsync();
        }

        // GET: api/UsuarioXInstitucion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.UsuarioXInstitucion>> GetUsuarioXInstitucion(int id)
        {
            var usuarioXInstitucion = await _context.UsuarioXInstitucions.FindAsync(id);

            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }

            return usuarioXInstitucion;
        }

        // PUT: api/UsuarioXInstitucion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioXInstitucion(int id, data.UsuarioXInstitucion usuarioXInstitucion)
        {
            if (id != usuarioXInstitucion.Cedula)
            {
                return BadRequest();
            }

            _context.Entry(usuarioXInstitucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioXInstitucionExists(id))
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

        // POST: api/UsuarioXInstitucion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.UsuarioXInstitucion>> PostUsuarioXInstitucion(data.UsuarioXInstitucion usuarioXInstitucion)
        {
            _context.UsuarioXInstitucions.Add(usuarioXInstitucion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioXInstitucionExists(usuarioXInstitucion.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioXInstitucion", new { id = usuarioXInstitucion.Cedula }, usuarioXInstitucion);
        }

        // DELETE: api/UsuarioXInstitucion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.UsuarioXInstitucion>> DeleteUsuarioXInstitucion(int id)
        {
            var usuarioXInstitucion = await _context.UsuarioXInstitucions.FindAsync(id);
            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }

            _context.UsuarioXInstitucions.Remove(usuarioXInstitucion);
            await _context.SaveChangesAsync();

            return usuarioXInstitucion;
        }

        private bool UsuarioXInstitucionExists(int id)
        {
            return _context.UsuarioXInstitucions.Any(e => e.Cedula == id);
        }
    }
}
