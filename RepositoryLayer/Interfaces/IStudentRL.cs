using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IStudentRL
    {
        public Studentmodel StudentRegistation(Studentmodel model);
        public string StudentLogin(string username, string password);
    }
}
