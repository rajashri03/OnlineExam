using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.AppContext;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class StudentRL:IStudentRL
    {
        private readonly Context context;
        private readonly IConfiguration Iconfiguration;
        public StudentRL(Context context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }
        public string StudentLogin(string username, string password)
        {
            try
            {
                StudentEntity user = new StudentEntity();
                user = this.context.StudentInfo.FirstOrDefault(x => x.Email == username &&x.userType=="Student");
                string dPass = Decrpt(user.Password);
                var id = user.studentid;
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
                Subject = new ClaimsIdentity(new[] { new Claim("studentid", userid.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public Studentmodel StudentRegistation(Studentmodel user)
        {
            try
            {
                StudentEntity users = new StudentEntity();
                users.FirstName = user.FirstName;
                users.LastName = user.LastName;
                users.Email = user.Email;
                users.Password = EncryptPass(user.Password);
                users.userType = user.userType;
                users.courseid = user.courseid;
                this.context.StudentInfo.Add(users);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return user;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EncryptPass(string password)
        {
            try
            {
                string msg = "";
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                msg = Convert.ToBase64String(encode);
                return msg;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GotoExam(int subjectid)
        {

            //var values = context.Exams.FromSqlRaw($"execute gotoexam {subjectid};");
            //return values.ToString();
            DateTime dateTime = DateTime.UtcNow;
            //var query = (from setexams in context.Exams
            //             where setexams.subjectid == subjectid && setexams.examdate == dateTime.Date
            //             select new { setexams }).ToList();
            //if (query != null)
            //{
            //    return query;
            //}
            //else
            //{
            //    return $"Coming Soon!Exam is not started yet";
            //}

            var result = context.Exams.Where(n => n.subjectid == subjectid).FirstOrDefault();
            int dateresult = DateTime.Compare(result.examdate, dateTime);
            if (dateresult==0)
            {
                return "you can take";
            }
            else if (dateresult < 0)
            {
                return $"Sorry!Exam ended.Selected Exam Last Date:{result.examdate} Exam Finished";
            }
            else
            {
                return $"Coming soon.Selected Exam date:{result.examdate}.and timing is :{result.examstarttime} to {result.endTime} Exam not started yet";
            }
                
        }
    }
}
