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
        public string AddCourse(string cousername)
        {
            try
            {
                return rl.AddCourse(cousername);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
