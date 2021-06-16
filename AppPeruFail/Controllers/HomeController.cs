using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppPeruFail.Models;
using AppPeruFail.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppPeruFail.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager, 
        ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var fail=_context.Fails.ToList();
            return View(fail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SubirFail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubirFail(String Titulo, String Foto)
        {
            var userID = _userManager.GetUserName(User);
            if (ModelState.IsValid){
                Fail f = new Fail();
                f.UserID = userID;
                f.Titulo = Titulo;
                f.Foto = Foto;
                _context.Add(f);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Comentarios()
        {
            var c=_context.Comentarios.Include(x => x.Fail).ToList();
            return View(c);
        }
        public async Task<IActionResult> Comentarios(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Fail = await _context.Fails.FindAsync(id);
            if (Fail == null)
            {
                return NotFound();
            }
            return View(Fail);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
