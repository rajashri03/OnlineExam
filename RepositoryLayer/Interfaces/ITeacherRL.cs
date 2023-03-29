using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ITeacherRL
    {
        public string TeacherLogin(string username, string password);
        public string AddCourse(string cousername, long userid);
        public subjectmodel AddSubject(subjectmodel model, long userid);
        public setExamModel Setexam(setExamModel model);
        public QuestionModel AddQuestions(QuestionModel QuestionModel,long userid);
        public IEnumerable<CourseEntity> GetAllCourse();
    }
}
