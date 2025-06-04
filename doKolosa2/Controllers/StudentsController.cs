using doKolosa2.DAL;
using doKolosa2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            .ToListAsync(cancellationToken);
        return Ok(data);

    }
}