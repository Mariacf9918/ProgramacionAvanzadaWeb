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
    public class UsuarioXInstitucionController : Controller
    {

        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;
        public UsuarioXInstitucionController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UsuarioXInstitucion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.UsuarioXInstitucion>>> GetUsuarioXInstitucions()
        {
            var aux = await new Solution.BS.UsuarioXInstitucion(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.UsuarioXInstitucion>, IEnumerable<Models.UsuarioXInstitucion>>(aux).ToList();
        }

        // GET: api/UsuarioXInstitucion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.UsuarioXInstitucion>> GetUsuarioXInstitucion(int id)
        {
            var usuarioXInstitucion = await new Solution.BS.UsuarioXInstitucion(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.UsuarioXInstitucion, Models.UsuarioXInstitucion>(usuarioXInstitucion);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/UsuarioXInstitucion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioXInstitucion(int id, Models.UsuarioXInstitucion usuarioXInstitucion)
        {
            if (id != usuarioXInstitucion.Cedula)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.UsuarioXInstitucion, data.UsuarioXInstitucion>(usuarioXInstitucion);
                new Solution.BS.UsuarioXInstitucion(_context).Update(result);
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
        public async Task<ActionResult<Models.UsuarioXInstitucion>> PostUsuarioXInstitucion(Models.UsuarioXInstitucion usuarioXInstitucion)
        {
            var result = _mapper.Map<Models.UsuarioXInstitucion, data.UsuarioXInstitucion>(usuarioXInstitucion);
            new Solution.BS.UsuarioXInstitucion(_context).Insert(result);

            return CreatedAtAction("GetUsuarioXInstitucion", new { id = usuarioXInstitucion.Cedula }, usuarioXInstitucion);
        }

        // DELETE: api/UsuarioXInstitucion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.UsuarioXInstitucion>> DeleteUsuarioXInstitucion(int id)
        {
            var usuarioXInstitucion = new Solution.BS.UsuarioXInstitucion(_context).GetOneById(id);
            var result = _mapper.Map<data.UsuarioXInstitucion, Models.UsuarioXInstitucion>(usuarioXInstitucion);
            if (usuarioXInstitucion == null)
            {
                return NotFound();
            }

            new Solution.BS.UsuarioXInstitucion(_context).Delete(usuarioXInstitucion);

            return result;
        }

        private bool UsuarioXInstitucionExists(int id)
        {
            return (new Solution.BS.UsuarioXInstitucion(_context).GetOneById(id) != null);
        }
    }
}
