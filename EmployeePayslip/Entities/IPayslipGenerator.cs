
namespace EmployeePayslip
{
    public interface IPayslipGenerator
    {
        PayslipResponse GeneratePaySlip(PayslipRequest payslipRequest);
    }
}
