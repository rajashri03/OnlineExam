using CommonLayer.Models;
using RepositoryLayer.Entities;
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
        public Studentmodel StudentRegistation(Studentmodel model)
		{
            try
            {
                return studentRL.StudentRegistation(model);
            }
            catch (Exception)
            {

                throw;
            }
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
