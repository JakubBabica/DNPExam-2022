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
    // [HttpGet("{id:int}")]
    // public async Task<ActionResult<GradeInCourse>> GetByIdAsync([FromRoute] int id)
    // {
    //     try
    //     {
    //         GradeInCourse grade = await Logic.GetByIdAsync(id);
    //         return Ok(grade);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         return StatusCode(500, e.Message);
    //     }
    // }
}