using doKolosa2.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace doKolosa2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly GakkoDbContext _context;

    public StudentsController(GakkoDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var data = await _context.Students
            .Include(s => s.StudentGroup)
            .OrderBy(s => s.Name)
            .Select(s =>
                s.Name)
            .ToListAsync(cancellationToken);
        return Ok(data);

    }
    
    [HttpGet("debug-connection")]
    public IActionResult GetDbConnectionString()
    {
        return Ok(_context.Database.GetDbConnection().ConnectionString);
    }

}