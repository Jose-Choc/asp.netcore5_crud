using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_info_netcore5.Data;
using test_info_netcore5.Models;

namespace test_info_netcore5.Controllers
{
    //Controlador que verifica los datos para acceso en los datos privilegiados

    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "_usuario";
        //injectar en el controlador la clase donde esta la esquematización de la base de datos.
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: AuthorizeLogin
        public ActionResult Index()
        {
            ViewBag.Error = "Credenciales invalidas";
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string Pass)
        {
            try
            {
                Users usuario = _context.users.Where(x => x.UserName == user.Trim() && x.PasswordHash == Pass.Trim()).FirstOrDefault();
                if (usuario == null)
                {
                    ViewBag.error = "Credenciales incorrectas";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString(SessionKeyName,usuario.Id);
                    return RedirectToAction("Index", "Home");
                }


            }
            catch(Exception error)
            {
                ViewBag.error = error;
                return View();
            }
        }
    }
}
