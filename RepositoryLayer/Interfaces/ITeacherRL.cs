using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ITeacherRL
    {
        public string TeacherLogin(string username, string password);
        public string AddCourse(string cousername);
    }
}
