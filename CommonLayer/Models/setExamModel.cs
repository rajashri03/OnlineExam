using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class setExamModel
    {
        public int courseid { get; set; }
        public int subjectid { get; set; }
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

    }
}
