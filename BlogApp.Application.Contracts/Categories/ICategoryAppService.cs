namespace BlogApp.Application.Contracts.Articles;

public interface ICategoryAppService
{
    Task<IEnumerable<CategoryDto?>> GetAllAsync();
    Task<CategoryDto?> GetByIdAsync(Guid id);
    Task<CategoryDto> CreateAsync(CategoryCreateDto? category);
    Task<CategoryDto> UpdateAsync(CategoryUpdateDto category);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
}