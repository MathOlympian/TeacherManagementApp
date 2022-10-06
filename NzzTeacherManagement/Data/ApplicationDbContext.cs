using System;
using Microsoft.EntityFrameworkCore;
using NzzTeacherManagement.Models;

namespace NzzTeacherManagement.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pupil> Pupils { get; set; }
    }
}
