using WebApi.Domain.Src.Shared;

namespace WebApi.Business.Src.Abstractions
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAll(Options queryOptions); //should consider the sorting, searching, and pagnination
        Task<TReadDto> GetById(string id);
        Task<TReadDto> postItem(TCreateDto item);
        Task<TReadDto> UpdateItem(string id, TUpdateDto item);
        Task<bool> DeleteItem(string id);
    }
}