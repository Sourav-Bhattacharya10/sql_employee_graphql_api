using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace sql_employee_graphql_api.Models
{
    [Table("Contact")]
    public partial class Contact
    {
        [Column("SerialID")]
        public int SerialId { get; set; }
        [Key]
        [Column("ContactID")]
        [StringLength(11)]
        public string ContactId { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactEmail { get; set; }
        [Column(TypeName = "date")]
        public DateTime ContactBirthday { get; set; }
        [Column("PhoneID")]
        [StringLength(12)]
        public string PhoneId { get; set; }

        [ForeignKey(nameof(PhoneId))]
        [InverseProperty("Contacts")]
        public virtual Phone Phone { get; set; }
    }
}
