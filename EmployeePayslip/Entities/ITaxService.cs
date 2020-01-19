using System;
namespace EmployeePayslip
{
    public interface ITaxService
    {
        TaxBracket GetTaxBracket(int annualSalary);
        int CalculateTaxPerMonth(int annualSalary, TaxBracket taxBracket);
        int CalculateSuper(int grossIncomePerMonth, int superRate);

    }
}
