using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IStudentRL
    {
        public string StudentLogin(string username, string password);
    }
}
