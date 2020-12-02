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
    
    public class CalificacionesCAPIController : Controller
    {
        string baseurl = " http://localhost:4404";

        // GET: CalificacionesWEF
        public async Task<IActionResult> Index()
        {
            // var proyectoProgramacionWebContext = _context.Calificaciones.Include(c => c.CedulaNavigation).Include(c => c.IdGrupoNavigation).Include(c => c.IdMateriaNavigation).Include(c => c.IdPeriodoNavigation).Include(c => c.IdTipoOperacionNavigation);
            //return View(await proyectoProgramacionWebContext.ToListAsync());

            List<data.Calificacione> aux = new List<data.Calificacione>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Calificaciones");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Calificacione>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: CalificacionesWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacione = GetById(id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // GET: CalificacionesWEF/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Cedula");
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo");
            ViewData["IdMateria"] = new SelectList(GetAllMaterias(), "IdMateria", "IdMateria");
            ViewData["IdPeriodo"] = new SelectList(GetAllTipoPeriodos(), "IdPeriodo", "IdPeriodo");
            ViewData["IdTipoOperacion"] = new SelectList(GetAllTipoOperaciones(), "IdTipoOperacion", "IdTipoOperacion");
            return View();
        }

        // POST: CalificacionesWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalificacion,IdGrupo,Cedula,IdTipoOperacion,IdMateria,IdPeriodo,Nota,Fecha")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(calificacione);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Calificaciones", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Cedula", calificacione.Cedula);
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo", calificacione.IdGrupo);
            ViewData["IdMateria"] = new SelectList(GetAllMaterias(), "IdMateria", "IdMateria", calificacione.IdMateria);
            ViewData["IdPeriodo"] = new SelectList(GetAllTipoPeriodos(), "IdPeriodo", "IdPeriodo", calificacione.IdPeriodo);
            ViewData["IdTipoOperacion"] = new SelectList(GetAllTipoOperaciones(), "IdTipoOperacion", "IdTipoOperacion", calificacione.IdTipoOperacion);
            return View(calificacione);
        }

        // GET: CalificacionesWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacione = GetById(id);
            if (calificacione == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Cedula", calificacione.Cedula);
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo", calificacione.IdGrupo);
            ViewData["IdMateria"] = new SelectList(GetAllMaterias(), "IdMateria", "IdMateria", calificacione.IdMateria);
            ViewData["IdPeriodo"] = new SelectList(GetAllTipoPeriodos(), "IdPeriodo", "IdPeriodo", calificacione.IdPeriodo);
            ViewData["IdTipoOperacion"] = new SelectList(GetAllTipoOperaciones(), "IdTipoOperacion", "IdTipoOperacion", calificacione.IdTipoOperacion);
            return View(calificacione);
        }

        // POST: CalificacionesWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalificacion,IdGrupo,Cedula,IdTipoOperacion,IdMateria,IdPeriodo,Nota,Fecha")] Calificacione calificacione)
        {
            if (id != calificacione.IdCalificacion)
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
                        var content = JsonConvert.SerializeObject(calificacione);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Calificaciones/" + id, byteContent).Result;

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
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Cedula", calificacione.Cedula);
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo", calificacione.IdGrupo);
            ViewData["IdMateria"] = new SelectList(GetAllMaterias(), "IdMateria", "IdMateria", calificacione.IdMateria);
            ViewData["IdPeriodo"] = new SelectList(GetAllTipoPeriodos(), "IdPeriodo", "IdPeriodo", calificacione.IdPeriodo);
            ViewData["IdTipoOperacion"] = new SelectList(GetAllTipoOperaciones(), "IdTipoOperacion", "IdTipoOperacion", calificacione.IdTipoOperacion);
            return View(calificacione);
        }

        // GET: CalificacionesWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacione = GetById(id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // POST: CalificacionesWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Calificaciones/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private data.Calificacione GetById(int? id)
        {
            data.Calificacione aux = new data.Calificacione();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Calificaciones/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.Calificacione>(auxres);
                }
            }
            return aux;
        }

        private List<data.Usuario> GetAllUsuarios()
        {
            List<data.Usuario> aux = new List<data.Usuario>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Usuarios").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Usuario>>(auxres);
                }
            }
            return aux;
        }

        private List<data.Grupo> GetAllGrupos()
        {
            List<data.Grupo> aux = new List<data.Grupo>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Grupos").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Grupo>>(auxres);
                }
            }
            return aux;
        }
        private List<data.Materia> GetAllMaterias()
        {
            List<data.Materia> aux = new List<data.Materia>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Materias").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Materia>>(auxres);
                }
            }
            return aux;
        }

        private List<data.TipoPeriodo> GetAllTipoPeriodos()
        {
            List<data.TipoPeriodo> aux = new List<data.TipoPeriodo>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/TipoPeriodo").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.TipoPeriodo>>(auxres);
                }
            }
            return aux;
        }

        private List<data.TipoOperacione> GetAllTipoOperaciones()
        {
            List<data.TipoOperacione> aux = new List<data.TipoOperacione>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/TipoOperaciones").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.TipoOperacione>>(auxres);
                }
            }
            return aux;
        }
    }
}
