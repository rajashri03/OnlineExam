using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class StudentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string classname { get; set; }
        public string Course { get; set; }
        public string Address { get; set; }
        [ForeignKey("Users")]
        public long userId { get; set; }
        public virtual UserEntity user { get; set; }
    }
}
