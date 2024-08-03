namespace BlogApp.Application.Contracts.Tags;

public interface ITagAppService
{
    Task<IEnumerable<TagDto?>> GetAllAsync();
    Task<TagDto?> GetByIdAsync(Guid id);
    Task<TagDto> CreateAsync(TagCreateDto? tag);
    Task<TagDto> UpdateAsync(TagUpdateDto tag);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
}