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
    public class InstitucionesController : Controller
    {
        private readonly SolutionDBContext _context;

        public InstitucionesController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Instituciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Instituciones>>> GetInstituciones()
        {
            return new Solution.BS.Instituciones(_context).GetAll().ToList();
        }

        // GET: api/Instituciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Instituciones>> GetInstitucione(int id)
        {
            var institucione = new Solution.BS.Instituciones(_context).GetOneById(id);

            if (institucione == null)
            {
                return NotFound();
            }

            return institucione;
        }

        // PUT: api/Instituciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitucione(int id, data.Instituciones institucione)
        {
            if (id != institucione.IdInstitucion)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Instituciones(_context).Update(institucione);
            }
            catch (Exception)
            {
                if (!InstitucioneExists(id))
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

        // POST: api/Instituciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Instituciones>> PostInstitucione(data.Instituciones institucione)
        {
            new Solution.BS.Instituciones(_context).Insert(institucione);

            return CreatedAtAction("GetInstitucione", new { id = institucione.IdInstitucion }, institucione);
        }

        // DELETE: api/Instituciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Instituciones>> DeleteInstitucione(int id)
        {
            var institucione = new Solution.BS.Instituciones(_context).GetOneById(id);
            if (institucione == null)
            {
                return NotFound();
            }

            new Solution.BS.Instituciones(_context).Delete(institucione);

            return institucione;
        }

        private bool InstitucioneExists(int id)
        {
            return (new Solution.BS.Instituciones(_context).GetOneById(id) != null);
        }
    }
}
