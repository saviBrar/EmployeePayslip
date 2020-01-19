using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePayslip.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeePayslip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayslipController : Controller
    {
        private readonly IPayslipGenerator _payslipGenrator;


        //public PayslipController(IPayslipGenerator payslipGenerator, ITaxService taxService)
        //{
         //   _payslipGenrator = new PayslipGenrator(new TaxService());
        //}

        public PayslipController()
        {
            //This needs to be injected through the constructor but for this test we are creating new object
            _payslipGenrator = new PayslipGenrator(new TaxService());
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HttpPost("GeneratePayslips")]
        [Produces("text/csv", new[] { "application/json" }, Type = typeof(List<PayslipResponse>))]
        public IActionResult GeneratePayslips([FromBody] List<PayslipRequest> payslipRequests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                List<PayslipResponse> data = payslipRequests.Select(_payslipGenrator.GeneratePaySlip).ToList();
                return Ok(data);
            }
        }
    }
}
