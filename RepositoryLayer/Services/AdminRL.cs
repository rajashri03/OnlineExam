﻿using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.AppContext;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AdminRL:IAdminRL
    {
        private readonly Context context;
        private readonly IConfiguration Iconfiguration;
        public AdminRL(Context context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }
        public UsersModel Registration(UsersModel user)
        {
            try
            {
                UserEntity users = new UserEntity();
                users.FirstName = user.FirstName;
                users.LastName = user.LastName;
                users.Email = user.Email;
                users.Password = EncryptPass(user.Password);
                users.userType = user.userType;
                this.context.Users.Add(users);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return user;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EncryptPass(string password)
        {
            try
            {
                string msg = "";
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                msg = Convert.ToBase64String(encode);
                return msg;
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
                UserEntity user = new UserEntity();
                user = this.context.Users.FirstOrDefault(x => x.Email == username && x.userType == "Admin");
                string dPass = Decrpt(user.Password);
                var id = user.userId;
                if (dPass == password && user != null)
                {
                    var token = this.TokenByID(id);
                    return token;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Decrpt(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string TokenByID(long userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Iconfiguration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", userid.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
