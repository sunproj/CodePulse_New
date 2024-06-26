﻿using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;

namespace CodePulse.API.NEW.Repositories.Interface
{
	public interface ICategoryRepository
	{
		Task<CategoryDto> CreateAsync(CreateCategoryRequestDto category);

		Task<List<CategoryDto>> GetAllAsync();

		Task<Category> GetAsync(Guid id);

		Task<Category?> UpdateAsync(Guid id, UpdateCategoryRequestDto categorydto);

		Task<Category?> DeleteAsync(Guid id);
	}
}
