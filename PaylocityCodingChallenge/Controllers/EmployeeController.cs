using PaylocityCodingChallenge.Business.Interfaces;
using PaylocityCodingChallenge.Data.Interfaces;
using PaylocityCodingChallenge.Models;
using PaylocityCodingChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PaylocityCodingChallenge.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<EmployeeViewModel> AddEmployee([FromBody] EmployeeViewModel employee)
        {
            return (EmployeeViewModel) await _employeeService.AddEmployeeAsync((Employee)employee);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            return (await _employeeRepository.GetAllEmployeesAsync()).Select(x => (EmployeeViewModel)x);
        }

        [HttpGet]
        public async Task<EmployeeViewModel> GetEmployee([FromUri]long employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if(employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return (EmployeeViewModel)employee;
        }
    }
}
