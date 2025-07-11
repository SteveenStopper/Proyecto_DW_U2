using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_development_project_U2.Controllers;
using Web_development_project_U2.Models;

namespace Web_development_project_U2.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUsuario = (Usuarios)filterContext.HttpContext.Session["User"];

            if (oUsuario == null)
            {
                if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Usuario" &&
                    filterContext.ActionDescriptor.ControllerDescriptor.ControllerType != typeof(UsuarioController))
                {
                    filterContext.Result = new RedirectResult("~/Usuario/Login");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }

}