namespace BlogApp.Domain.Tags;

public interface ITagRepository
{
    Task<IEnumerable<Tag?>> GetAllAsync();
    Task<Tag?> GetByIdAsync(Guid id);
    Task<Tag> CreateAsync(Tag tag);
    Task<Tag> UpdateAsync(Tag tag);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
    Task<IQueryable<Tag>> GetQueryable();
}