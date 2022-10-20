using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext BDContext = new SGPI_BDContext();
        public IActionResult Login()
        {
            ///Create
            //TblUsuario usr = new TblUsuario();
            //usr.PrimerNombre = "Mauricio";
            //usr.SegundoNombre=String.Empty;
            //usr.PrimerApellido = "Amariles";
            //usr.SegundoApellido = "Camacho";
            //usr.Email = "yonosequeponer@gmail.com";
            //usr.Iddoc = 1;
            //usr.Idgenero = 1;
            //usr.NumeroDocumento = "123456789";
            //usr.VcPassword = "123";

            //BDContext.Add(usr);
            //BDContext.SaveChanges();

            //Query

            //Update

            var usr = BDContext.TblUsuarios.Where(cursor => cursor.Idusuario == 1).FirstOrDefault();
            if (usr != null)
            {
                usr.SegundoNombre = "Tronchatoro";
                BDContext.TblUsuarios.Update(usr);
                BDContext.SaveChanges();
            }
            //Delete
            var usuarioEliminar = BDContext.TblUsuarios.Where(cursor => cursor.Idusuario == 1).FirstOrDefault();
            BDContext.TblUsuarios.Remove(usuarioEliminar);

            return View();
        }

        [HttpPost]
        public IActionResult Login(TblUsuario user)
        {
            string numerodoc = user.NumeroDocumento;
            string password = user.VcPassword;

            var usuarioLogin=BDContext.TblUsuarios.Where(consulta => consulta.NumeroDocumento == numerodoc && consulta.VcPassword=password).FirstOrDefault();
            if (usuarioLogin != null)
            {
                switch (usuarioLogin.Idrol)
                {
                    case 1:
                    case 2:
                    case 3:
                    default:
                }
            }
            else
            {
                return ViewBag.mensaje = "Usuario no existe o usuario/contraseña no no valida";
                
            }
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            return View();
        }

        public IActionResult EliminarUsuario()
        {
            return View();
        }

        public IActionResult ModificarUsuario()
        {
            return View();
        }

        public IActionResult ReporteUsu()
        {
            return View();
        }
    }
}
