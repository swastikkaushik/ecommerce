using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(
            (entity) => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasMany(e => e.Orders).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            }
        );

        modelBuilder.Entity<Order>(
            (entity) => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).IsRequired();
                 entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");

                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasOne(e => e.User).WithMany(e => e.Orders).HasForeignKey(e => e.UserId);
            }
        );
    }
}