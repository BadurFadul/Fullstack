using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Src.Abstractions;
using WebApi.Domain.Src.Shared;

namespace WebApi.Controller.Src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class CrudController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _baseService;
        public CrudController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery]Options queryOptions)
        {
            return Ok(await _baseService.GetAll(queryOptions));
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TReadDto>> GetById([FromRoute] string id)
        {
            return Ok(await _baseService.GetById(id));
        }

        [HttpPost]
        public virtual async Task<ActionResult<TReadDto>> Post([FromBody]TCreateDto item)
        {
            var createdObject = await _baseService.postItem(item);
            return CreatedAtAction("created", createdObject);
        }

        [HttpPatch("{id}")]
        public virtual async Task<ActionResult<TReadDto>> Update([FromRoute]string id,[FromBody] TUpdateDto updateItem)
        {
            var updatedObject = _baseService.UpdateItem(id, updateItem);
            return Ok(updateItem);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TReadDto>> DeleteById([FromRoute]string id)
        {
            return StatusCode(204,await _baseService.DeleteItem(id));
        }
    }
}