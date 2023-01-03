using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IStudentService
{
    public Task<Student> CreateAsync(NewStudentDTO dto);
    Task<IEnumerable<Student>> GetAll();
}