using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthService.Models;

public class ApplicationDbContext : IdentityDbContext<PlantingPadIdentity>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
}