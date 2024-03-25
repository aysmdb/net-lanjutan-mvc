using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Services;

namespace MyBlog.Controllers;

[Route("api/{controller}")]
[ApiController]
public class PostApiController : ControllerBase
{
    private readonly IPostRepository _repo;
    private readonly IEmailService _email;

    public PostApiController(IPostRepository r, IEmailService email)
    {
        _repo = r;
        _email = email;
    }

    [HttpGet]
    [Route("get-all")]
    public IActionResult GetAllPost()
    {
        _email.SendEmail(
            "aysmdb@gmail.com",
            "Registrasi Akun",
            "Selamat registrasi akun anda berhasil"
        );
        var post = _repo.GetAllPost();

        return Ok(post);
    }

    [HttpGet]
    [Route("get-one/{id}")]
    public IActionResult GetOnePost(int id)
    {
        try
        {
            var post = _repo.GetOnePost(id);

            if(post == null){
                return BadRequest("Ga ada post dengan id tersebut");
            }
            // var iniharusnyaerror = post.Title;

            return Ok(post);
        }
        catch(Exception e)
        {
            throw e;
        }
    }

    [HttpPost]
    [Route("create-post")]
    public IActionResult CreatePost([FromBody] PostRequest data)
    {
        try 
        {
            var post = _repo.CreatePost(data);

            return Ok(post);

        } catch (Exception e)
        {
            throw e;
        }
    }

    [HttpPut]
    public IActionResult EditPost(){
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeletePost(){
        return Ok();
    }
}