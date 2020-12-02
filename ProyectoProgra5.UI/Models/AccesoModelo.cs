using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Models
{
    public class AccesoModelo{

        public Usuario ValidarAcceso(Usuario usr, ProyectoProgramacionWebContext context){
            Usuario usuario = new Usuario();
            Usuario user = (from d in context.Usuarios where d.Cedula == usr.Cedula && d.Contrasena == usr.Contrasena select d).FirstOrDefault();

            if (user != null){
                usuario.Cedula = user.Cedula;
                usuario.Contrasena = user.Contrasena.Trim();
                usuario.NombreCompleto = user.NombreCompleto.Trim();
                usuario.Telefono = user.Telefono;
                usuario.Telefono = user.Telefono;
                usuario.IdRol = user.IdRol;
                if (user.IdRol == 1){
                    Usuario.RolDescripcion = "Administrador";
                }else if (user.IdRol == 2){
                    Usuario.RolDescripcion = "Profesor";
                }else if (user.IdRol == 3){
                    Usuario.RolDescripcion = "Estudiante";
                }

            }
            return usuario;
        }//FIN DE ValidarAcceso
    }

}