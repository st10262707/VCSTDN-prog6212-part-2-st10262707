using Microsoft.AspNetCore.Mvc;
using MVC_prog6212_part_2.Models;
using System.IO;
using System.Threading.Tasks;

namespace MvcProg6212Part2.Controllers
{
    public partial class SubmitClaimController : Controller

    {
        private readonly ApplicationDbContext _context;

        public SubmitClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitClaimWithDocument(Claim claim, IFormFile supportingDocument)
        {
            if (ModelState.IsValid)
            {
                if (supportingDocument != null && supportingDocument.Length > 0)
                {
                    var fileName = Path.GetFileName(supportingDocument.FileName);
                    var filePath = Path.Combine("wwwroot/uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await supportingDocument.CopyToAsync(stream);
                    }

                    claim.SupportingDocumentPath = filePath;
                }

                _context.Claims.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}