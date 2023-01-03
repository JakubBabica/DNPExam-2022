using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class GradeLogic:GradeInterface
{
    private readonly IGradeDao GradeDao;

    public GradeLogic(IGradeDao dao)
    {
        this.GradeDao = dao;
    }
    
    public async Task<GradeInCourse> CreateAsync(NewGradeDTO dto)
    {
        GradeInCourse toCreate = new GradeInCourse
        {
            studentId = dto.studentId,
            GradeId = dto.GradeId,
            CourseCode = dto.CourseCode,
            Grade = dto.Grade
        };
        GradeInCourse created = await GradeDao.createAsync(toCreate);
        return created;
    }
}