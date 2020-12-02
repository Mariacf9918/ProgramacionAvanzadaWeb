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
    public class GruposController : Controller
    {
        private readonly SolutionDBContext _context;

        public GruposController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Grupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Grupos>>> GetGrupos()
        {
            return new Solution.BS.Grupos(_context).GetAll().ToList();
        }

        // GET: api/Grupos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Grupos>> GetGrupo(int id)
        {
            var grupo = new Solution.BS.Grupos(_context).GetOneById(id);

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        // PUT: api/Grupos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupo(int id, data.Grupos grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return BadRequest();
            }


            try
            {
                new Solution.BS.Grupos(_context).Update(grupo);
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
        public async Task<ActionResult<data.Grupos>> PostGrupo(data.Grupos grupo)
        {
            new Solution.BS.Grupos(_context).Insert(grupo);

            return CreatedAtAction("GetGrupo", new { id = grupo.IdGrupo }, grupo);
        }

        // DELETE: api/Grupos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Grupos>> DeleteGrupo(int id)
        {
            var grupo = new Solution.BS.Grupos(_context).GetOneById(id);
            if (grupo == null)
            {
                return NotFound();
            }

            new Solution.BS.Grupos(_context).Delete(grupo);

            return grupo;
        }

        private bool GrupoExists(int id)
        {
            return (new Solution.BS.Grupos(_context).GetOneById(id) != null);
        }
    }
}
