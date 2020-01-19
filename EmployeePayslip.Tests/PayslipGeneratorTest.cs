using System;
using NUnit.Framework;

namespace EmployeePayslip.Tests
{
    [TestFixture]
    public class PayslipGeneratorTest
    {
        private readonly IPayslipGenerator _payslipGenerator;
        public PayslipGeneratorTest()
        {
            _payslipGenerator = new PayslipGenrator(new TaxService());
        }

        /// <summary>
        /// Tests if a payslip is generated
        /// We can expand this test further to deep check the result data
        /// </summary>
        [Test]
        public void _generate_payslip()
        {
            //Arrange
            var payslipRequest = new PayslipRequest
            {
                FirstName = "David",
                LastName = "Rudd",
                AnnualSalary = 60050,
                SuperRate = 9,
                PayStartPeriod = new DateTime(2019, 12, 1)
            };

            //Act
            var result = _payslipGenerator.GeneratePaySlip(payslipRequest);

            //Assert
            Assert.IsNotNull(result);
        }


    }
}
