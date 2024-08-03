using AutoMapper;
using BlogApp.Application.Contracts.Articles;
using BlogApp.Domain.Categories;

namespace BlogApp.Application.Categories;

public class CategoryAppService(ICategoryRepository categoryRepository, CategoryManager categoryManager, IMapper mapper)
    : ICategoryAppService
{
    public async Task<IEnumerable<CategoryDto?>> GetAllAsync()
    {
        return mapper.Map<IEnumerable<CategoryDto>>(await categoryRepository.GetAllAsync());
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid id)
    {
        return mapper.Map<CategoryDto>(await categoryRepository.GetByIdAsync(id));
    }

    public async Task<CategoryDto> CreateAsync(CategoryCreateDto? category)
    {
        return await categoryManager.CreateAsync(category);
    }

    public async Task<CategoryDto> UpdateAsync(CategoryUpdateDto category)
    {
        return await categoryManager.UpdateAsync(category);
    }

  

    public Task DeleteAsync(Guid id)
    {
        return categoryRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await categoryRepository.ExistsByNameAsync(name);
    }
}