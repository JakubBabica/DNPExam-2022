namespace Domain.DTOs;

public class NewGradeDTO
{
    public string CourseCode { get; set; }
    public int Grade { get; set; }
    public int GradeId { get; set; }
    public int studentId { get; set; }

    public NewGradeDTO(string courseCode, int grade, int gradeId, int studentId)
    {
        CourseCode = courseCode;
        Grade = grade;
        GradeId = gradeId;
        this.studentId = studentId;
    }
}