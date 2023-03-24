using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class StudentBL:IStudentBL
    {
		IStudentRL studentRL;
		public StudentBL(IStudentRL studentRL)
		{
			this.studentRL = studentRL;
		}
        public string StudentLogin(string username, string password)
        {
			try
			{
				return studentRL.StudentLogin(username, password);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
