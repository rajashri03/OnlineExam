using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnwer { get; set; }
        public int courseid { get; set; }
    }
}
