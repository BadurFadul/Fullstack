using AutoMapper;
using WebApi.Business.Src.Abstractions;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Shared;

namespace WebApi.Business.Src.Implementations
{
    public class BaseService<T, TReadDto, TWriteDto, TUpdateDto> : IBaseService<T, TReadDto, TWriteDto, TUpdateDto>
    {
        protected readonly IBaseRepo<T> _repo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> baseRepo, IMapper mapper)
        {
            _repo = baseRepo;
            _mapper = mapper;

        }

        public async Task<bool> DeleteItem(string id)
        {
            var foundItem = await _repo.GetById(id);
            if (foundItem == null)
            {
                return false;
            }
             await _repo.DeleteItem(foundItem);
            return true;
        }

        public async Task<IEnumerable<TReadDto>> GetAll(Options queryOptions)
        {
            if(_repo.GetAll(queryOptions) ==null)
            {
                throw new Exception("users not found");
            }
            return _mapper.Map<IEnumerable<TReadDto>> ( await _repo.GetAll(queryOptions));
        }

        public async Task<TReadDto> GetById(string id)
        {
            if(await _repo.GetById(id)== null)
            {
                throw new Exception("user not found");
            }
           return _mapper.Map<TReadDto> (await _repo.GetById(id));
        }

        public virtual async Task<TReadDto> postItem(TWriteDto item)
        {
            var entity = _mapper.Map<T>(item);
            var createdEntity = await _repo.postItem(entity);
            return _mapper.Map<TReadDto>(createdEntity);
        }

        public async Task<TReadDto> UpdateItem(string id, TUpdateDto item)
        {
            _ = await _repo.GetById(id) ?? throw new InvalidOperationException("Item not found");
            var entity = _mapper.Map<T>(item);
            var updatedEntity = await _repo.UpdateItem(id, entity);
            return _mapper.Map<TReadDto>(updatedEntity);
        }
    }
}