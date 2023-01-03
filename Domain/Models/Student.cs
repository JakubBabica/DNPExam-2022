using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Student
{
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    [Required]
    public string Programme { get; set;}
    [Key]
    public int studentId { get; set; }
    public List<GradeInCourse> grades { get; set; }
    public Student(){}
}