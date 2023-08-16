using WebApi.Domain.Src.Shared;

namespace WebApi.Business.Src.Abstractions
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAll(Options queryOptions); //should consider the sorting, searching, and pagnination
        Task<TReadDto> GetById(Guid id);
        Task<TReadDto> postItem(TCreateDto item);
        Task<TReadDto> UpdateItem(Guid id, TUpdateDto item);
        Task<bool> DeleteItem(Guid id);
    }
}