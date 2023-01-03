using Application.DAOInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class StudentEfcDao:IStudentDao
{
    private readonly Context Context;

    public StudentEfcDao(Context context)
    {
        Context = context;
    }
    public async Task<Student> createAsync(Student student)
    {
        EntityEntry<Student> newStudent = await Context.Students.AddAsync(student);
        await Context.SaveChangesAsync();
        return newStudent.Entity;
    }
}