using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;

public class AccountController : Controller {
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] Login data){
        var userFromDb = _context.User
            .FirstOrDefault(x => 
                x.Username == data.Username 
                && x.Password == data.Password);

        if(userFromDb == null){
            @ViewBag.Error = "User not found";
            return View();
        }

        var claims = new List<Claim>(){
            new Claim(ClaimTypes.Name, data.Username),
            new Claim(ClaimTypes.Role, "Admin"),
        };

        var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
        var identity = new ClaimsIdentity(claims, scheme);
    
        await HttpContext.SignInAsync(scheme, new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync();

        return RedirectToAction("Login");
    }

    public IActionResult Register(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] User data){
        _context.Add(data);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }
}