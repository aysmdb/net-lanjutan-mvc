using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly AppDbContext _context;

    public PostController(AppDbContext c){
        _context = c;
    }

    
    // GET
    public IActionResult Index(int page = 1)
    {
        ViewBag.NextPage = page + 1;
        
        int dataPerPage = 10;
        int skip = dataPerPage * page - dataPerPage;

        List<Post> data = _context.Post
        // .Where(x => x.Title.Contains("kedua"))
        .ToList();
        
        List<Post> filteredData = data
            // .Where(post => post.Id <= 10)
            .Skip(skip)
            .Take(dataPerPage)
            .OrderBy(post => post.Id) //Urutkan dari terkecil
            // .OrderByDescending(post => post.Id) //Urutkan dari terbesar
            .ToList();

        return View(filteredData);
    }
    
    public IActionResult Detail(int id)
    {
        Post data = _context.Post.Where(post => post.Id == id)
                .FirstOrDefault();

        return View(data);
    }

    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] Post data){
        data.Likes = 0;
        data.CreatedDate = DateTime.Now;

        _context.Post.Add(data);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id){
        var postData = _context.Post
            .FirstOrDefault(x => x.Id == id);

        return View(postData);
    }

    [HttpPost]
    public IActionResult Edit([FromForm] Post data){
        var dataFromDb = _context.Post
            .FirstOrDefault(x => x.Id == data.Id);

        if(dataFromDb != null){
            dataFromDb.Title = data.Title;
            dataFromDb.Content = data.Content;

            _context.Post.Update(dataFromDb);
            _context.SaveChanges();
        }
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id){
        var dataFromDb = _context.Post
            .FirstOrDefault(x => x.Id == id);
        
        if(dataFromDb != null){
            _context.Post.Remove(dataFromDb);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    private List<Post> GeneratePost(){
        List<Post> posts = new List<Post>();
        int id = 1;
        for(int i = 0;i < 100; i++ ){
            posts.Add(
                new Post(){
                    Id = id,
                    Title = "Judul " + id,
                    Content = "Ini isi artikel",
                    CreatedDate = DateTime.Now
                }
            );

            id++;
        }

        return posts;
    }
}