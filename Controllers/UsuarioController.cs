using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_development_project_U2.Filters;
using Web_development_project_U2.Models;
using Web_development_project_U2.Models.ViewModels;

namespace Web_development_project_U2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string email_usu, string pass)
        {
            try
            {
                using (bibliotecaEntities db = new bibliotecaEntities())
                {
                    var lst = from u in db.Usuarios
                              where u.correo == email_usu && u.password_usu == pass
                              select u;

                    if (lst.Count() > 0)
                    {
                        Usuarios oUsuario = lst.First();
                        Session["User"] = oUsuario;
                        Session["UserId"] = oUsuario.id_usu;
                        if (oUsuario.id_rol == 1)
                        {
                            return Content("1");
                        }
                        else
                        {
                            return Content ("2");
                        }
                    }
                    else
                    {
                        return Content("Usuario no válido");
                    }
                }
            }
            catch (Exception e)
            {
                return Content("Ocurrio un error :'c" + e.Message);
            }
        }

        public ActionResult CerrarSesion()
        {
            Session["User"] = null;
            Session["UserId"] = null;
            return RedirectToAction("Login", "Usuario");
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(UsuarioViewModel usuarioModel)
        {
            try
            {
                //Validar los data Anotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido, guardamos los datos en la base
                    using (bibliotecaEntities db = new bibliotecaEntities())
                    {
                        var oUsuario = new Usuarios();
                        oUsuario.nombre = usuarioModel.Nombre;
                        oUsuario.apellido = usuarioModel.Apellido;
                        oUsuario.correo = usuarioModel.Correo;
                        oUsuario.password_usu = usuarioModel.Password_usu;
                        oUsuario.telefono = usuarioModel.Telefono;
                        oUsuario.direccion = usuarioModel.Direccion;
                        oUsuario.id_rol = 1;

                        db.Usuarios.Add(oUsuario);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Usuario/Login");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar()
        {
            int userId = (int)Session["UserId"];
            UsuarioViewModel usuario = new UsuarioViewModel();
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                var oUsuario = db.Usuarios.Find(userId);
                usuario.Nombre = oUsuario.nombre;
                usuario.Apellido = oUsuario.apellido;
                usuario.Telefono = oUsuario.telefono;
                usuario.Direccion = oUsuario.direccion;
                usuario.Id_usu = oUsuario.id_usu;
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioViewModel usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int userId = (int)Session["UserId"];
                    using (bibliotecaEntities db = new bibliotecaEntities())
                    {
                        var oUsuario = db.Usuarios.Find(userId);
                        oUsuario.nombre = usuarioModel.Nombre;
                        oUsuario.apellido = usuarioModel.Apellido;
                        oUsuario.telefono = usuarioModel.Telefono;
                        oUsuario.direccion = usuarioModel.Direccion;

                        db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Home/Index");
                }
                return View(usuarioModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Eliminar()
        {
            int userId = (int)Session["UserId"];
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                // Eliminar las filas relacionadas en la tabla Prestamos
                var prestamosRelacionados = db.Prestamos.Where(p => p.usuario_id == userId);
                db.Prestamos.RemoveRange(prestamosRelacionados);

                // Eliminar el usuario de la tabla Usuarios
                var oUsuario = db.Usuarios.Find(userId);
                if (oUsuario != null)
                {
                    db.Usuarios.Remove(oUsuario);
                }

                db.SaveChanges();
            }
            return Redirect("~/Usuario/Login");
        }

    }
}