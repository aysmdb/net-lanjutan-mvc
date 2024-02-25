using System.Globalization;
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

    public async Task<IActionResult> Detail(int id){
        var data = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

        var indoCulture = CultureInfo.GetCultureInfo("id-ID");

        data.FormatTanggalLahir = data.TanggalLahir.ToString("d MMMM yyyy", indoCulture);
        return View(data);
    }
}