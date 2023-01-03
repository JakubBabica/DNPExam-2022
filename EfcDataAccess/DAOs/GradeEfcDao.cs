using Application.DAOInterfaces;
using Domain.Models;
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
}