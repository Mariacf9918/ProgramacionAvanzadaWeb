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
    public class InstitucionesController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;
        public InstitucionesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Instituciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Instituciones>>> GetInstituciones()
        {
            var result= new Solution.BS.Instituciones(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.Instituciones>, IEnumerable<Models.Instituciones>>(result);
            return aux.ToList();
        }

        // GET: api/Instituciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Instituciones>> GetInstitucione(int id)
        {
            var institucione = new Solution.BS.Instituciones(_context).GetOneById(id);
            var aux = _mapper.Map<data.Instituciones, Models.Instituciones>(institucione);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/Instituciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitucione(int id, Models.Instituciones institucione)
        {
            if (id != institucione.IdInstitucion)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.Instituciones, data.Instituciones>(institucione);
                new Solution.BS.Instituciones(_context).Update(aux);
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
        public async Task<ActionResult<Models.Instituciones>> PostInstitucione(Models.Instituciones institucione)
        {
            var aux = _mapper.Map<Models.Instituciones, data.Instituciones>(institucione);
            new Solution.BS.Instituciones(_context).Insert(aux);

            return CreatedAtAction("GetInstitucione", new { id = institucione.IdInstitucion }, institucione);
        }

        // DELETE: api/Instituciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Instituciones>> DeleteInstitucione(int id)
        {
            var institucione = new Solution.BS.Instituciones(_context).GetOneById(id);
            var aux = _mapper.Map<data.Instituciones, Models.Instituciones>(institucione);
            if (institucione == null)
            {
                return NotFound();
            }

            new Solution.BS.Instituciones(_context).Delete(institucione);

            return aux;
        }

        private bool InstitucioneExists(int id)
        {
            return (new Solution.BS.Instituciones(_context).GetOneById(id) != null);
        }
    }
}
