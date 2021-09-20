using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using TestAPI.Context;
using TestAPI.Models;

namespace TestAPI.Repository
{
    public class UserRepository
    {
        private readonly DbAccessContext _context;

        public UserRepository(DbAccessContext context)
        {
            _context = context;
        }

        public List<User> All ()
        {
            List<User> usersList = new List<User>();
            DbAccessContext context;

            try
            {
                context = _context.Create();
                context.Database.OpenConnection();

                DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM users";
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        Lastnames = reader["lastnames"].ToString(),
                        Email = reader["email"].ToString()
                    };

                    usersList.Add(user);
                }
                reader.Close();

                return usersList;
            } 
            catch(Exception ex)
            {
                throw;
            }
        } 
    }
}
