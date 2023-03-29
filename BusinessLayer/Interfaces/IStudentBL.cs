using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IStudentBL
    {
        public Studentmodel StudentRegistation(Studentmodel model);
        public string StudentLogin(string username, string password);
        public string GotoExam(int subjectid);
    }
}
