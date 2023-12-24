using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class PostController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Detail(string title)
    {
        ViewBag.Title = title;
        return View();
    }
}