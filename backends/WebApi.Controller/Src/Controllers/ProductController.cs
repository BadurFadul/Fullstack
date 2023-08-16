using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controller.Src.Controllers
{
    public class ProductController: CrudController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService): base(productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        public override async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _productService.GetAll(queryOptions));
        }

        [AllowAnonymous]
        public override async Task<ActionResult<ProductReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _productService.GetById(id));
        }

        [Authorize(Roles = "Admin")]
         public override async Task<ActionResult<ProductReadDto>> Post([FromBody]ProductCreateDto item)
        {
            var createdObject = await _productService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<ProductReadDto>> Update([FromRoute]Guid id,[FromBody] ProductUpdateDto updateItem)
        {
            var updatedObject = _productService.UpdateItem(id, updateItem);
            return Ok(updatedObject);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<ProductReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _productService.DeleteItem(id));
        }
    }
}