using Microsoft.AspNetCore.Mvc;

// Pages/VerifyClaims.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcProg6212Part2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Claim = Models.CMCS.Models.Claim;


namespace MvcProg6212Part2.Controllers
{

    public class VerifyClaimsModel : PageModel
    {
        private readonly ApplicationDbContext _context; // Assuming you have a DbContext for database access
        private List<Models.CMCS.Models.Claim> claims;

        public VerifyClaimsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Claim> Claims { get => claims; set => claims = value; }

        public void OnGet() =>
            // Load pending claims from the database (non-functional placeholder)
            Claims = _context.Claims.Where(c => c.Status == "Pending")
            .ToList();

        public IActionResult OnPostApprove(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges(); // Save changes to the database (non-functional placeholder)
            }

            return RedirectToPage(); // Refresh the page to show updated claims
        }

        public IActionResult OnPostReject(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges(); // Save changes to the database (non-functional placeholder)
            }

            return RedirectToPage(); // Refresh the page to show updated claims
        }
    }

}