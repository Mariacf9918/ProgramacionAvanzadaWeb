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
    public class UsuariosController : Controller
    {
        private readonly SolutionDBContext _context;

        public UsuariosController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Usuarios>>> GetUsuarios()
        {
            return new Solution.BS.Usuarios(_context).GetAll().ToList();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Usuarios>> GetUsuario(int id)
        {
            var usuario = new Solution.BS.Usuarios(_context).GetOneById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, data.Usuarios usuario)
        {
            if (id != usuario.Cedula)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Usuarios(_context).Update(usuario);
            }
            catch (Exception)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Usuarios>> PostUsuario(data.Usuarios usuario)
        {

            new Solution.BS.Usuarios(_context).Insert(usuario);
            return CreatedAtAction("GetUsuario", new { id = usuario.Cedula }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Usuarios>> DeleteUsuario(int id)
        {
            var usuario = new Solution.BS.Usuarios(_context).GetOneById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            new Solution.BS.Usuarios(_context).Delete(usuario);

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return (new Solution.BS.Usuarios(_context).GetOneById(id) != null);
        }
    }
}
