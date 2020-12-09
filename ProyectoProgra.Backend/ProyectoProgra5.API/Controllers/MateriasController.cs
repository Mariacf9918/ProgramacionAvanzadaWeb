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
    public class MateriasController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;
        public MateriasController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Materias>>> GetMaterias()
        {
            var aux = await new Solution.BS.Materias(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Materias>, IEnumerable<Models.Materias>>(aux).ToList();
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Materias>> GetMateria(int id)
        {
            var materia = await new Solution.BS.Materias(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Materias, Models.Materias>(materia);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Materias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Models.Materias materia)
        {
            if (id != materia.IdMateria)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Materias, data.Materias>(materia);
                new Solution.BS.Materias(_context).Update(result);
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
        public async Task<ActionResult<Models.Materias>> PostMateria(Models.Materias materia)
        {
            var result = _mapper.Map<Models.Materias, data.Materias>(materia);
            new Solution.BS.Materias(_context).Insert(result);

            return CreatedAtAction("GetMateria", new { id = materia.IdMateria }, materia);
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Materias>> DeleteMateria(int id)
        {
            var materia = new Solution.BS.Materias(_context).GetOneById(id);
            var result = _mapper.Map<data.Materias, Models.Materias>(materia);
            if (materia == null)
            {
                return NotFound();
            }

            new Solution.BS.Materias(_context).Delete(materia);

            return result;
        }

        private bool MateriaExists(int id)
        {
            return (new Solution.BS.Materias(_context).GetOneById(id) != null);
        }
    }
}
