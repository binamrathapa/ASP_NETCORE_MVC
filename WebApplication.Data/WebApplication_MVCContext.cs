using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Entities;

namespace WebApplication.Data
{
    public class WebApplication_MVCContext : DbContext
    {
        public WebApplication_MVCContext (DbContextOptions<WebApplication_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<User> User { get; set; }
    }
}
