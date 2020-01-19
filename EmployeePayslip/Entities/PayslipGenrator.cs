using System;

namespace EmployeePayslip
{
    public class PayslipGenrator : IPayslipGenerator
    {
        private readonly ITaxService _taxService;
        public PayslipGenrator(ITaxService taxService)
        {
            _taxService = taxService;
        }

        /// <summary>
        /// Generates a payslip as per the payslip request
        /// </summary>
        /// <param name="payslipRequest"></param>
        /// <returns></returns>
        public PayslipResponse GeneratePaySlip(PayslipRequest payslipRequest)
        {
            var payslipMonth = payslipRequest.PayStartPeriod;

            var grossIncome = (int)Math.Round((decimal)(payslipRequest.AnnualSalary / 12));
            var super = (int)Math.Round((decimal)(grossIncome * payslipRequest.SuperRate / 100));
            var payPeriod = string.Format("1 {0} - {1} {0}", payslipMonth.ToString("MMMM"),
                new DateTime(payslipMonth.Year, payslipMonth.Month, 1).AddMonths(1).AddDays(-1).Day);
            var taxBracket = _taxService.GetTaxBracket(payslipRequest.AnnualSalary);
            var incomeTax = _taxService.CalculateTaxPerMonth(payslipRequest.AnnualSalary, taxBracket);
            var netIncome = grossIncome - incomeTax;

            return new PayslipResponse()
            {
                FullName = string.Format("{0} {1}", payslipRequest.FirstName.Trim(), payslipRequest.LastName.Trim()),
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                NetIncome = netIncome,
                Super = super,
                PayPeriod = payPeriod
            };
        }

    }
}
