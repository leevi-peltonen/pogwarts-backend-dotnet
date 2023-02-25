using Microsoft.EntityFrameworkCore;
using web_api.Models;
using Attribute = web_api.Models.Attribute;

namespace web_api
{
    public class PogwartsContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Attribute> Attribute { get; set; }



        public PogwartsContext(DbContextOptions<PogwartsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Weapon>().ToTable("Weapon");
            modelBuilder.Entity<Armor>().ToTable("Armor");
            modelBuilder.Entity<Attribute>().ToTable("Attribute");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne(c => c.User);


            modelBuilder.Entity<Character>()
                .HasMany(c => c.Weapons)
                .WithMany(w => w.Characters);
                
        }
    }
}
