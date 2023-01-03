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
}