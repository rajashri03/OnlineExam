using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class SetExamEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long examsetupid { get; set; }
        public string examname { get; set; }
        public string examdiscription { get; set; }
        public DateTime examdate { get; set; }
        public string examDuration { get; set; }
        public string exampassmarks { get; set; }
        public string examtotalmarks { get; set; }
        public string examstarttime { get; set; }
        public string endTime { get; set; }
        public int totalquestion { get; set; }
        public string singleQuestionmarks { get; set; }
      
        [ForeignKey("courses")] 
        public int courseid { get; set; }
        public virtual CourseEntity courses { get; set; }
        [ForeignKey("subjects")]
        public int subjectid { get; set; }
        public virtual SubjectEntity subjects { get; set; }

    }
}
