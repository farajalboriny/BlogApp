using AutoMapper;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Domain.Articles;

namespace BlogApp.Domain.Categories;

public class CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
{
    public async Task<CategoryDto> CreateAsync(CategoryCreateDto? categoryCreateDto)
    {
        var category = new Category() { Id = Guid.NewGuid(), Name = categoryCreateDto.Name };
        return mapper.Map<CategoryDto>(await categoryRepository.CreateAsync(category));
    }

    public async Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
    {
        var category = new Category() { Id = categoryUpdateDto.Id, Name = categoryUpdateDto.Name};
        return mapper.Map<CategoryDto>(await categoryRepository.UpdateAsync(category));
    }
}