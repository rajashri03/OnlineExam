﻿using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAdminBL
    {
        public UsersModel Registration(UsersModel user);
        public string AdminLogin(string username, string password);
        }
}
