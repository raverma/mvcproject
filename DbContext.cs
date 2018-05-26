using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SampleMVC.Models;
using System.Data.Entity.Infrastructure;

namespace SampleMVC
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        { }

        protected AppDbContext(DbCompiledModel model) : base(model)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}