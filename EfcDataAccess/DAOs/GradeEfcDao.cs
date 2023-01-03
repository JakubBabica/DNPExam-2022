using Application.DAOInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class GradeEfcDao:IGradeDao
{
    private readonly Context Context;

    public GradeEfcDao(Context context)
    {
        Context = context;
    }
    public async Task<GradeInCourse> createAsync(GradeInCourse grade)
    {
        EntityEntry<GradeInCourse> newGrade = await Context.Grades.AddAsync(grade);
        await Context.SaveChangesAsync();
        return newGrade.Entity;
    }

    public Task<IEnumerable<GradeInCourse>> GetAsync()
    {
        IEnumerable<GradeInCourse> grades = Context.Grades.AsEnumerable();
        grades = Context.Grades;
        return Task.FromResult(grades);
    }

    public async Task<IEnumerable<GradeInCourse>> Details(StatisticsOverviewDto dto)
    {
        IQueryable<GradeInCourse> query = Context.Grades.Include(grade=>grade.studentId).AsQueryable();
        if (!string.IsNullOrEmpty(dto.CourseCode))
        {
            // Not enough time to construct the queries :(
            query = query.Where(grade =>
                grade.CourseCode.Equals(dto.CourseCode));
        }
    
        
        List<GradeInCourse> result = await query.ToListAsync();
        return result;
    }
}