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
    public class CalificacionesController : Controller    
    {
        private readonly SolutionDBContext _context;

        public CalificacionesController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Calificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Calificaciones>>> GetCalificaciones()
        {
            return new Solution.BS.Calificaciones(_context).GetAll().ToList();
        }

        // GET: api/Calificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Calificaciones>> GetCalificacione(int id)
        {
            var calificacione = new Solution.BS.Calificaciones(_context).GetOneById(id);

            if (calificacione == null)
            {
                return NotFound();
            }

            return calificacione;
        }

        // PUT: api/Calificaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacione(int id, data.Calificaciones calificacione)
        {
            if (id != calificacione.IdGrupo)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Calificaciones(_context).Update(calificacione);
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
        //REVISAR----------------------
        [HttpPost]
        public async Task<ActionResult<data.Calificaciones>> PostCalificacione(data.Calificaciones calificacione)
        {
            new Solution.BS.Calificaciones(_context).Insert(calificacione);

            return CreatedAtAction("GetCalificacione", new { id = calificacione.IdCalificacion }, calificacione);
        }

        // DELETE: api/Calificaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Calificaciones>> DeleteCalificacione(int id)
        {
            var calificacione = new Solution.BS.Calificaciones(_context).GetOneById(id);
            if (calificacione == null)
            {
                return NotFound();
            }

            new Solution.BS.Calificaciones(_context).Delete(calificacione);

            return calificacione;
        }

        private bool CalificacioneExists(int id)
        {
            return (new Solution.BS.Calificaciones(_context).GetOneById(id) != null);
        }
    }
}
