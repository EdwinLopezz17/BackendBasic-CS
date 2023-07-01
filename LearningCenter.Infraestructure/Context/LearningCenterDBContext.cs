using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure.Context;

public class LearningCenterDBContext: DbContext
{
    public LearningCenterDBContext()
    {
        
    }

    public LearningCenterDBContext(DbContextOptions<LearningCenterDBContext> options) : base(options)
    {
        
    }
     
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
            optionsBuilder.UseMySql(
                "Server=localhost,3306;Uid=root;Pwd=UPC@intranet_17;Database=LearningCenterPractice", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(c => c.id);
        builder.Entity<Category>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.description).IsRequired().HasMaxLength(200);


        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(t => t.id);
        builder.Entity<Tutorial>().Property(t => t.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.isActive).HasDefaultValue(true);
    }
    
}