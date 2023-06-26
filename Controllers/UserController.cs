using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task< ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var Users = await _context.Users.ToListAsync();
        return Users;
    }
    [HttpGet("{id}")]
    public async Task< ActionResult<AppUser>> GetUser(int id)
    {
       return await _context.Users.FindAsync(id);
    }

}