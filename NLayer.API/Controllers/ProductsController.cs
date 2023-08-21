using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _service = service;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await _service.GetAllAsync();
            var resultDtos = _mapper.Map<List<ProductDto>>(result).ToList();
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, resultDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            var resultDto = _mapper.Map<ProductDto>(result);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, resultDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto product)
        {
            var result = await _service.AddAsync(_mapper.Map<Product>(product));
            var resultDto = _mapper.Map<ProductDto>(result);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, resultDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(product));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var productToDelete = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(productToDelete);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

