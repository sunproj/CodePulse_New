
using CodePulse.API.Data;
using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;
using CodePulse.API.NEW.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.NEW.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		ICategoryRepository categoryRepository;
		public CategoryController(ICategoryRepository _categoryRepository) {
			categoryRepository= _categoryRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="createCategoryRequestDto"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("/api/AddCategories")]
		public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto createCategoryRequestDto)
		{
			CategoryDto response = null;

			if (createCategoryRequestDto != null)
			{
				try
				{
					response = await categoryRepository.CreateAsync(createCategoryRequestDto);
					return Ok(response);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
			var error = new {ErrorCode= StatusCodes.Status400BadRequest ,  ErrorMessage = "Request is Null" };

			return Ok(error);
		}

		[HttpGet]
		[Route("/api/GetCategories")]
		public async Task<IActionResult> GetCategory()
		{
			return Ok(await categoryRepository.GetAllAsync());
		}

		//https:localhost/api/catgories/{id}
		[HttpGet]
		[Route("/api/GetCategories/{id:Guid}")]
		public async Task<IActionResult> GetCategory(Guid id)
		{
			return Ok(await categoryRepository.GetAsync(id));
		}

		//https:localhost/api/catgories/{id}
		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryRequestDto request)
		{
			return Ok(await categoryRepository.UpdateAsync(id, request));
		}

		//https:localhost/api/catgories/{id}
		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteCategory(Guid id)
		{
			return Ok(await categoryRepository.DeleteAsync(id));
		}
	}
}
