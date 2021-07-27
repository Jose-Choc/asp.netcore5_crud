using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using test_info_netcore5.Data;
using test_info_netcore5.Models;

namespace test_info_netcore5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //encapsular la clase donde esta registrado la base de datos
        private readonly ApplicationDbContext _context;
        


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Clients> clients = _context.clients.ToList();
            ViewBag.clientes = clients;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int? Id)
        {
            Clients client = _context.clients.Where(x => x.Id == Id).FirstOrDefault();

            return View(client);
        }
        public IActionResult Delete(int? Id)
        {
            Clients client = _context.clients.Where(x => x.Id == Id).FirstOrDefault();
            return View(client);
        }
        [HttpPost]
        public async Task<ActionResult> Add(string Firstname, string Lastname, string Address, string Nit)
        {
            try
            {
                _context.clients.Add(new Clients()
                {
                    Firstname = Firstname,
                    Lastname = Lastname,
                    Address = Address,
                    Nit = Nit
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");

            }catch(Exception error)
            {
                ViewBag.error = error;
                return View();
            }
        }
        [HttpPost()]
        public async Task<ActionResult> Edit(int Id, string Firstname, string Lastname, string Address, string Nit)
        {
            try
            {
                Clients client = _context.clients.FirstOrDefault(x => x.Id == Id);
                client.Firstname = Firstname;
                client.Lastname = Lastname;
                client.Address = Address;
                client.Nit = Nit;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch(Exception error)
            {
                ViewBag.error = error;
                return View();
            }

        }
        [HttpPost()]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                Clients client = _context.clients.FirstOrDefault(x => x.Id == Id);
                _context.clients.Remove(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception error)
            {
                ViewBag.error = error;
                return View();
            }
        }
    }
}
