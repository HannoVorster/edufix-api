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
            .Where(x => x.Status != "A")
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

    [HttpGet("approvalslist")]
    public async Task<IActionResult> ApprovalsList()
    {
        try
        {
            return Ok(await _db.Requests
            .Where(x => x.Status == "A")
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

    [HttpGet("detailedassess/{id}")]
    public async Task<IActionResult> DetailedReq(int id)
    {
        try
        {
            return Ok(await _db.Requests
            .Where(x => x.Id == id)
            .Select(x => new DetailedRequest
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                UserCreated = x.UserCreated,
                Department = x.Department,
                LocationRoom = x.LocationRoom,
                Facility = x.Facility,
                Discipline = x.Discipline,
                NewComment = x.NewComment,
                Status = x.Status
            }).FirstOrDefaultAsync());
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return StatusCode(500);
        }
    }

    [HttpGet("detailedapprove/{id}")]
    public async Task<IActionResult> DetailedApprove(int id)
    {
        try
        {
            return Ok(await _db.Requests
            .Where(x => x.Id == id)
            .Select(x => new DetailedApprove
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                UserCreated = x.UserCreated,
                Department = x.Department,
                LocationRoom = x.LocationRoom,
                Facility = x.Facility,
                Discipline = x.Discipline,
                NewComment = x.NewComment,
                Status = x.Status,
                ResponseTime = x.ResponseTime,
                EmergencyNormal = x.EmergencyNormal,
                AssessComment = x.AssessComment
            }).FirstOrDefaultAsync());
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return StatusCode(500);
        }
    }

    [HttpGet("detailedcontractor/{id}")]
    public async Task<IActionResult> DetailedContractor(int id)
    {
        try
        {
            return Ok(await _db.Requests
            .Where(x => x.Id == id)
            .Select(x => new DetailedContractor
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                UserCreated = x.UserCreated,
                Department = x.Department,
                LocationRoom = x.LocationRoom,
                Facility = x.Facility,
                Discipline = x.Discipline,
                NewComment = x.NewComment,
                Status = x.Status,
                ResponseTime = x.ResponseTime,
                EmergencyNormal = x.EmergencyNormal,
                AssessComment = x.AssessComment,
                ApproveMandate = x.ApproveMandate,
                ApproveComment = x.ApproveComment,
                ApproveUser = x.ApproveUser
            }).FirstOrDefaultAsync());
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return StatusCode(500);
        }
    }

    [HttpPost("assessment")]
    public async Task<IActionResult> Assessment(Assessment req)
    {
        try
        {
            var temp = await _db.Requests.Where(x => x.Id == req.Id).FirstOrDefaultAsync();

            temp.ResponseTime = req.ResponseTime;
            temp.EmergencyNormal = req.EmergencyNormal;
            temp.AssessComment = req.Comment;
            temp.AssessUser = req.User;
            temp.LastUpdated = DateTime.UtcNow;
            temp.UserLastUpdated = req.User;
            temp.Status = "A";

            await _db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpPost("approval")]
    public async Task<IActionResult> Approval(Approval req)
    {
        try
        {
            var temp = await _db.Requests.Where(x => x.Id == req.Id).FirstOrDefaultAsync();

            temp.ApproveMandate = req.ApproveMandate;
            temp.ApproveComment = req.Comment;
            temp.ApproveUser = req.User;
            temp.LastUpdated = DateTime.UtcNow;
            temp.UserLastUpdated = req.User;
            temp.Status = "AA";

            await _db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }
}
