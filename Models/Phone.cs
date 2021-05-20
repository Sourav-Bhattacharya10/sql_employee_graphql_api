using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace sql_employee_graphql_api.Models
{
    [Table("Phone")]
    public partial class Phone
    {
        public Phone()
        {
            Contacts = new HashSet<Contact>();
        }

        [Column("SerialID")]
        public int SerialId { get; set; }
        [Key]
        [Column("PhoneID")]
        [StringLength(12)]
        public string PhoneId { get; set; }
        [Required]
        [StringLength(30)]
        public string PhoneType { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public bool IsDefault { get; set; }

        [InverseProperty(nameof(Contact.Phone))]
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
