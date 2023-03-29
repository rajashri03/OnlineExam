using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.AppContext;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class TeacherRL : ITeacherRL
    {
        private readonly Context context;
        private readonly IConfiguration Iconfiguration;
        public TeacherRL(Context context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }
        public string TeacherLogin(string username, string password)
        {
            try
            {
                UserEntity user = new UserEntity();
                user = this.context.Users.FirstOrDefault(x => x.Email == username && x.userType == "Teacher");
                string dPass = Decrpt(user.Password);
                var id = user.userId;
                if (dPass == password && user != null)
                {
                    var token = this.TokenByID(id);
                    return token;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Decrpt(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string TokenByID(long userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Iconfiguration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", userid.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string AddCourse(string coursename ,long userid)
        {
            try
            {
                CourseEntity addcourse = new CourseEntity();
                addcourse.Coursename = coursename;
                addcourse.userid = userid;
                this.context.courses.Add(addcourse);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return coursename;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public subjectmodel AddSubject(subjectmodel model, long userid)
        {
            try
            {
                SubjectEntity addsubjects = new SubjectEntity();
                addsubjects.Courseid = model.courseid;
                addsubjects.SubjectName = model.subjectname;
                addsubjects.userid = userid;
                this.context.Subjects.Add(addsubjects);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return model;
                }
                return null;
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
                SetExamEntity addsubjects = new SetExamEntity();
                addsubjects.courseid = model.courseid;
                addsubjects.subjectid = model.subjectid;
                addsubjects.examname = model.examname;
                addsubjects.examdiscription = model.examdiscription;
                addsubjects.examdate = model.examdate;
                addsubjects.examDuration = model.examDuration;
                addsubjects.exampassmarks = model.exampassmarks;
                addsubjects.examtotalmarks = model.examtotalmarks;
                addsubjects.examstarttime = model.examstarttime;
                addsubjects.endTime = model.endTime;
                addsubjects.totalquestion = model.totalquestion;
                addsubjects.singleQuestionmarks = model.singleQuestionmarks;
                this.context.Exams.Add(addsubjects);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return model;
                }
                return null;
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
                QuestionEntity addsubjects = new QuestionEntity();
                addsubjects.Question = QuestionModel.Question;
                addsubjects.OptionA = QuestionModel.OptionA;
                addsubjects.OptionB = QuestionModel.OptionB;
                addsubjects.OptionC = QuestionModel.OptionC;
                addsubjects.OptionD = QuestionModel.OptionD;
                addsubjects.CorrectAnswer = QuestionModel.CorrectAnwer;
                addsubjects.courseid = QuestionModel.courseid;
                addsubjects.userid = userid;
                this.context.Questions.Add(addsubjects);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return QuestionModel;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<CourseEntity> GetAllCourse()
        {
            return context.courses.ToList();
        }
    }
}
