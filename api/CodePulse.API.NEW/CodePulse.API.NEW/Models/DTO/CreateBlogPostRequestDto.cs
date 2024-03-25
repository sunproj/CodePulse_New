﻿namespace CodePulse.API.NEW.Models.DTO
{
	public class CreateBlogPostRequestDto
	{
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Content { get; set; }
		public string UrlHandle { get; set; }
		public string FeaturedImageUrl { get; set; }
		public DateTime DateCreated { get; set; }
		public string Author { get; set; }
		public bool IsVisible { get; set; }
	}
}
