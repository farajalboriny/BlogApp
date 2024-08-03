using BlogApp.Application.Contracts.Articles;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryAppService categoryAppService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CategoryDto?>> GetAllAsync()
        {
            return await categoryAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            return await categoryAppService.GetByIdAsync(id);
           
        }

        [HttpPost]
        public async Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
           
            return await categoryAppService.CreateAsync(categoryCreateDto);
        }

        [HttpPut]
        public async Task<CategoryDto?> UpdateAsync( CategoryUpdateDto categoryUpdateDto)
        {
         
            return await categoryAppService.UpdateAsync(categoryUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await categoryAppService.DeleteAsync(id);
           
        }

        [HttpGet("exists/{name}")]
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await categoryAppService.ExistsByNameAsync(name);
        }
    }
}
