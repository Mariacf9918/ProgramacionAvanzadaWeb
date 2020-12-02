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
    
    public class UsuarioXGrupoCAPIController : Controller
    {
        string baseurl = " http://localhost:4404";

        // GET: UsuarioXGrupoWEF
        public async Task<IActionResult> Index()
        {
            // var proyectoProgramacionWebContext = _context.UsuarioXGrupos.Include(u => u.CedulaNavigation).Include(u => u.IdGrupoNavigation);
            //return View(await proyectoProgramacionWebContext.ToListAsync());

            List<data.UsuarioXGrupo> aux = new List<data.UsuarioXGrupo>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/UsuarioXGrupo");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.UsuarioXGrupo>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: UsuarioXGrupoWEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXGrupo = GetById(id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioXGrupo);
        }

        // GET: UsuarioXGrupoWEF/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Contrasena");
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo");
            return View();
        }

        // POST: UsuarioXGrupoWEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarioXgrupo,IdGrupo,Cedula")] UsuarioXGrupo usuarioXGrupo)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(usuarioXGrupo);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/UsuarioXGrupo", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Contrasena", usuarioXGrupo.Cedula);
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo", usuarioXGrupo.IdGrupo);
            return View(usuarioXGrupo);
        }

        // GET: UsuarioXGrupoWEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXGrupo = GetById(id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Contrasena", usuarioXGrupo.Cedula);
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo", usuarioXGrupo.IdGrupo);
            return View(usuarioXGrupo);
        }

        // POST: UsuarioXGrupoWEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarioXgrupo,IdGrupo,Cedula")] UsuarioXGrupo usuarioXGrupo)
        {
            if (id != usuarioXGrupo.IdUsuarioXgrupo)
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
                        var content = JsonConvert.SerializeObject(usuarioXGrupo);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/UsuarioXGrupo/" + id, byteContent).Result;

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
            ViewData["Cedula"] = new SelectList(GetAllUsuarios(), "Cedula", "Contrasena", usuarioXGrupo.Cedula);
            ViewData["IdGrupo"] = new SelectList(GetAllGrupos(), "IdGrupo", "IdGrupo", usuarioXGrupo.IdGrupo);
            return View(usuarioXGrupo);
        }

        // GET: UsuarioXGrupoWEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioXGrupo = GetById(id);
            if (usuarioXGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioXGrupo);
        }

        // POST: UsuarioXGrupoWEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/UsuarioXGrupo/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private data.UsuarioXGrupo GetById(int? id)
        {
            data.UsuarioXGrupo aux = new data.UsuarioXGrupo();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/UsuarioXGrupo/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.UsuarioXGrupo>(auxres);
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
    }
}
