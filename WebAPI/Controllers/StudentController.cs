using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentController:ControllerBase
{
    private readonly StudentInterface Logic;
    
    public StudentController(StudentInterface logic)
    {
        Logic = logic;
    }
    [HttpPost]
    public async Task<ActionResult> CreateAsync( NewStudentDTO dto)
    {
        try
        {
            Student student = await Logic.CreateAsync(dto);
            return Ok(student);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAsync()
    {
        try
        {
            IEnumerable<Student> students = await Logic.GetAsync();
            return Ok(students);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}