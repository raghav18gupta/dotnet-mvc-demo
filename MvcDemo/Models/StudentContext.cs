using Microsoft.EntityFrameworkCore;

namespace MvcDemo.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        
        public DbSet<Student> tbl_student { get; set; }
        public DbSet<Department> tbl_department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("MvcDemo");
        }
    }
}
