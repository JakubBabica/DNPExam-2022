using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface StudentInterface
{
    Task<Student> CreateAsync(NewStudentDTO dto);
}