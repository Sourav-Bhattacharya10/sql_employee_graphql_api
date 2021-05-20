using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using sql_employee_graphql_api.Models;
using sql_employee_graphql_api.Repositories;

namespace sql_employee_graphql_api.Controllers
{
    [ApiController]
    [Route("api/[controller]controller")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IRepository<Employee> _empRepository;

        // private readonly 

        public EmployeeController(ILogger<EmployeeController> logger, IRepository<Employee> empRepo)
        {
            _logger = logger;
            _empRepository = empRepo;
        }

        // // GET: api/employees
        // [HttpGet("employees")]
        // public IEnumerable<Employee> GetAllEmployees()
        // {
        //     IEnumerable<Employee> employees = _context.Employees.Where(emp => emp.EmployeeId != 0);
            
        //     return employees;
        // }

        // GET: api/employees
        [HttpGet("employees/{id}")]
        public Employee GetEmployee(int id)
        {
            var param = new SqlParameter("@EmployeeID", id);
            return _empRepository.Get("GetEmployee @EmployeeID", param);
        }
    }
}