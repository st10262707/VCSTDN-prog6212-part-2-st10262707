using Microsoft.AspNetCore.Mvc;
using MVC_prog6212_part_2.Models;

namespace MvcProg6212Part2.Controllers
{
    public class SubmitClaimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim, IFormFile supportingDocument)
        {
            // Logic to handle claim submission and file upload
            // Save claim and file to the database
            return RedirectToAction("Index");
        }
    }
}