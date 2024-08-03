using AutoMapper;
using BlogApp.Application.Contracts.Tags;
using BlogApp.Domain.Articles;

namespace BlogApp.Domain.Tags;

public class TagManager(ITagRepository tagRepository, IMapper mapper)
{
    public async Task<TagDto> CreateAsync(TagCreateDto tagCreateDto)
    {
        var tag = new Tag() { Id = Guid.NewGuid(), Name = tagCreateDto.Name };
        return mapper.Map<TagDto>(await tagRepository.CreateAsync(tag));
    }

    public async Task<TagDto> UpdateAsync(TagUpdateDto tagUpdateDto)
    {
        var tag = new Tag() { Id = tagUpdateDto.Id, Name = tagUpdateDto.Name };
        return mapper.Map<TagDto>(await tagRepository.UpdateAsync(tag));
    }
}