using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IGradeService
{
    public Task<GradeInCourse> CreateAsync(NewGradeDTO dto);
    Task<IEnumerable<GradeInCourse>> GetAll();
}