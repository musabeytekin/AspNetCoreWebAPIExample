using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await _productService.GetAllAsync();
            var resultDtos = _mapper.Map<List<ProductDto>>(result).ToList();
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, resultDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            var resultDto = _mapper.Map<ProductDto>(result);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, resultDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategoryAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto product)
        {
            var result = await _productService.AddAsync(_mapper.Map<Product>(product));
            var resultDto = _mapper.Map<ProductDto>(result);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, resultDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(product));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var productToDelete = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(productToDelete);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

