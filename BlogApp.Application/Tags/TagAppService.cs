using AutoMapper;
using BlogApp.Application.Contracts.Tags;
using BlogApp.Domain.Tags;

namespace BlogApp.Application.Tags;

public class TagAppService(ITagRepository tagRepository, IMapper mapper, TagManager tagManager) : ITagAppService
{
    public async Task<IEnumerable<TagDto?>> GetAllAsync()
    {
        return mapper.Map<IEnumerable<TagDto>>(await tagRepository.GetAllAsync());
    }

    public async Task<TagDto?> GetByIdAsync(Guid id)
    {
        return mapper.Map<TagDto>(await tagRepository.GetByIdAsync(id));
    }

    public async Task<TagDto> CreateAsync(TagCreateDto? tag)
    {
        return await tagManager.CreateAsync(tag);
    }

    public async Task<TagDto> UpdateAsync(TagUpdateDto tag)
    {
        return await tagManager.UpdateAsync(tag);
    }

    public Task DeleteAsync(Guid id)
    {
        return tagRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await tagRepository.ExistsByNameAsync(name);
    }
}