using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;

namespace CodePulse.API.NEW.Repositories.Interface
{
	public interface IBlogPostRepository
	{
		Task<BlogPost> CreateBlogPost(CreateBlogPostRequestDto createBlogPostRequestDto);

		Task<List<BlogPost>> GetAllBlogPosts();
	}
}
