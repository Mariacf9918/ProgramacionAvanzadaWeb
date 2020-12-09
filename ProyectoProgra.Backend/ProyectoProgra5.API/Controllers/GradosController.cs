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
    public class GradosController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;
        public GradosController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Grados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Grados>>> GetGrados()
        {
            var aux = await new Solution.BS.Grados(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Grados>, IEnumerable<Models.Grados>>(aux).ToList();
        }

        // GET: api/Grados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Grados>> GetGrado(int id)
        {
            var grado = await new Solution.BS.Grados(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Grados, Models.Grados>(grado);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Grados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado(int id, Models.Grados grado)
        {
            if (id != grado.IdGrado)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Grados, data.Grados>(grado);
                new Solution.BS.Grados(_context).Update(result);
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
        public async Task<ActionResult<Models.Grados>> PostGrado(Models.Grados grado)
        {
            var result = _mapper.Map<Models.Grados, data.Grados>(grado);
            new Solution.BS.Grados(_context).Insert(result);

            return CreatedAtAction("GetGrado", new { id = grado.IdGrado }, grado);
        }

        // DELETE: api/Grados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Grados>> DeleteGrado(int id)
        {
            var grado = new Solution.BS.Grados(_context).GetOneById(id);
            var result = _mapper.Map<data.Grados, Models.Grados>(grado);
            if (grado == null)
            {
                return NotFound();
            }

            new Solution.BS.Grados(_context).Delete(grado);

            return result;
        }

        private bool GradoExists(int id)
        {
            return (new Solution.BS.Grados(_context).GetOneById(id) != null);
        }
    }
}
