using WebApi.Domain.Src.Shared;

namespace WebApi.Business.Src.Abstractions
{
    public interface IBaseService<T, TDto>
    {
        IEnumerable<TDto> GetAll(Options queryOptions); //should consider the sorting, searching, and pagnination
        TDto GetById(string id);
        TDto postItem(TDto item);
        TDto UpdateItem(string id, TDto item);
        bool DeleteItem(string id);
    }
}