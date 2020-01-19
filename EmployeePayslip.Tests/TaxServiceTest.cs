using System;
using NUnit.Framework;

namespace EmployeePayslip.Tests
{
    [TestFixture]
    public class TaxServiceTest
    {
        private readonly ITaxService _taxService;
        public TaxServiceTest()
        {
            _taxService = new TaxService();
        }

        /// <summary>
        /// Testing that a correct tax bracket is returned
        /// </summary>
        /// <param name="annualIncome"></param>
        [TestCase(60050)]
        public void _get_tax_rate(int annualIncome)
        {
            //Arrange
            //Act
            TaxBracket taxBracket = _taxService.GetTaxBracket(annualIncome);

            //Assert
            Assert.AreEqual(taxBracket.BaseRate, 3572);
            Assert.AreEqual(taxBracket.TaxPerDollar, 0.325m);
        }

        /// <summary>
        /// Calculate super for monthly income
        /// </summary>
        /// <param name="annualIncome"></param>
        /// <param name="superRate"></param>
        [TestCase(60050, 9)]
        public void _get_super(int annualIncome, int superRate)
        {
            //Arrange
            int monthlyGrossIncome = annualIncome / 12;

            //Act
            var super = _taxService.CalculateSuper(monthlyGrossIncome, superRate);

            //Assert
            Assert.AreEqual(super, 450);
        }

        /// <summary>
        /// In real world the gross income cannot be less than 0.
        /// To test our method that an exception is thrown we are passing in a negative
        /// The vallidation to ensure gross income is not less than 0 should happen on the client end
        /// </summary>
        /// <param name="annualIncome"></param>
        [TestCase(-50000)]
        public void _get_tax_rate_exception_thrown(int annualIncome)
        {
            //Should throw an exception
            Assert.Throws<TaxBracketNotAvailableException>(() => _taxService.GetTaxBracket(annualIncome));
        }
    }
}
