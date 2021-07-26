using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_info_netcore5.Controllers;
using test_info_netcore5.Models;

namespace test_info_netcore5.Filter
{
    public class VerificaSession : ActionFilterAttribute
    {
        public const string SessionKeyName = "_usuario";
        private Users usuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                //usuario = (Users)HttpContext.Current.Session["User"];
                //ISession session = HttpContext.Session;
                //var sessiones = session.GetString(SessionKeyName);

                if (this.usuario == null)
                {
                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }
                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }
    }
}
