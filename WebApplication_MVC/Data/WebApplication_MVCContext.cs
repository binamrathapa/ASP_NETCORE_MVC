using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Data
{
    public class WebApplication_MVCContext : DbContext
    {
        public WebApplication_MVCContext (DbContextOptions<WebApplication_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication_MVC.Models.Student> Student { get; set; }

        public DbSet<WebApplication_MVC.Models.Department> Department { get; set; }

        public DbSet<WebApplication_MVC.Models.Product> Product { get; set; }

        public DbSet<WebApplication_MVC.Models.User> User { get; set; }
    }
}
