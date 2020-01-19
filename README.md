# EmployeePayslip

Summary
This API generates an employee payslip based on the supplied information. 

Built With

1. .Net Core 3.0 Web API
2. C#
3. NUnit
4. JSON

Assumptions
1. There is no persistence layer
2. We are not maintaining any employee information 
3. The sole purpose of the API is to generate a payslip based on the supplied information
4. No decimal values are used


Future Enhancements 
1. Async functionality can be added to ensure parallelism
2. Persistence layer can be added to record any payslip generation


To Run

URL - https://localhost:5001/api/Payslip

Sample data
[{
	"FirstName":"David",
	"LastName":"Rudd",
	"AnnualSalary":60050,
	"SuperRate":9,
	"PayStartPeriod":"2019-03-01"
},
{
	"FirstName":"Ryan",
	"LastName":"Chen",
	"AnnualSalary":120000,
	"SuperRate":10,
	"PayStartPeriod":"2019-03-01"
}]


Result 
[
    {
        "fullName": "David Rudd",
        "payPeriod": "1 March - 31 March",
        "grossIncome": 5004,
        "incomeTax": 922,
        "netIncome": 4082,
        "super": 450
    },
    {
        "fullName": "Ryan Chen",
        "payPeriod": "1 March - 31 March",
        "grossIncome": 10000,
        "incomeTax": 2696,
        "netIncome": 7304,
        "super": 1000
    }
]
