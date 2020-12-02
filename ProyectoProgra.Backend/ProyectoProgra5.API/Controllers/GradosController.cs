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
    public class GradosController : Controller
    {
        private readonly SolutionDBContext _context;

        public GradosController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Grados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Grados>>> GetGrados()
        {
            return new Solution.BS.Grados(_context).GetAll().ToList();
        }

        // GET: api/Grados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Grados>> GetGrado(int id)
        {
            var grado = new Solution.BS.Grados(_context).GetOneById(id);

            if (grado == null)
            {
                return NotFound();
            }

            return grado;
        }

        // PUT: api/Grados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado(int id, data.Grados grado)
        {
            if (id != grado.IdGrado)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Grados(_context).Update(grado);
            }
            catch (Exception)
            {
                if (!GradoExists(id))
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

        // POST: api/Grados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Grados>> PostGrado(data.Grados grado)
        {
            new Solution.BS.Grados(_context).Insert(grado);

            return CreatedAtAction("GetGrado", new { id = grado.IdGrado }, grado);
        }

        // DELETE: api/Grados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Grados>> DeleteGrado(int id)
        {
            var grado = new Solution.BS.Grados(_context).GetOneById(id);
            if (grado == null)
            {
                return NotFound();
            }

            new Solution.BS.Grados(_context).Delete(grado);

            return grado;
        }

        private bool GradoExists(int id)
        {
            return (new Solution.BS.Grados(_context).GetOneById(id) != null);
        }
    }
}
