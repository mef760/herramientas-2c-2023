using Microsoft.AspNetCore.Identity;

namespace clase12.Models;

public class User: IdentityUser
{
    public string Dni { get; set; }
}