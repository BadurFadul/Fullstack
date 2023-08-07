using AutoMapper;
using WebApi.Business.Src.Abstractions;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Shared;

namespace WebApi.Business.Src.Implementations
{
    public class BaseService<T, TDto> : IBaseService<T, TDto>
    {
        protected readonly IBaseRepo<T> _repo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> baseRepo, IMapper mapper)
        {
            _repo = baseRepo;
            _mapper = mapper;

        }

        public bool DeleteItem(string id)
        {
            var foundItem = _repo.GetById(id);
            if (foundItem == null)
            {
                return false;
            }
            //_repo.DeleteItem(foundItem);
            return true;
        }

        public IEnumerable<TDto> GetAll(Options queryOptions)
        {
            return _mapper.Map<IEnumerable<TDto>> (_repo.GetAll(queryOptions));
        }

        public TDto GetById(string id)
        {
           return _mapper.Map<TDto> (_repo.GetById(id));
        }

        public TDto postItem(TDto item)
        {
            var entity = _mapper.Map<T>(item);
            var createdEntity = _repo.postItem(entity);
            return _mapper.Map<TDto>(createdEntity);
        }

        public TDto UpdateItem(string id, TDto item)
        {
            var foundItem = _repo.GetById(id);
            if(foundItem == null)
            {
                throw new InvalidOperationException("Item not found");
            }
            var entity = _mapper.Map<T>(item);
            var updatedEntity = _repo.UpdateItem(id, entity);
            return _mapper.Map<TDto>(updatedEntity);
        }
    }
}