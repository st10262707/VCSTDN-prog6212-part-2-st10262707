using Microsoft.AspNetCore.Mvc;
using MVC_prog6212_part_2.Models;
using System.Linq;

namespace MvcProg6212Part2.Controllers
{
    public class VerifyClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VerifyClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var claims = _context.Claims.Where(c => c.Status == "Pending").ToList();
            return View(claims);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}