using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayslip
{
    public class TaxService : ITaxService
    {
        private readonly IList<TaxBracket> _taxBrackets;

        /// <summary>
        /// These tax brackets should be supplied from the persisitence layer
        /// or through a json file to ensure extension of this method in future 
        /// </summary>
        public TaxService()
        {
            _taxBrackets = new List<TaxBracket>
            { 
                new TaxBracket() {FromIncome = 0, ToIncome = 18200, BaseRate = 0, TaxPerDollar = 0 },
                new TaxBracket() {FromIncome = 18200, ToIncome = 37000, BaseRate = 0, TaxPerDollar = 0.19m },
                new TaxBracket() {FromIncome = 37000, ToIncome = 80000, BaseRate = 3572, TaxPerDollar = 0.325m },
                new TaxBracket() {FromIncome = 80000, ToIncome = 180000, BaseRate = 17547, TaxPerDollar = 0.37m },
                new TaxBracket() {FromIncome = 180000, ToIncome = null, BaseRate = 54547, TaxPerDollar = 0.45m }
            };

        }

        public int CalculateSuper(int grossIncomePerMonth, int superRate)
        {
            return (grossIncomePerMonth * superRate / 100);
        }

        public int CalculateTaxPerMonth(int annualSalary, TaxBracket taxBracket)
        {
            var taxPerYear = taxBracket.BaseRate +
                            (annualSalary - taxBracket.FromIncome) * taxBracket.TaxPerDollar;

            return (int)Math.Round(taxPerYear / 12);
        }

       
        public TaxBracket GetTaxBracket(int annualSalary)
        {
            
                var returnTaxBracket =  _taxBrackets
                    .FirstOrDefault(x => (annualSalary == 0 || x.FromIncome < annualSalary) &&
                                (!x.ToIncome.HasValue || annualSalary <= x.ToIncome.Value));

            if (returnTaxBracket == null)
                throw new TaxBracketNotAvailableException("The tax bracket is not available for the given annual income");
            else return returnTaxBracket;
            
        }
    }
}
