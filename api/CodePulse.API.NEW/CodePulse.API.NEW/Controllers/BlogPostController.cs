using CodePulse.API.NEW.Models.DTO;
using CodePulse.API.NEW.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.NEW.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostController : ControllerBase
	{
		IBlogPostRepository blogPostRepository;
		public BlogPostController(IBlogPostRepository _blogPostRepository) {
			blogPostRepository = _blogPostRepository;
		}

		[HttpPost]
		public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto createBlogPostRequestDto) {

			var response =  await blogPostRepository.CreateBlogPost(createBlogPostRequestDto);

			return Ok(response);
		}

		//{baseurl}/api/blogposts
		[HttpGet]
		public async Task<ActionResult> GetAllBlogPosts()
		{
			return Ok(await blogPostRepository.GetAllBlogPosts());
		}
	}
}
