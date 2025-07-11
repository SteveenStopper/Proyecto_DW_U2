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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            int userId = (int)Session["UserId"];
            return View();
        }

        public ActionResult Admin()
        {
            List<ListLibroViewModel> lst;
            using (bibliotecaEntities db = new bibliotecaEntities())
            {
                lst = (from c in db.Libros
                       select new ListLibroViewModel
                       {
                           id = c.id,
                           titulo = c.titulo,
                           autor = c.autor,
                           anio_publicacion = c.anio_publicacion ?? 0,
                           categoria = c.categoria
                       }).ToList();
            }
            return View(lst);
        }

    }

}