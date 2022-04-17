using ecommerce_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_Assignment
{
    public class UserDB
    {
        private DBContext dbContext;

        public UserDB(DBContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public void SeedUsers()
        {
            HashAlgorithm sha = SHA256.Create();

            string[] usernames = { "Eugene", "JianRui" };

            string[] passwords = { "cat", "hamster" };

            for (int i = 0; i < usernames.Length; i++)
            {
                string combo = usernames[i] + passwords[i];
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(combo));


                dbContext.Add(new User
                {
                    Username = usernames[i],
                    PassHash = hash
                });

                dbContext.SaveChanges();
            }

        }
    }
}
