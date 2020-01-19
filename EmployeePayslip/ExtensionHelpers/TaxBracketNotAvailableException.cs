using System;
namespace EmployeePayslip
{
    public class TaxBracketNotAvailableException : Exception
    {
        public TaxBracketNotAvailableException()
        {
        }

        public TaxBracketNotAvailableException(string message)
        : base(message)
        {
        }

        public TaxBracketNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
