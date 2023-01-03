using Domain.DTOs;
using Domain.Models;

namespace Application.DAOInterfaces;

public interface IGradeDao
{
    Task<GradeInCourse> createAsync(GradeInCourse student);
    public Task<IEnumerable<GradeInCourse>> GetAsync();
    Task<IEnumerable<GradeInCourse>> Details(StatisticsOverviewDto dto);
}