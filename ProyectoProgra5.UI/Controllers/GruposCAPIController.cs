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
   
    public class GruposCAPIController : Controller
    {
        string baseurl = " http://localhost:4404";

        // GET: GruposWEF
        public async Task<IActionResult> Index()
        {
            //var proyectoProgramacionWebContext = _context.Grupos.Include(g => g.IdGradoNavigation).Include(g => g.IdInstitucionNavigation);
            //return View(await proyectoProgramacionWebContext.ToListAsync());

            List<data.Grupo> aux = new List<data.Grupo>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Grupos");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Grupo>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: GruposWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = GetById(id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: GruposWEF/Create
        public IActionResult Create()
        {
            ViewData["IdGrado"] = new SelectList(GetAllGrados(), "IdGrado", "IdGrado");
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion");
            return View();
        }

        // POST: GruposWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,IdGrado,IdInstitucion")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(grupo);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Grupos", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["IdGrado"] = new SelectList(GetAllGrados(), "IdGrado", "IdGrado", grupo.IdGrado);
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", grupo.IdInstitucion);
            return View(grupo);
        }

        // GET: GruposWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo =  GetById(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["IdGrado"] = new SelectList(GetAllGrados(), "IdGrado", "IdGrado", grupo.IdGrado);
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", grupo.IdInstitucion);
            return View(grupo);
        }

        // POST: GruposWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,IdGrado,IdInstitucion")] Grupo grupo)
        {
            if (id != grupo.IdGrupo)
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
                        var content = JsonConvert.SerializeObject(grupo);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Grupos/" + id, byteContent).Result;

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
            ViewData["IdGrado"] = new SelectList(GetAllGrados(), "IdGrado", "IdGrado", grupo.IdGrado);
            ViewData["IdInstitucion"] = new SelectList(GetAllInstituciones(), "IdInstitucion", "IdInstitucion", grupo.IdInstitucion);
            return View(grupo);
        }

        // GET: GruposWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = GetById(id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: GruposWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Grupos/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private data.Grupo GetById(int? id)
        {
            data.Grupo aux = new data.Grupo();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Grupos/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.Grupo>(auxres);
                }
            }
            return aux;
        }

        private List<data.Grado> GetAllGrados()
        {
            List<data.Grado> aux = new List<data.Grado>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Grados").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Grado>>(auxres);
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
