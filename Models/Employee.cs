using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace sql_employee_graphql_api.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(200)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(200)]
        public string EmployeeEmail { get; set; }
        [Required]
        [StringLength(200)]
        public string EmployeePassword { get; set; }
        [StringLength(1000)]
        public string EmployeeImage { get; set; }
        public int EmployeeSalary { get; set; }
    }
}
