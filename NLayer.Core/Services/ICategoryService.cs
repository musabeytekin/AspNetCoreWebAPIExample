using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
	public interface ICategoryService: IService<Category>
	{
		Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int id);
	}
}