using doKolosa2.Models;
using Microsoft.EntityFrameworkCore;

namespace doKolosa2.DAL;

public class GakkoDbContext : DbContext
//komunikacja z baza danych
//DbSet<Student> --> tabelka w bazie danych
{
    public DbSet<Student> Students { get; set; }
    
    public DbSet<StudentGroup> StudentGroups { get; set; }
    
    protected GakkoDbContext()
    {
    }

    public GakkoDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder);
        
        //seed
        modelBuilder.Entity<StudentGroup>().HasData(
            new StudentGroup
            {
                IdStudentGroup = 1,
                Name = "GrupaAng",
            }
        );
        
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                IdStudent = 1,
                Name = "Karolina",
                IdStudentGroup = 1
            }
            );
        
    }
    
    
}