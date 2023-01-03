namespace Domain.DTOs;

public class StatisticsOverviewDto
{
    public string CourseCode { get; set; }
    public int? TotalNoOfPassed { get; set; }
    public int? TotalNumOfStudents { get; set; }
    public float? AvrGradeOverall { get; set; }
    public float? AvrGradePassed { get; set; }
    public int? MedianGrade { get; set; }

    public StatisticsOverviewDto(string courseCode, int? totalNoOfPassed, int? totalNumOfStudents, float? avrGradeOverall, float? avrGradePassed, int? medianGrade)
    {
        CourseCode = courseCode;
        TotalNoOfPassed = totalNoOfPassed;
        TotalNumOfStudents = totalNumOfStudents;
        AvrGradeOverall = avrGradeOverall;
        AvrGradePassed = avrGradePassed;
        MedianGrade = medianGrade;
    }
}
