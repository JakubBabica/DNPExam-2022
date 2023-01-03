using Domain.Models;

namespace Application.DAOInterfaces;

public interface IGradeDao
{
    Task<GradeInCourse> createAsync(GradeInCourse student);
}