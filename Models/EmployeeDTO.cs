namespace sql_employee_graphql_api.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeImage { get; set; }
        public int EmployeeSalary { get; set; }
    }
}