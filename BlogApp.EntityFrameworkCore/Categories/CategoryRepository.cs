using BlogApp.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.EntityFrameworkCore.Categories;

public class CategoryRepository(BlogAppDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category?>> GetAllAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        context.Update(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task DeleteAsync(Guid id)
    {
        await context.Categories.Where(c => c.Id.Equals(id)).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await context.Categories.AnyAsync(c => c.Name == name);
    }

    public Task<IQueryable<Category>> GetQueryable()
    {
        return Task.FromResult(context.Categories.AsQueryable());
    }
}