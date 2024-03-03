using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog;

public class SidebarViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public SidebarViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        List<Menu> menus = _context.Menu.ToList();

        return View(menus);
    }
}