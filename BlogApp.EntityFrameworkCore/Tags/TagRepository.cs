using BlogApp.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.EntityFrameworkCore.Tags;

public class TagRepository(BlogAppDbContext context) : ITagRepository
{
    public async Task<IEnumerable<Tag?>> GetAllAsync()
    {
        return await context.Tags.ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        return await context.Tags.FindAsync(id);
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> UpdateAsync(Tag tag)
    {
        context.Update(tag);
        await context.SaveChangesAsync();
        return tag;
    }

    public async Task DeleteAsync(Guid id)
    {
        await context.Tags.Where(t => t.Id.Equals(id)).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await context.Tags.AnyAsync(t => t.Name.Equals(name));
    }

    public Task<IQueryable<Tag>> GetQueryable()
    {
        return Task.FromResult(context.Tags.AsQueryable());
    }
}