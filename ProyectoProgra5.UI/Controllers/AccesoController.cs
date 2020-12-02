using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ProyectoProgra5.UI.Models;

namespace ProyectoProgra5.UI.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        private readonly ProyectoProgramacionWebContext _context;

        public AccesoController(ProyectoProgramacionWebContext context){
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(int user, string contrasena){
            AccesoModelo modelAcceso = new AccesoModelo();

            Usuario usr = new Usuario();
            usr.Cedula = user;
            usr.Contrasena = contrasena;
            Usuario usuario = modelAcceso.ValidarAcceso(usr, _context);

            if (usuario.IdRol != 0){
                return RedirectToAction("Index", "Home");
            }else{
                ViewBag.Error = "Usuario o contraseña invalida";
                return View();
            }
        }

    }
}