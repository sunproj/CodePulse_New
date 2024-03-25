using CodePulse.API.Data;
using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;
using CodePulse.API.NEW.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.NEW.Repositories.Implementation
{
	public class BlogPostRepository : IBlogPostRepository
	{
		private ApplicationDbContext applicationDbContext;

		public BlogPostRepository(ApplicationDbContext _applicationDbContext) {
			applicationDbContext = _applicationDbContext;
		}

		public async Task<BlogPost> CreateBlogPost(CreateBlogPostRequestDto createBlogPostRequestDto)
		{
			BlogPost blogPost = null;

			try { 
			blogPost = new BlogPost
			{
				Author = createBlogPostRequestDto.Author,
				Content = createBlogPostRequestDto.Content,
				DateCreated = createBlogPostRequestDto.DateCreated,
				FeaturedImageUrl = createBlogPostRequestDto.FeaturedImageUrl,
				ShortDescription = createBlogPostRequestDto.ShortDescription,
				UrlHandle = createBlogPostRequestDto.UrlHandle,
				Title = createBlogPostRequestDto.Title,
				IsVisible = createBlogPostRequestDto.IsVisible,
			};

			applicationDbContext.BlogPosts.Add(blogPost);
			await applicationDbContext.SaveChangesAsync();
			}
			catch(Exception ex) {
				
			}
			return blogPost;
		}

		//{baseurl}/api/blogposts
		[HttpGet]
		public async Task<List<BlogPost>> GetAllBlogPosts()
		{ 
			return await applicationDbContext.BlogPosts.ToListAsync();
		}
	}
}
