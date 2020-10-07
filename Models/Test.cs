using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microservice_1.Models
{
    public partial class Test
    {
        [Key]
        [Column("id", TypeName = "varchar(11)")]
        public string Id { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("surname", TypeName = "varchar(255)")]
        public string Surname { get; set; }
        [Column("sex", TypeName = "int(255)")]
        public int? Sex { get; set; }
        [Column("birthyear", TypeName = "year(4)")]
        public short? Birthyear { get; set; }
        [Column("birthdate", TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        [Column("mobile", TypeName = "varchar(255)")]
        public string Mobile { get; set; }
    }
}
