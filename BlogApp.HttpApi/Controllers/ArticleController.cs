using System.Net;
using BlogApp.Application.Contracts.Articles;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp.HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController(IArticleAppService articleAppService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ArticleDto?> GetByIdAsync(Guid id)
        {
            return await articleAppService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> GetAllAsync([FromQuery] GetArticleInput getArticleInput)
        {
            return await articleAppService.GetAllAsync(getArticleInput);
        }

        [HttpPost]
        public async Task<ArticleDto> CreateAsync([FromBody] ArticleCreateDto articleCreateDto)
        {
            if (await articleAppService.ExistsByTitleAsync(articleCreateDto.Title))
            {
                Response.StatusCode = (int)HttpStatusCode.Conflict;
                return new ArticleDto();
            }
            return await articleAppService.CreateAsync(articleCreateDto);
        }

        [HttpPut]
        public async Task<ArticleDto> UpdateAsync([FromBody] ArticleUpdateDto articleUpdateDto)
        {
            if (await articleAppService.ExistsByTitleAsync(articleUpdateDto.Title))
            {
                Response.StatusCode = (int)HttpStatusCode.Conflict;
                return new ArticleDto();
            }
            return await articleAppService.UpdateAsync(articleUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await articleAppService.DeleteAsync(id);
        }

        [HttpGet("exists")]
        public async Task<bool> ExistsByTitleAsync([FromQuery] string title)
        {
            return await articleAppService.ExistsByTitleAsync(title);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<ArticleDto>> SearchAsync([FromQuery] ArticleSearchCriteria query)
        {
            return await articleAppService.SearchAsync(query);
        }

        [HttpPost("{id}/views")]
        public async Task IncrementViewsAsync(Guid id)
        {
            await articleAppService.IncrementViewsAsync(id);
        }

        [HttpGet("recent")]
        public async Task<IEnumerable<ArticleDto>> GetRecentlyPublishedAsync()
        {
            return await articleAppService.GetRecentlyPublishedAsync();
        }
    }
}
