using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Golfers> Golfer { get; set; }
    public DbSet<Golfers_Friends> GolferFriends { get; set; }
    public DbSet<Challenges> Challenge { get; set; }
    public DbSet<Courses> Course { get; set; }


}
