using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models;

public class User {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Alamat { get; set; }
    public string Email { get; set; }
    public string Telepon { get; set; }
    public DateTime TanggalLahir { get; set; }
}