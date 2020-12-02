using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using data = Solution.DO.Objects;

namespace ProyectoProgra5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioXGrupoController : Controller
    {
        private readonly SolutionDBContext _context;

        public UsuarioXGrupoController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioXGrupo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.UsuarioXGrupo>>> GetUsuarioXGrupos()
        {
            return new Solution.BS.UsuarioXGrupo(_context).GetAll().ToList();
        }

        // GET: api/UsuarioXGrupo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.UsuarioXGrupo>> GetUsuarioXGrupo(int id)
        {
            var usuarioXGrupo = new Solution.BS.UsuarioXGrupo(_context).GetOneById(id);

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
            try
            {
                new Solution.BS.UsuarioXGrupo(_context).Update(usuarioXGrupo);
            }
            catch (Exception)
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
        //Pregutar--------------------
        [HttpPost]
        public async Task<ActionResult<data.UsuarioXGrupo>> PostUsuarioXGrupo(data.UsuarioXGrupo usuarioXGrupo)
        {
            _context.UsuarioXGrupo.Add(usuarioXGrupo);
            try
            {
                new Solution.BS.UsuarioXGrupo(_context).Insert(usuarioXGrupo);
            }
            catch (Exception)
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
            var usuarioXGrupo = new Solution.BS.UsuarioXGrupo(_context).GetOneById(id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            new Solution.BS.UsuarioXGrupo(_context).Delete(usuarioXGrupo);

            return usuarioXGrupo;
        }

        private bool UsuarioXGrupoExists(int id)
        {
            return (new Solution.BS.UsuarioXGrupo(_context).GetOneById(id) != null);
        }
    }
}
