using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_development_project_U2.Models.ViewModels;
using Web_development_project_U2.Models;
using System.ComponentModel.DataAnnotations;

namespace Web_development_project_U2.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult prestamo()
        {
            int userId = (int)Session["UserId"];
            List<ListPrestamoViewModel> lst;
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                lst = (from p in db.Prestamos
                       join l in db.Libros on p.libro_id equals l.id
                       where p.usuario_id == userId
                       select new ListPrestamoViewModel
                       {
                           Id = p.id,
                           UsuarioId = p.usuario_id,
                           LibroId = p.libro_id,
                           FechaPrestamo = p.fecha_prestamo,
                           FechaDevolucion = p.fecha_devolucion ?? default(DateTime),
                           TituloLibro = l.titulo
                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult Nuevo(int libroId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int userId = (int)Session["UserId"];
                    using (bibliotecaEntities db = new bibliotecaEntities())
                    {
                        var oPrestamo = new Prestamos();
                        oPrestamo.usuario_id = userId;
                        oPrestamo.libro_id = libroId;
                        oPrestamo.fecha_prestamo = DateTime.Now;
                        oPrestamo.fecha_devolucion = DateTime.Now.AddDays(30);

                        db.Prestamos.Add(oPrestamo);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/Prestamo/prestamo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            PrestamoViewModel prestamo = new PrestamoViewModel();
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                var oPrestamo = db.Prestamos.Find(id);
                prestamo.LibroId = oPrestamo.libro_id;
                prestamo.UsuarioId = oPrestamo.usuario_id;
                prestamo.FechaPrestamo = oPrestamo.fecha_prestamo;
                prestamo.FechaDevolucion = oPrestamo.fecha_devolucion ?? default(DateTime);
                prestamo.Id = oPrestamo.id;

                // Obtener la lista de libros y asignarla al ViewBag
                var libros = db.Libros.Select(l => new SelectListItem { Value = l.id.ToString(), Text = l.titulo }).ToList();
                ViewBag.LibrosList = new SelectList(libros, "Value", "Text");
            }
            return View(prestamo);
        }

        [HttpPost]
        public ActionResult Editar(PrestamoViewModel prestamoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (bibliotecaEntities db = new bibliotecaEntities())
                    {
                        var oPrestamo = db.Prestamos.Find(prestamoModel.Id);
                        oPrestamo.libro_id = prestamoModel.LibroId; // Ya es de tipo int

                        // Validar la fecha de devolución
                        if (prestamoModel.FechaDevolucion <= DateTime.Now)
                        {
                            ModelState.AddModelError("FechaDevolucion", "La fecha de devolución debe ser mayor a la fecha actual.");
                            var libros = db.Libros.Select(l => new SelectListItem { Value = l.id.ToString(), Text = l.titulo }).ToList();
                            ViewBag.LibrosList = new SelectList(libros, "Value", "Text");
                            return View(prestamoModel);
                        }

                        oPrestamo.fecha_prestamo = DateTime.Now;
                        oPrestamo.fecha_devolucion = prestamoModel.FechaDevolucion;

                        db.Entry(oPrestamo).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Prestamo/prestamo");
                }

                // Si el modelo no es válido, se recupera la lista de libros para rellenar el DropDownList
                using (bibliotecaEntities db = new bibliotecaEntities())
                {
                    var libros = db.Libros.Select(l => new SelectListItem { Value = l.id.ToString(), Text = l.titulo }).ToList();
                    ViewBag.LibrosList = new SelectList(libros, "Value", "Text");
                }

                return View(prestamoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                var oPrestamo = db.Prestamos.Find(id);
                db.Prestamos.Remove(oPrestamo);
                db.SaveChanges();
            }
            return Redirect("~/Prestamo/prestamo");
        }
    }
}
