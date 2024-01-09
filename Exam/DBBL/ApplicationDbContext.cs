using Microsoft.EntityFrameworkCore;
using Models;

namespace DBBL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Monster> Monsters { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var frozenFrog = new Monster
        {
            Id = 1,
            Name = "Frozen Frog",
            HitPoints = 32,
            AttackModifier = 3,
            AttackPerRound = 1,
            Damage = "1d8",
            DamageModifier = 1,
            ArmorClass = 12
        };

        var gorgon = new Monster
        {
            Id = 2,
            Name = "Gorgon",
            HitPoints = 114,
            AttackModifier = 8,
            AttackPerRound = 1,
            Damage = "2d12",
            DamageModifier = 5,
            ArmorClass = 19
        };

        var bigChef = new Monster
        {
            Id = 3,
            Name = "Big Chef",
            HitPoints = 77,
            AttackModifier = 3,
            AttackPerRound = 2,
            Damage = "1d8",
            DamageModifier = 3,
            ArmorClass = 13
        };

        modelBuilder.Entity<Monster>().HasData(frozenFrog, gorgon, bigChef);
    }
}