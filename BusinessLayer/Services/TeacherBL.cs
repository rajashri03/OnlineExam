using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class TeacherBL : ITeacherBL
    {
        ITeacherRL rl;
        public TeacherBL(ITeacherRL rl)
        {
            this.rl = rl;
        }

        public string TeacherLogin(string username, string password)
        {
            try
            {
                return rl.TeacherLogin(username, password);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string AddCourse(string cousername, long userid)
        {
            try
            {
                return rl.AddCourse(cousername,userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public subjectmodel AddSubject(subjectmodel model,long userid)
        {
            try
            {
                return rl.AddSubject(model,userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public setExamModel Setexam(setExamModel model)
        {
            try
            {
                return rl.Setexam(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public QuestionModel AddQuestions(QuestionModel QuestionModel, long userid)
        {
            try
            {
                return rl.AddQuestions(QuestionModel,userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<CourseEntity> GetAllCourse()
        {
            try
            {
                return rl.GetAllCourse();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
