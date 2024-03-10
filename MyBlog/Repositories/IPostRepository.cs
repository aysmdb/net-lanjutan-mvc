using MyBlog.Models;

namespace MyBlog.Repositories;

public interface IPostRepository
{
    List<Post> GetAllPost();
    Post GetOnePost(int id);
    Post CreatePost(PostRequest data);
}