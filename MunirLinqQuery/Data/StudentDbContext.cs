using Microsoft.EntityFrameworkCore;
using System;
using static MunirLinqQuery.Data.Department;

namespace MunirLinqQuery.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        public DbSet<Student> std { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Enrolled> Enrolled { get; set; }
        public DbSet<Department> depts { get; set; }
    }
}