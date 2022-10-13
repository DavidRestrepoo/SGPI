using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext BDContext=new SGPI_BDContext();
        public IActionResult Login()
        {
            ///Create
            TblUsuario usr = new TblUsuario();
            usr.PrimerNombre = "Mauricio";
            usr.SegundoNombre=String.Empty;
            usr.PrimerApellido = "Amariles";
            usr.SegundoApellido = "Camacho";
            usr.Email = "yonosequeponer@gmail.com";
            usr.Iddoc = 1;
            usr.Idgenero = 1;
            usr.NumeroDocumento = "123456789";
            usr.VcPassword = "123";

            BDContext.Add(usr);
            BDContext.SaveChanges();

            //Query

            //Update

            //Delete
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
