using DreamDictionary.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }


        [HttpPost("getBlogTitles")]
        public IActionResult GetTitles()
        {
            if (_blogService.getBlogTitles().isSuccess)
            {
                var response = _blogService.getBlogTitles();
                return Ok(response);
            }
            else
            {
                return BadRequest(_blogService.getBlogTitles());
            }
        }

        [HttpPost("getBlogDetails/{id}")]
        public IActionResult GetDetails (int id)
        {
            if (_blogService.getBlogDetails(id).isSuccess)
            {
                var response = _blogService.getBlogDetails(id);
                return Ok(response);
            }
            else
            {
                return BadRequest(_blogService.getBlogDetails(id));
            }
        }
    }
}
