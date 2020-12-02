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
    public class UsuarioXInstitucionController : Controller
    {

        private readonly SolutionDBContext _context;

        public UsuarioXInstitucionController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioXInstitucion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.UsuarioXInstitucion>>> GetUsuarioXInstitucions()
        {
            return new Solution.BS.UsuarioXInstitucion(_context).GetAll().ToList();
        }

        // GET: api/UsuarioXInstitucion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.UsuarioXInstitucion>> GetUsuarioXInstitucion(int id)
        {
            var usuarioXInstitucion = new Solution.BS.UsuarioXInstitucion(_context).GetOneById(id);

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

            try
            {
                new Solution.BS.UsuarioXInstitucion(_context).Update(usuarioXInstitucion);
            }
            catch (Exception)
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
            _context.UsuarioXInstitucion.Add(usuarioXInstitucion);
            try
            {
                new Solution.BS.UsuarioXInstitucion(_context).Insert(usuarioXInstitucion);
            }
            catch (Exception)
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
            var usuarioXInstitucion = new Solution.BS.UsuarioXInstitucion(_context).GetOneById(id);
            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }

            new Solution.BS.UsuarioXInstitucion(_context).Delete(usuarioXInstitucion);

            return usuarioXInstitucion;
        }

        private bool UsuarioXInstitucionExists(int id)
        {
            return (new Solution.BS.UsuarioXInstitucion(_context).GetOneById(id) != null);
        }
    }
}
