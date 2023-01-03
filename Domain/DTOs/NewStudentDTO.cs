using Domain.Models;

namespace Domain.DTOs;

public class NewStudentDTO
{
    public string Name { get; set; }
    
    public string Programme { get; set;}
   
    public int studentId { get; set; }
    //public List<GradeInCourse> grades { get; set; }
}