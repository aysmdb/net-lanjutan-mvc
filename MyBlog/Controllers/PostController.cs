using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;

public class PostController : Controller
{
    private readonly List<Post> _listPosts;

    public PostController(){
        _listPosts = GeneratePost();
    }

    // GET
    public IActionResult Index(int page = 1)
    {
        ViewBag.NextPage = page + 1;
        
        int dataPerPage = 10;
        int skip = dataPerPage * page - dataPerPage;

        List<Post> data = _listPosts;
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
        Post data = _listPosts.Where(post => post.Id == id)
                .FirstOrDefault();

        return View(data);
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