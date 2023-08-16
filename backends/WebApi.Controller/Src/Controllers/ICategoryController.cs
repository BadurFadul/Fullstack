using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Src.Shared;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controller.Src.Controllers
{
    public class CategoryController: CrudController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService): base(categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public override async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _categoryService.GetAll(queryOptions));
        }

        [AllowAnonymous]
        public override async Task<ActionResult<CategoryReadDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> Post([FromBody]CategoryCreateDto item)
        {
            var createdObject = await _categoryService.postItem(item);
            return CreatedAtAction(nameof(Post), createdObject);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> Update([FromRoute]Guid id,[FromBody] CategoryUpdateDto updateItem)
        {
            var updatedObject = _categoryService.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<CategoryReadDto>> DeleteById([FromRoute]Guid id)
        {
            return StatusCode(204,await _categoryService.DeleteItem(id));
        }
    }
}