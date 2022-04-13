using eCommence_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommence_Assignment
{
    public class DB
    {
        private DBContext dbContext;

        public DB(DBContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public void Seed()
        {
            SeedUsers();
        }

        public void SeedUsers()
        {
            HashAlgorithm sha = SHA256.Create();

            string[] usernames = { "Eugene", "JianRui" };

            string password = "secretLover";

            foreach (string username in usernames)
            {
                string combo = username + password;
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(combo));


                dbContext.Add(new User
                {
                    Username = username,
                    PassHash = hash
                });

                dbContext.SaveChanges();
            }   

        }  



    }
}
