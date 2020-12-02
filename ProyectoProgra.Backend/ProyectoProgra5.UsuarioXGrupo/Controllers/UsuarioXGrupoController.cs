using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.UsuarioXGrupo.Models;
using data = ProyectoProgra5.UsuarioXGrupo.Models;

namespace ProyectoProgra5.UsuarioXGrupo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioXGrupoController : ControllerBase
    {
        private readonly ProyectoProgramacionWebContext _context;

        public UsuarioXGrupoController(ProyectoProgramacionWebContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioXGrupo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.UsuarioXGrupo>>> GetUsuarioXGrupos()
        {
            return await _context.UsuarioXGrupos.ToListAsync();
        }

        // GET: api/UsuarioXGrupo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.UsuarioXGrupo>> GetUsuarioXGrupo(int id)
        {
            var usuarioXGrupo = await _context.UsuarioXGrupos.FindAsync(id);

            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            return usuarioXGrupo;
        }

        // PUT: api/UsuarioXGrupo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioXGrupo(int id, data.UsuarioXGrupo usuarioXGrupo)
        {
            if (id != usuarioXGrupo.IdGrupo)
            {
                return BadRequest();
            }

            _context.Entry(usuarioXGrupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioXGrupoExists(id))
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

        // POST: api/UsuarioXGrupo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.UsuarioXGrupo>> PostUsuarioXGrupo(data.UsuarioXGrupo usuarioXGrupo)
        {
            _context.UsuarioXGrupos.Add(usuarioXGrupo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioXGrupoExists(usuarioXGrupo.IdGrupo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioXGrupo", new { id = usuarioXGrupo.IdGrupo }, usuarioXGrupo);
        }

        // DELETE: api/UsuarioXGrupo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.UsuarioXGrupo>> DeleteUsuarioXGrupo(int id)
        {
            var usuarioXGrupo = await _context.UsuarioXGrupos.FindAsync(id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            _context.UsuarioXGrupos.Remove(usuarioXGrupo);
            await _context.SaveChangesAsync();

            return usuarioXGrupo;
        }

        private bool UsuarioXGrupoExists(int id)
        {
            return _context.UsuarioXGrupos.Any(e => e.IdGrupo == id);
        }
    }
}
