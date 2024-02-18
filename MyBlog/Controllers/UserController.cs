using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Controllers;

public class UserController : Controller {
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(){
        var data = await _context.User.ToListAsync();
        return View(data);
    }

    public async Task<IActionResult> Detail([FromQuery] int id){
        var data = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        return View(data);
    }
}