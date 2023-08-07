using WebApi.Domain.Src.Shared;

namespace WebApi.Domain.Src.Abstractions
{
    public interface IBaseRepo<T> // repo should not work with Dto, origninal entites only
    {
        IEnumerable<T> GetAll(Options queryOptions); //should consider the sorting, searching, and pagnination
        T GetById(string id);
        T postItem(T item);
        T UpdateItem(string id, T item);
        bool DeleteItem(T item);
    }
}