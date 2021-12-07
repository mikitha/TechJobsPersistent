using System;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.Data
{
    public class EmployerDbContext : DbContext
    {
        public DbSet<Employer> Employer { get; set; }

        public EmployerDbContext(DbContextOptions<EmployerDbContext> options)
              : base(options)
        {
        }
       
    }
}