using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PS.Phonebook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Phonebook.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Organization1> Organizations1 { get; set; } = null!;
        public DbSet<Organization2> Organizations2 { get; set; } = null!;
        public DbSet<Organization3> Organizations3 { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Subdivision> Subdivisions { get; set; } = null!;
        public object Organization3s { get; internal set; }
    }
}
