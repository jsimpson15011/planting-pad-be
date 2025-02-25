using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace plantingPadBE.Models;

public class CustomIdentity : IdentityUser
{
    public bool IsBigDog { get; set; }
}

public class ApplicationDbContext : IdentityDbContext<CustomIdentity>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
}