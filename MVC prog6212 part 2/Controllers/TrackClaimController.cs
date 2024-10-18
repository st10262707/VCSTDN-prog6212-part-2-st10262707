using Microsoft.AspNetCore.Mvc;
using MVC_prog6212_part_2.Models;
using System.Linq;

namespace MvcProg6212Part2.Controllers
{
    public class TrackClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }
    }
}
