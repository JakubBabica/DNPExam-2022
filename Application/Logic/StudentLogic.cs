using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class StudentLogic:StudentInterface
{
    private readonly IStudentDao StudentDao;

    public StudentLogic(IStudentDao dao)
    {
        this.StudentDao = dao;
    }
    public async Task<Student> CreateAsync(NewStudentDTO dto)
    {
        Student toCreate = new Student
        {
            Name = dto.Name,
            Programme = dto.Programme,
            studentId = dto.studentId,
            //grades = dto.grades
        };
        Student created = await StudentDao.createAsync(toCreate);
        return created;
    }
}