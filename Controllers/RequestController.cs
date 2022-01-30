using EduFix_Api.Data;
using EduFix_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLeak_Backend.Data;

namespace EduFix_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private EduFixContext _db;
    public RequestController(EduFixContext db)
    {
        _db = db;
    }

    [HttpPost("newrequest")]
    public async Task<IActionResult> NewRequest(NewRequest req)
    {
        try
        {
            var obj = new Requests
            {
                Department = req.Department,
                LocationRoom = req.LocationRoom,
                Facility = req.Facility,
                Discipline = req.Discipline,
                NewComment = req.NewComment,
                UserCreated = req.UserCreated,
                DateCreated = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                UserLastUpdated = req.UserCreated,
                Status = "N"
            };

            await _db.AddRangeAsync(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpGet("requestlist")]
    public async Task<IActionResult> RequestList()
    {
        try
        {
            return Ok(await _db.Requests
            .Select(x => new RequestList
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Discipline = x.Discipline,
                Status = x.Status
            }).ToListAsync());
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return StatusCode(500);
        }
    }
}
