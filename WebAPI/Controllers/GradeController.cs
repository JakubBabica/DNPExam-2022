using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class GradeController:ControllerBase
{
    private readonly GradeInterface Logic;
    
    public GradeController(GradeInterface logic)
    {
        Logic = logic;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync( NewGradeDTO dto)
    {
        try
        {
            GradeInCourse grade = await Logic.CreateAsync(dto);
            return Ok(grade);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GradeInCourse>>> GetAsync()
    {
        try
        {
            IEnumerable<GradeInCourse> grades = await Logic.GetAsync();
            return Ok(grades);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GradeInCourse>>> GetAsync([FromQuery] string? courseCode,[FromQuery] int? totalNoOfPassed, [FromQuery] int? totalNoOfStudents,
        [FromQuery] float? avrGradeOverall, [FromQuery]float? avrGradePassed, [FromQuery]int? medianGrade)
    {
        try
        {
            StatisticsOverviewDto parameters = new StatisticsOverviewDto(courseCode,totalNoOfPassed,totalNoOfStudents,avrGradeOverall,avrGradePassed,medianGrade);
            var todos = await Logic.Details(parameters);
            return Ok(todos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}