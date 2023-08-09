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
            return _mapper.Map<IEnumerable<TReadDto>> ( await _repo.GetAll(queryOptions));
        }

        public async Task<TReadDto> GetById(string id)
        {
           return _mapper.Map<TReadDto> (await _repo.GetById(id));
        }

        public async Task<TReadDto> postItem(TWriteDto item)
        {
            var entity = await _repo.postItem(_mapper.Map<T>(item));
            return _mapper.Map<TReadDto>(entity);
        }

        public async Task<TReadDto> UpdateItem(string id, TUpdateDto item)
        {
            var foundItem = await _repo.GetById(id);
            if(foundItem == null)
            {
                throw new InvalidOperationException("Item not found");
            }
            var entity = _mapper.Map<T>(item);
            var updatedEntity = await _repo.UpdateItem(id, entity);
            return _mapper.Map<TReadDto>(updatedEntity);
        }
    }
}