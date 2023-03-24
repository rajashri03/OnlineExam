using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IStudentBL
    {

        public string StudentLogin(string username, string password);
    }
}
