using EduFix_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLeak_Backend.Data;

namespace EduFix_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DropDownController : ControllerBase
{
    private EduFixContext _db;
    public DropDownController(EduFixContext db)
    {
        _db = db;
    }

    [HttpGet("{dropDownType}")]
    public async Task<IActionResult> DepartmentsAsync(string dropDownType)
    {
        try
        {
            return Ok(await _db.DropdownValues.Where(x => x.Type == dropDownType).ToListAsync());
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return StatusCode(500);
        }
    }
}
