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
    
    public class TipoOperacionesCAPIController : Controller
    {
        string baseurl = " http://localhost:4404";

        // GET: TipoOperacionesWEF
        public async Task<IActionResult> Index()
        {
            //var proyectoProgramacionWebContext = _context.TipoOperaciones.Include(t => t.IdInstitucionNavigation);
            //return View(await proyectoProgramacionWebContext.ToListAsync());

            List<data.TipoOperacione> aux = new List<data.TipoOperacione>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/TipoOperaciones");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.TipoOperacione>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: TipoOperacionesWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOperacione = GetById(id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            return View(tipoOperacione);
        }

        // GET: TipoOperacionesWEF/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: TipoOperacionesWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoOperacion,Descripcion,Porcentaje,IdInstitucion")] TipoOperacione tipoOperacione)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(tipoOperacione);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/TipoOperaciones", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", tipoOperacione.IdInstitucion);
            return View(tipoOperacione);
        }

        // GET: TipoOperacionesWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOperacione = GetById(id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", tipoOperacione.IdInstitucion);
            return View(tipoOperacione);
        }

        // POST: TipoOperacionesWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoOperacion,Descripcion,Porcentaje,IdInstitucion")] TipoOperacione tipoOperacione)
        {
            if (id != tipoOperacione.IdTipoOperacion)
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
                        var content = JsonConvert.SerializeObject(tipoOperacione);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/TipoOperaciones/" + id, byteContent).Result;

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
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", tipoOperacione.IdInstitucion);
            return View(tipoOperacione);
        }

        // GET: TipoOperacionesWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOperacione = GetById(id);
            if (tipoOperacione == null)
            {
                return NotFound();
            }

            return View(tipoOperacione);
        }

        // POST: TipoOperacionesWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/TipoOperaciones/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private data.TipoOperacione GetById(int? id)
        {
            data.TipoOperacione aux = new data.TipoOperacione();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/TipoOperaciones/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.TipoOperacione>(auxres);
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
