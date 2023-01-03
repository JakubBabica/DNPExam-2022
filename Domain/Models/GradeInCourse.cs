using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class GradeInCourse
{
    [Required]
    [MaxLength(4)]
    public string CourseCode { get; set; }
    [Required]
    public int Grade { get; set; }
    [Key]
    public int GradeId { get; set; }
    public int studentId { get; set; }
    public GradeInCourse(){}
}