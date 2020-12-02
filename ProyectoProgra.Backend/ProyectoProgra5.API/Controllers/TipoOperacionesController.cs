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
    public class TipoOperacionesController : Controller
    {
        private readonly SolutionDBContext _context;

        public TipoOperacionesController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/TipoOperaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.TipoOperaciones>>> GetTipoOperaciones()
        {
            return new Solution.BS.TipoOperaciones(_context).GetAll().ToList();
        }

        // GET: api/TipoOperaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.TipoOperaciones>> GetTipoOperacione(int id)
        {
            var tipoOperacione = new Solution.BS.TipoOperaciones(_context).GetOneById(id);

            if (tipoOperacione == null)
            {
                return NotFound();
            }

            return tipoOperacione;
        }

        // PUT: api/TipoOperaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOperacione(int id, data.TipoOperaciones tipoOperacione)
        {
            if (id != tipoOperacione.IdTipoOperacion)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.TipoOperaciones(_context).Update(tipoOperacione);
            }
            catch (Exception)
            {
                if (!TipoOperacioneExists(id))
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

        // POST: api/TipoOperaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.TipoOperaciones>> PostTipoOperacione(data.TipoOperaciones tipoOperacione)
        {
            new Solution.BS.TipoOperaciones(_context).Insert(tipoOperacione);

            return CreatedAtAction("GetTipoOperacione", new { id = tipoOperacione.IdTipoOperacion }, tipoOperacione);
        }

        // DELETE: api/TipoOperaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.TipoOperaciones>> DeleteTipoOperacione(int id)
        {
            var tipoOperacione = new Solution.BS.TipoOperaciones(_context).GetOneById(id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            new Solution.BS.TipoOperaciones(_context).Delete(tipoOperacione);

            return tipoOperacione;
        }

        private bool TipoOperacioneExists(int id)
        {
            return (new Solution.BS.TipoOperaciones(_context).GetOneById(id) != null);
        }

    }
}
