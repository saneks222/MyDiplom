using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentControl.Models;

namespace StudentControl.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       public DbSet<Student> Students { get; set; }
       public DbSet<Group> Groups { get; set; }
       public DbSet<Lesson> Lessons { get; set; }
       public DbSet<Visit> Visits { get; set; }
    }
}