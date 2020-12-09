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
    public class UsuarioXGrupoController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;
        public UsuarioXGrupoController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UsuarioXGrupo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.UsuarioXGrupo>>> GetUsuarioXGrupos()
        {
            var aux = await new Solution.BS.UsuarioXGrupo(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.UsuarioXGrupo>, IEnumerable<Models.UsuarioXGrupo>>(aux).ToList();
        }

        // GET: api/UsuarioXGrupo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.UsuarioXGrupo>> GetUsuarioXGrupo(int id)
        {
            var usuarioXGrupo = await new Solution.BS.UsuarioXGrupo(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.UsuarioXGrupo, Models.UsuarioXGrupo>(usuarioXGrupo);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/UsuarioXGrupo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioXGrupo(int id, Models.UsuarioXGrupo usuarioXGrupo)
        {
            if (id != usuarioXGrupo.IdGrupo)
            {
                return BadRequest();
            }
            try
            {
                var result = _mapper.Map<Models.UsuarioXGrupo, data.UsuarioXGrupo>(usuarioXGrupo);
                new Solution.BS.UsuarioXGrupo(_context).Update(result);
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
        public async Task<ActionResult<Models.UsuarioXGrupo>> PostUsuarioXGrupo(Models.UsuarioXGrupo usuarioXGrupo)
        {
            var result = _mapper.Map<Models.UsuarioXGrupo, data.UsuarioXGrupo>(usuarioXGrupo);
            new Solution.BS.UsuarioXGrupo(_context).Insert(result);

            return CreatedAtAction("GetUsuarioXGrupo", new { id = usuarioXGrupo.IdGrupo }, usuarioXGrupo);
        }

        // DELETE: api/UsuarioXGrupo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.UsuarioXGrupo>> DeleteUsuarioXGrupo(int id)
        {
            var usuarioXGrupo = new Solution.BS.UsuarioXGrupo(_context).GetOneById(id);
            var result = _mapper.Map<data.UsuarioXGrupo, Models.UsuarioXGrupo>(usuarioXGrupo);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            new Solution.BS.UsuarioXGrupo(_context).Delete(usuarioXGrupo);

            return result;
        }

        private bool UsuarioXGrupoExists(int id)
        {
            return (new Solution.BS.UsuarioXGrupo(_context).GetOneById(id) != null);
        }
    }
}
