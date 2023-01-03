using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface GradeInterface
{
    Task<GradeInCourse> CreateAsync(NewGradeDTO dto);
}