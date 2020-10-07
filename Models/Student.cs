using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace microservice_1.Models
{
    [Table("student")]
    public partial class Student
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("name", TypeName = "varchar(45)")]
        public string Name { get; set; }
        [Column("class", TypeName = "int(11)")]
        public int? Class { get; set; }
        [Column("grade", TypeName = "int(11)")]
        public int? Grade { get; set; }
    }
}
