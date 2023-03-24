using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AdminBL:IAdminBL
    {
		IAdminRL adminrl;
		public AdminBL(IAdminRL adminrl)
		{
				this.adminrl = adminrl;
		}
        public UsersModel Registration(UsersModel user)
        {
			try
			{
				return adminrl.Registration(user);
			}
			catch (Exception)
			{

				throw;
			}
        }
		public string AdminLogin(string username, string password)
		{
            try
            {
                return adminrl.AdminLogin(username,password);
            }
            catch (Exception)
            {

                throw;
            }
        }
        }
}
