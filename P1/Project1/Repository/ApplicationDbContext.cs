using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project1.Entities;
public class ApplicationDbContext :DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public ApplicationDbContext(){}

    public DbSet<User> Users {get; set;}

    public DbSet<DndCharacter> DndCharacter {get; set;}

    public DbSet<Login> Logins {get; set;}
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


        modelBuilder.Entity<User>()
                    .HasMany(u => u.DndCharacters)
                    .WithOne(d => d.User)
                    .HasForeignKey(d => d.UserID);

        modelBuilder.Entity<User>()
                    .HasOne(u => u.Login)
                    .WithOne(l => l.User)
                    .HasForeignKey<Login>(l => l.UserID);


      
    }


}