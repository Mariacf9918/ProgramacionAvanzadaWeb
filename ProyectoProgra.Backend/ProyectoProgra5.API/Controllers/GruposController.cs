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
    public class GruposController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GruposController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Grupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Grupos>>> GetGrupos()
        {
            var aux = await new Solution.BS.Grupos(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Grupos>, IEnumerable<Models.Grupos>>(aux).ToList();
        }

        // GET: api/Grupos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Grupos>> GetGrupo(int id)
        {
            var grupo = new Solution.BS.Grupos(_context).GetOneById(id);
            var result = _mapper.Map<data.Grupos, Models.Grupos>(grupo);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Grupos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupo(int id, Models.Grupos grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return BadRequest();
            }


            try
            {
                var result = _mapper.Map<Models.Grupos, data.Grupos>(grupo);
                new Solution.BS.Grupos(_context).Update(result);
            }
            catch (Exception)
            {
                if (!GrupoExists(id))
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

        // POST: api/Grupos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.Grupos>> PostGrupo(Models.Grupos grupo)
        {
            var result = _mapper.Map<Models.Grupos, data.Grupos>(grupo);
            new Solution.BS.Grupos(_context).Insert(result);

            return CreatedAtAction("GetGrupo", new { id = grupo.IdGrupo }, grupo);
        }

        // DELETE: api/Grupos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Grupos>> DeleteGrupo(int id)
        {
            var grupo = new Solution.BS.Grupos(_context).GetOneById(id);
            var result = _mapper.Map<data.Grupos, Models.Grupos>(grupo);
            if (grupo == null)
            {
                return NotFound();
            }

            new Solution.BS.Grupos(_context).Delete(grupo);

            return result;
        }

        private bool GrupoExists(int id)
        {
            return (new Solution.BS.Grupos(_context).GetOneById(id) != null);
        }
    }
}
