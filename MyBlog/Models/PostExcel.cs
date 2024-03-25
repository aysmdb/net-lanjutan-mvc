using MiniExcelLibs.Attributes;

namespace MyBlog.Models;

public class PostExcel
{
    public string Title { get; set; }

    [ExcelColumnWidth(90)]
    public string Content { get; set; }
    
    public int Likes { get; set; }
}