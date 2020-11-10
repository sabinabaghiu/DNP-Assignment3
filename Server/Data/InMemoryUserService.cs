using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService() {
            users = new[] {
                new User {
                    City = "Horsens",
                    Domain = "ymail.com",
                    Password = "123456",
                    Role = "Admin",
                    BirthYear = 2000,
                    SecurityLevel = 5,
                    UserName = "Sabina"
                },
                new User {
                    City = "Aarhus",
                    Domain = "gmail.com",
                    Password = "123456",
                    Role = "User",
                    BirthYear = 1998,
                    SecurityLevel = 1,
                    UserName = "Bob"
                }
            }.ToList();
        }
        
        public User ValidateUser(string userName, string password) 
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }
            return first;
        }
    }
}