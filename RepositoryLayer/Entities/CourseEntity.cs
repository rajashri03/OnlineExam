﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class CourseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Courseid { get; set; }
        public string Coursename { get; set; }
        [ForeignKey("Users")]
        public long userid { get; set; }
        public virtual UserEntity user { get; set; }

    }
}
