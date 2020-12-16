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
    public class CalificacionesController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public CalificacionesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Calificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Calificaciones>>> GetCalificaciones()
        {
            var aux = await new Solution.BS.Calificaciones(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.Calificaciones>, IEnumerable<Models.Calificaciones>>(aux).ToList();
        }

        // GET: api/Calificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Calificaciones>> GetCalificacione(int id)
        {
            var aux = await new Solution.BS.Calificaciones(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.Calificaciones, Models.Calificaciones>(aux);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Calificaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacione(int id, Models.Calificaciones calificacione)
        {
            if (id != calificacione.IdCalificacion)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.Calificaciones, data.Calificaciones>(calificacione);
                new Solution.BS.Calificaciones(_context).Update(result);
            }
            catch (Exception)
            {
                if (!CalificacioneExists(id))
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

        // POST: api/Calificaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.Calificaciones>> PostCalificacione(Models.Calificaciones calificacione)
        {
            var result = _mapper.Map<Models.Calificaciones, data.Calificaciones>(calificacione);
            new Solution.BS.Calificaciones(_context).Insert(result);

            return CreatedAtAction("GetCalificacione", new { id = calificacione.IdCalificacion }, calificacione);
        }

        // DELETE: api/Calificaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Calificaciones>> DeleteCalificacione(int id)
        {
            var calificacione = new Solution.BS.Calificaciones(_context).GetOneById(id);
            var result = _mapper.Map<data.Calificaciones, Models.Calificaciones>(calificacione);
            if (calificacione == null)
            {
                return NotFound();
            }

            new Solution.BS.Calificaciones(_context).Delete(calificacione);

            return result;
        }

        private bool CalificacioneExists(int id)
        {
            return (new Solution.BS.Calificaciones(_context).GetOneById(id) != null);
        }
    }
}
