using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CharacterVaulBack.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

}