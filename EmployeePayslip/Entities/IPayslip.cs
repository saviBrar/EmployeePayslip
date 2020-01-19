using System;
namespace EmployeePayslip
{
    public interface IPayslip
    {
        string FullName { get; set; }
        string PayPeriod { get; set; }

        //Should be decimal but to satisfy the conditions of the test we are considering all these a positive integer
        int GrossIncome { get; set; } 
        int NetIncome { get; set; }
        int Tax { get; set; }
        int Super { get; set; }
    }
}
