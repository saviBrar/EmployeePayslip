using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayslip
{
    public class PayslipRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be a positive integer")]
        public int AnnualSalary { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int SuperRate { get; set; }

        [Required]
        [PayslipDateHelper(ErrorMessage = "The {0} cannot be the current or a future month.")]
        public DateTime PayStartPeriod { get; set; }
    }
}
