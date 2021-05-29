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

        private readonly IStoredProcedureConfigurationEntity _empStoredProcedureConfigurationEntity;

        public EmployeeController(ILogger<EmployeeController> logger, IRepository<Employee> empRepo, IStoredProcedureConfigurations spConfigs)
        {
            _logger = logger;
            _empRepository = empRepo;
            _empStoredProcedureConfigurationEntity = spConfigs.Entities.SingleOrDefault(item => item.Name == "Employee");
        }

        // GET: api/employees
        [HttpGet("employees")]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = _empRepository.GetAll(_empStoredProcedureConfigurationEntity.GetAll);
            
            if(employees == null){
                return StatusCode(500);
            }

            return employees;
        }

        // GET: api/employees/2
        [HttpGet("employees/{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var param = new SqlParameter("@EmployeeID", id);
            var foundEmployee = _empRepository.Get(_empStoredProcedureConfigurationEntity.Get, param);

            if(foundEmployee ==  null){
                return StatusCode(500);
            }

            return Ok(foundEmployee);
        }
    }
}