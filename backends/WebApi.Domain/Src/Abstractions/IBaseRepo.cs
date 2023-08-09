using WebApi.Domain.Src.Shared;

namespace WebApi.Domain.Src.Abstractions
{
    public interface IBaseRepo<T> // repo should not work with Dto, origninal entites only
    {
        Task<IEnumerable<T>> GetAll(Options queryOptions); //should consider the sorting, searching, and pagnination
        Task<T> GetById(string id);
        Task<T> postItem(T item);
        Task<T> UpdateItem(string id, T item);
        Task<bool> DeleteItem(T item);
    }
}