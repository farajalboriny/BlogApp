using BlogApp.Application.Contracts.Tags;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagAppService tagAppService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TagDto?>> GetAllAsync()
        {
            return await tagAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<TagDto?> GetByIdAsync(Guid id)
        {
            return await tagAppService.GetByIdAsync(id);
            
           
        }

        [HttpPost]
        public async Task<TagDto?> CreateAsync(TagCreateDto tagCreateDto)
        {
            return await tagAppService.CreateAsync(tagCreateDto);
        }

        [HttpPut]
        public async Task<TagDto?> UpdateAsync( TagUpdateDto tagUpdateDto)
        {
            return await tagAppService.UpdateAsync(tagUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await tagAppService.DeleteAsync(id);
        }

      
        [HttpGet("exists/{name}")]
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await tagAppService.ExistsByNameAsync(name);
        }
    }
}
