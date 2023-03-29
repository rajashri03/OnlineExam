using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class SubjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Subjectid { get; set; }
        public int Courseid { get; set; }
        public string SubjectName { get; set; }
        [ForeignKey("Users")]
        public long userid { get; set; }
        public virtual UserEntity user { get; set; }
    }
}
