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
    public class TipoOperacionesController : Controller
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public TipoOperacionesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TipoOperaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.TipoOperaciones>>> GetTipoOperaciones()
        {
            var aux= await new Solution.BS.TipoOperaciones(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.TipoOperaciones>, IEnumerable<Models.TipoOperaciones>>(aux).ToList();
        }

        // GET: api/TipoOperaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.TipoOperaciones>> GetTipoOperacione(int id)
        {
            var tipoOperacione = await new Solution.BS.TipoOperaciones(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.TipoOperaciones, Models.TipoOperaciones>(tipoOperacione);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/TipoOperaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOperacione(int id, Models.TipoOperaciones tipoOperacione)
        {
            if (id != tipoOperacione.IdTipoOperacion)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.TipoOperaciones, data.TipoOperaciones>(tipoOperacione);
                new Solution.BS.TipoOperaciones(_context).Update(result);
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
        public async Task<ActionResult<Models.TipoOperaciones>> PostTipoOperacione(Models.TipoOperaciones tipoOperacione)
        {
            var result = _mapper.Map<Models.TipoOperaciones, data.TipoOperaciones>(tipoOperacione);
            new Solution.BS.TipoOperaciones(_context).Insert(result);

            return CreatedAtAction("GetTipoOperacione", new { id = tipoOperacione.IdTipoOperacion }, tipoOperacione);
        }

        // DELETE: api/TipoOperaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.TipoOperaciones>> DeleteTipoOperacione(int id)
        {
            var tipoOperacione = new Solution.BS.TipoOperaciones(_context).GetOneById(id);
            var result = _mapper.Map<data.TipoOperaciones, Models.TipoOperaciones>(tipoOperacione);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            new Solution.BS.TipoOperaciones(_context).Delete(tipoOperacione);

            return result;
        }

        private bool TipoOperacioneExists(int id)
        {
            return (new Solution.BS.TipoOperaciones(_context).GetOneById(id) != null);
        }

    }
}
