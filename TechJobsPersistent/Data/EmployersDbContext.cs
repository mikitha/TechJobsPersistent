using System;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.Data
{
    public class EmployersDbContext : DbContext
    {
        public DbSet<Employer> Employer { get; set; }

        public EmployersDbContext(DbContextOptions<EmployersDbContext> options)
              : base(options)
        {
        }
       
    }
}