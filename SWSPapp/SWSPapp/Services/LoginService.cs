﻿using System.Linq;
using SWSPapp.Models;
using SWSPapp.Context;
using System.Security.Cryptography;
using System.Text;

namespace SWSPapp.Services
{
    public class LoginService
    {
        public static UserModel SignIn(UserModel userModel)
        {
            using (SWSPContext context = new SWSPContext())
            {
                var hash = Hash(userModel.Password);
                var user = context.Users.FirstOrDefault(x => x.Login == userModel.Login && x.Password == hash);
                if (user != null)
                {
                    return new UserModel() { Id = user.User_ID, Login = user.Login, Name = user.Name, Role = user.Access };
                }
                return null;
            }
        }


        public static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}