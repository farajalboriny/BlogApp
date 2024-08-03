namespace BlogApp.Domain.Categories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category?>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
    Task<IQueryable<Category>> GetQueryable();
}