using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class Context:DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<GradeInCourse> Grades { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/ExamDatabase.db");
    }
}