using System;
namespace EmployeePayslip
{
    public class TaxBracket
    {
        public int FromIncome { get; set; }
        public int? ToIncome { get; set; }
        public int BaseRate { get; set; }
        public decimal TaxPerDollar { get; set; }
    }
}
