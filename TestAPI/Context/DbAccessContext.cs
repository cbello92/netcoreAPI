﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Context
{
    public class DbAccessContext : DbContext 
    {
        private readonly IConfiguration _configuration;

        public DbAccessContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public DbAccessContext(DbContextOptions<DbAccessContext> options)
            : base(options)
        {
        }
        private string BuildConnectionString()
        {
            return _configuration.GetConnectionString("DEV");
        }

        public DbAccessContext Create()
        {
            string _connectionString;

            _connectionString = BuildConnectionString();

            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentException($"{nameof(_connectionString)} is null or empty.", nameof(_connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<DbAccessContext>();

            optionsBuilder.UseSqlServer(_connectionString);

            return new DbAccessContext(optionsBuilder.Options);
        }
    }
}
