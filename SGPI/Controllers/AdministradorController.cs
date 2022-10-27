using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //TblUsuario usuario = new TblUsuario();
            //usuario = BDContext.TblUsuarios
            //.Single(b => b.NumeroDocumento == "123456789");

            //List<TblUsuario> usuarios = new List<TblUsuario>();
            //usuarios = BDContext.TblUsuarios.ToList();

            //Update

            //var usr = BDContext.TblUsuarios.Where(cursor => cursor.Idusuario == 1).FirstOrDefault();
            //if (usr != null)
            //{
            //    usr.SegundoNombre = "Tronchatoro";
            //    BDContext.TblUsuarios.Update(usr);
            //    BDContext.SaveChanges();
            //}
            //Delete
            //var usuarioEliminar = BDContext.TblUsuarios.Where(cursor => cursor.Idusuario == 1).FirstOrDefault();
            //BDContext.TblUsuarios.Remove(usuarioEliminar);

            return View();
        }

        [HttpPost]
        public IActionResult Login(TblUsuario user)
        {
            string numerodoc = user.NumeroDocumento;
            string password = user.VcPassword;

            var usuarioLogin = BDContext.TblUsuarios.Where(consulta => consulta.NumeroDocumento == numerodoc && consulta.VcPassword == password).FirstOrDefault();
            if (usuarioLogin != null)
            {
                switch (usuarioLogin.Idrol)
                {
                    case 1:
                        CrearUsuario();
                        return View("CrearUsuario");
                    case 2:
                        /// Instancia para el controlador de coordinador
                        CoordinadorController Coordinador = new CoordinadorController();
                        /// Objeto tipo CoordinadorController
                        Coordinador.BuscarCoordinador();
                        return Redirect("Coordinador/BuscarCoordinador");
                    case 3:
                        /// Instancia para el controlador de Estudiante
                        EstudianteController Estudiante = new EstudianteController();
                        Estudiante.ActualizarEstudiante();
                        /// Objeto tipo EstudianteController
                        return Redirect("Estudiante/ActualizarEstudiante");
                    default:
                        return View();
                }
            }
            else
            {
                ViewBag.mensaje = "Usuario no existe o usuario y/o contraseña invalido";
            }
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.TblPrograma = BDContext.TblProgramas.ToList();
            ViewBag.TblGenero = BDContext.TblGeneros.ToList();
            ViewBag.TblRol = BDContext.TblRols.ToList();
            ViewBag.TblTipoDocumento = BDContext.TblTipoDocumentos.ToList();
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            //TblUsuario usuario = new TblUsuario();
            
            //usuario = BDContext.TblUsuarios
            //.Single(b => b.NumeroDocumento == "");

            //List<TblUsuario> usuarios = new List<TblUsuario>();
            //usuarios = BDContext.TblUsuarios.ToList();
            return View();
        }

        public IActionResult EliminarUsuario()
        {
            return View();
        }

        public IActionResult ModificarUsuario()
        {
            ViewBag.TblPrograma = BDContext.TblProgramas.ToList();
            ViewBag.TblGenero = BDContext.TblGeneros.ToList();
            ViewBag.TblRol = BDContext.TblRols.ToList();
            ViewBag.TblTipoDocumento = BDContext.TblTipoDocumentos.ToList();
            return View();
        }

        public IActionResult ReporteUsu()
        {
            return View();
        }
    }
}
