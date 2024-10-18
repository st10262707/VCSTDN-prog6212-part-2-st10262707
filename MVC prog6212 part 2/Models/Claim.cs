
// Models/Claim.cs
using System.ComponentModel.DataAnnotations;


namespace MVC_prog6212_part_2.Models;


    public class Claim
    {
        public int ClaimID { get; set; }
        public string LecturerName { get; set; }

        [Required(ErrorMessage = "Please enter hours worked.")]
        [Range(0, double.MaxValue, ErrorMessage = "Hours worked must be a positive number.")]
        public double HoursWorked { get; set; }

        [Required(ErrorMessage = "Please enter your hourly rate.")]
        [Range(0, double.MaxValue, ErrorMessage = "Hourly rate must be a positive number.")]
        public double HourlyRate { get; set; }

        public string AdditionalNotes { get; set; }

        public string SupportingDocumentPath { get; set; }

        public string Status { get; set; } // e.g., "Pending", "Approved", "Rejected"
    
    }


