using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoProgra5.UI.Models;
using data = ProyectoProgra5.UI.Models;

namespace ProyectoProgra5.UI.Controllers
{
    
    public class TipoPeriodoCAPIController : Controller
    {
        string baseurl = " http://localhost:4404";

        // GET: TipoPeriodoWEF
        public async Task<IActionResult> Index()
        {
            //var proyectoProgramacionWebContext = _context.TipoPeriodos.Include(t => t.IdInstitucionNavigation);
            //return View(await proyectoProgramacionWebContext.ToListAsync());

            List<data.TipoPeriodo> aux = new List<data.TipoPeriodo>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/TipoPeriodo");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.TipoPeriodo>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: TipoPeriodoWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPeriodo = GetById(id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            return View(tipoPeriodo);
        }

        // GET: TipoPeriodoWEF/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: TipoPeriodoWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodo,Descripcion,IdInstitucion")] TipoPeriodo tipoPeriodo)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(tipoPeriodo);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/TipoPeriodo", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", tipoPeriodo.IdInstitucion);
            return View(tipoPeriodo);
        }

        // GET: TipoPeriodoWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPeriodo = GetById(id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", tipoPeriodo.IdInstitucion);
            return View(tipoPeriodo);
        }

        // POST: TipoPeriodoWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,Descripcion,IdInstitucion")] TipoPeriodo tipoPeriodo)
        {
            if (id != tipoPeriodo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(tipoPeriodo);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/TipoPeriodo/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", tipoPeriodo.IdInstitucion);
            return View(tipoPeriodo);
        }

        // GET: TipoPeriodoWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPeriodo = GetById(id);
            if (tipoPeriodo == null)
            {
                return NotFound();
            }

            return View(tipoPeriodo);
        }

        // POST: TipoPeriodoWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/TipoPeriodo/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private data.TipoPeriodo GetById(int? id)
        {
            data.TipoPeriodo aux = new data.TipoPeriodo();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/TipoPeriodo/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.TipoPeriodo>(auxres);
                }
            }
            return aux;
        }

        private List<data.Institucione> GetAllInstituciones()
        {
            List<data.Institucione> aux = new List<data.Institucione>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Instituciones").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Institucione>>(auxres);
                }
            }
            return aux;
        }
    }
}
