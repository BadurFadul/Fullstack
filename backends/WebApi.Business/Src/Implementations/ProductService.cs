using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Dtos;
using WebApi.Business.Src.Shared;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;

namespace WebApi.Business.Src.Implementations
{
   public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {
        private readonly IBaseRepo<Category> _categoryRepo;  // Inject the category repository
        private readonly IProductRepo _productrepo;  // Assuming you'll use this for other product-specific methods

        public ProductService(IBaseRepo<Product> baseRepo, IBaseRepo<Category> categoryRepo, IMapper mapper) 
            : base(baseRepo, mapper)
        {
            _categoryRepo = categoryRepo;
        }

        public override async Task<ProductReadDto> postItem(ProductCreateDto item)
        {
            // Check if the category exists
            var category = await _categoryRepo.GetById(item.CategoryId);
            if (category == null)
            {
                throw CustomException.NotFoundException("Category not found");
            }

            // Continue with the base postItem logic
            return await base.postItem(item);
        }
    }
}