using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using MVC_prog6212_part_2.Models;
using System.IO;
using System.Threading.Tasks;

namespace MvcProg6212Part2.Controllers
{
    public class SubmitClaimModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SubmitClaimModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MVC_prog6212_part_2.Models.Claim Claim { get; set; } // Use fully qualified name

        // Property to hold the uploaded file name for display
        public string UploadedFileName { get; set; }

        public void OnGet()
        {
            // Non-functional placeholder for GET request logic
        }

        public async Task<IActionResult> OnPostAsync(IFormFile SupportingDocument)
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return to the same page with validation errors
            }

            if (SupportingDocument != null && SupportingDocument.Length > 0)
            {
                // Validate file size (limit to 2 MB)
                if (SupportingDocument.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("SupportingDocument", "File size must not exceed 2 MB.");
                    return Page();
                }

                // Validate file type
                var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" };
                var extension = Path.GetExtension(SupportingDocument.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("SupportingDocument", "Only PDF, DOCX, and XLSX files are allowed.");
                    return Page();
                }

                // Generate a unique file name and save it securely
                var fileName = Path.GetFileName(SupportingDocument.FileName);
                var filePath = Path.Combine("wwwroot/uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SupportingDocument.CopyToAsync(stream);
                }

                // Store the file path in the claim object
                Claim.SupportingDocumentPath = filePath;
                UploadedFileName = fileName; // Store the uploaded file name for display
            }

            // Save claim to database (non-functional placeholder)
            _context.Claims.Add(Claim);
            await _context.SaveChangesAsync();

            return RedirectToPage("Confirmation"); // Redirect to confirmation page after submission
        }
    }
}