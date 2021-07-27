using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_info_netcore5.Data;
using test_info_netcore5.Models;

namespace test_info_netcore5.Controllers
{
    [Authorize]
    public class ReporteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReporteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Clients> clients =  _context.clients.ToList();
            return new ViewAsPdf("Index",clients)
            {

            };
        }
    }
}
