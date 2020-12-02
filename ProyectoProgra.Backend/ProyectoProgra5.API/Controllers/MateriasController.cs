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
    public class MateriasController : Controller
    {
        private readonly SolutionDBContext _context;

        public MateriasController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Materias>>> GetMaterias()
        {
            return new Solution.BS.Materias(_context).GetAll().ToList();
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Materias>> GetMateria(int id)
        {
            var materia = new Solution.BS.Materias(_context).GetOneById(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // PUT: api/Materias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, data.Materias materia)
        {
            if (id != materia.IdMateria)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Materias(_context).Update(materia);
            }
            catch (Exception)
            {
                if (!MateriaExists(id))
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

        // POST: api/Materias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Materias>> PostMateria(data.Materias materia)
        {
            new Solution.BS.Materias(_context).Insert(materia);

            return CreatedAtAction("GetMateria", new { id = materia.IdMateria }, materia);
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Materias>> DeleteMateria(int id)
        {
            var materia = new Solution.BS.Materias(_context).GetOneById(id);
            if (materia == null)
            {
                return NotFound();
            }

            new Solution.BS.Materias(_context).Delete(materia);

            return materia;
        }

        private bool MateriaExists(int id)
        {
            return (new Solution.BS.Materias(_context).GetOneById(id) != null);
        }
    }
}
