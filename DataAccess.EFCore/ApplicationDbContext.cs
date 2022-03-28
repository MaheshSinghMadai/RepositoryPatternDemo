using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

//Data Access Layer
namespace DataAccess.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
    }

}
