using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPI_BDContext BDContext = new SGPI_BDContext();



        public IActionResult ActualizarEstudiante(int? Idusuario)
        {
            TblUsuario usuario = BDContext.TblUsuarios.Find(Idusuario);
            if (usuario != null)
            {
                ViewBag.TblPrograma = BDContext.TblProgramas.ToList();
                ViewBag.TblGenero = BDContext.TblGeneros.ToList();
                ViewBag.TblTipoDocumento = BDContext.TblTipoDocumentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/ActualizarEstudiante/?Idusuario=");
            }
        }

        //public IActionResult ActualizarEstudiante()
        //{
        //    return View();

        //}

        [HttpPost]
        public IActionResult ActualizarEstudiante(TblUsuario usuarios)
        {            
        //    int numerodocumento = usuarios.Idusuario;
        //    var usuarioActualizar = BDContext.TblUsuarios.Where(consulta => consulta.Idusuario == numerodocumento).FirstOrDefault();
        //    usuarioActualizar.NumeroDocumento = usuarios.NumeroDocumento;
        //    usuarioActualizar.Iddoc = usuarios.Iddoc;
        //    usuarioActualizar.PrimerNombre = usuarios.PrimerNombre;
        //    usuarioActualizar.SegundoNombre = usuarios.SegundoNombre;
        //    usuarioActualizar.PrimerApellido = usuarios.PrimerApellido;
        //    usuarioActualizar.SegundoApellido = usuarios.SegundoApellido;
        //    usuarioActualizar.Idgenero = usuarios.Idgenero;
        //    usuarioActualizar.Idprograma = usuarios.Idprograma;
        //    usuarioActualizar.Email = usuarios.Email;
        //    //TblEstudiante estudiante = new TblEstudiante();
        //    //estudiante.Idusuario = usuarios.Idusuario;
        //    //estudiante.Egresado = false;
        //    //estudiante.Archivo = "";
        //    //BDContext.Add(estudiante);
        //    //BDContext.SaveChanges();
        //    ViewBag.mensaje = "Se ha actualizado con exito";
        //    BDContext.Update(usuarioActualizar);
        //    BDContext.SaveChanges();
        //    return Redirect("/Estudiante/ActualizarEstudiante/?Idusuario=" + usuarioActualizar.Idusuario);

            usuarios.Idrol=3;
           ViewBag.Mensaje ="Se Actualizo con exito";
            ViewBag.idusuario=usuarios.Idusuario;
            BDContext.Update(usuarios);
            BDContext.SaveChanges();            
            ViewBag.TblPrograma = BDContext.TblProgramas.ToList();
            ViewBag.TblGenero = BDContext.TblGeneros.ToList();
            ViewBag.TblTipoDocumento = BDContext.TblTipoDocumentos.ToList();
            return View(usuarios);
    }

        public IActionResult PagoEstudiante()
        {
            //TblUsuario usuario = new TblUsuario();
            //var usr = BDContext.TblUsuarios.Where(consulta => consulta.Idusuario == IdUsuario).FirstOrDefault();
            //ViewBag.idusuario = usr.Idusuario;
            //List<TblPago> listpago = new List<TblPago>();
            //listpago = BDContext.TblPagos.ToList();
            //ViewBag.listapgs = listpago;
            
            return View();
        }

        [HttpPost]
        public IActionResult PagoEstudiante(TblPago usuario)
        {
            usuario.Estado = true;
            
            ViewBag.mensaje = "Pago Enviado";
            BDContext.TblPagos.Add(usuario);
            BDContext.SaveChanges();

            //var user = BDContext.TblUsuarios.Where(consulta => consulta.Idusuario == idusuario).FirstOrDefault();

            //TblUsuario usr = BDContext.TblUsuarios.Find(IdUsuario);

            //BDContext.TblPagos.Add(pago);
            //BDContext.SaveChanges();


            //TblEstudiante est = new TblEstudiante();
            //est.Idusuario = usr.Idusuario;
            //est.Idpago = pago.IdPagos;
            //est.Egresado = false;

            //BDContext.TblEstudiantes.Add(est);
            //BDContext.SaveChanges();

            //TblUsuario usuario = new TblUsuario();
            //var usrc = BDContext.TblUsuarios.Where(consulta => consulta.Idusuario == IdUsuario).FirstOrDefault();
            //ViewBag.idusuario = usrc.Idusuario;

            //List<TblPago> listpago = new List<TblPago>();
            //listpago = BDContext.TblPagos.ToList();
            //ViewBag.listapgs = listpago;
            return View();
        }
    }
}
