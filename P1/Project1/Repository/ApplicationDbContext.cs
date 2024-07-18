using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project1.Entities;

public class ApplicationDbContext :DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public ApplicationDbContext(){}

    public DbSet<User> Users {get; set;}

    public DbSet<DndCharacter> DndCharacter {get; set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured){
            IConfigurationRoot config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<DndCharacter>()
                    .HasOne(d => d.User)
                    .WithMany(u => u.DndCharacters)
                    .HasForeignKey("UserID");

        modelBuilder.Entity<User>()
                    .HasMany(u => u.DndCharacters)
                    .WithOne(d => d.User)
                    .HasForeignKey(d => d.UserID);
        

        // modelBuilder.Entity<DndCharacter>()
        //             .HasOne(d => d.User)
        //             .WithMany(u => u.DndCharacters)
        //             .HasForeignKey(d => d.UserID);

        

        // modelBuilder.Entity<User>()
        //             .HasMany(u => u.DndCharacters)
        //             .WithOne(d => d.User)
        //             .HasForeignKey(d => d.UserID);
                    
    }


}