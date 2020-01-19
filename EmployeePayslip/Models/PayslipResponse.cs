using System;
namespace EmployeePayslip
{
    public class PayslipResponse
    {
        public string FullName { get; set; }

        public string PayPeriod { get; set; }

        public int GrossIncome { get; set; }

        public int IncomeTax { get; set; }

        public int NetIncome { get; set; }

        public int Super { get; set; }
    }
}
