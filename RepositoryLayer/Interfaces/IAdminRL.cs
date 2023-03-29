using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminRL
    {
        public UsersModel Registration(UsersModel user);
        public string AdminLogin(string username, string password);

    }
}
