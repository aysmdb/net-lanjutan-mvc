namespace MyBlog.Models;

public class PostExcelTemplate
{
    public string Title { get; set; }
    public IEnumerable<PostExcel> Post { get; set; }
}