using Domain.Models;

namespace Application.DAOInterfaces;

public interface IStudentDao
{
    Task<Student> createAsync(Student student);
    public Task<IEnumerable<Student>> GetAsync();
}