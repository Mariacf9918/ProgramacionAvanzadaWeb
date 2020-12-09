using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public UsuariosController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Usuarios>>> GetUsuarios()
        {
            var aux = await new Solution.BS.Usuarios(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Usuarios>, IEnumerable<Models.Usuarios>>(aux).ToList();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Usuarios>> GetUsuario(int id)
        {
            var usuario = await new Solution.BS.Usuarios(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Usuarios, Models.Usuarios>(usuario);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Models.Usuarios usuario)
        {
            if (id != usuario.Cedula)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Usuarios, data.Usuarios>(usuario);
                new Solution.BS.Usuarios(_context).Update(result);
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
        public async Task<ActionResult<Models.Usuarios>> PostUsuario(Models.Usuarios usuario)
        {
            var result = _mapper.Map<Models.Usuarios, data.Usuarios>(usuario);
            new Solution.BS.Usuarios(_context).Insert(result);

            return CreatedAtAction("GetUsuario", new { id = usuario.Cedula }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Usuarios>> DeleteUsuario(int id)
        {
            var usuario = new Solution.BS.Usuarios(_context).GetOneById(id);
            var result = _mapper.Map<data.Usuarios, Models.Usuarios>(usuario);
            if (usuario == null)
            {
                return NotFound();
            }

            new Solution.BS.Usuarios(_context).Delete(usuario);

            return result;
        }

        private bool UsuarioExists(int id)
        {
            return (new Solution.BS.Usuarios(_context).GetOneById(id) != null);
        }
    }
}
