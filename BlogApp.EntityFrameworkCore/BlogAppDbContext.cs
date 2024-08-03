using BlogApp.Domain.Articles;
using BlogApp.Domain.Categories;
using BlogApp.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.EntityFrameworkCore;

public class BlogAppDbContext(DbContextOptions<BlogAppDbContext> options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .HasIndex(a => a.Title)
            .IsUnique();

        modelBuilder.Entity<Article>()
            .Property(a => a.Status)
            .HasDefaultValue("Draft");

        modelBuilder.Entity<Article>()
            .Property(a => a.Views)
            .HasDefaultValue(0);

        modelBuilder.Entity<Article>()
            .HasMany(a => a.Tags)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "ArticleTags",
                j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                j => j.HasOne<Article>().WithMany().HasForeignKey("ArticleId"),
                j =>
                {
                    j.HasKey("ArticleId", "TagId");
                    j.ToTable("ArticleTags");
                });

        modelBuilder.Entity<Article>()
            .HasMany(a => a.Categories)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "ArticleCategories",
                j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                j => j.HasOne<Article>().WithMany().HasForeignKey("ArticleId"),
                j =>
                {
                    j.HasKey("ArticleId", "CategoryId");
                    j.ToTable("ArticleCategories");
                });


        modelBuilder.Entity<Tag>()
            .HasIndex(t => t.Name)
            .IsUnique();

        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}