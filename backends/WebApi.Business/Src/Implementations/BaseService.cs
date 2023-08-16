using AutoMapper;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Shared;
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

        public async Task<bool> DeleteItem(Guid id)
        {
            var foundItem = await _repo.GetById(id);
            if (foundItem != null)
            {
                await _repo.DeleteItem(foundItem);
                return true;
            }
            return false;
            throw CustomException.NotFoundException();
            
        }

        public async Task<IEnumerable<TReadDto>> GetAll(Options queryOptions)
        {
            // if( await _repo.GetAll(queryOptions) ==null)
            // {
            //     throw new Exception("users not found");
            // }
            return _mapper.Map<IEnumerable<TReadDto>>(await _repo.GetAll(queryOptions));
        }

        public async Task<TReadDto> GetById(Guid id)
        {
            if(await _repo.GetById(id)== null)
            {
                 throw CustomException.NotFoundException();
            }
           return _mapper.Map<TReadDto> (await _repo.GetById(id));
        }

        public virtual async Task<TReadDto> postItem(TWriteDto item)
        {
            var entity = _mapper.Map<T>(item);
            var createdEntity = await _repo.postItem(entity);
            if(createdEntity == null)
            {
                throw CustomException.NotFoundException();
            }
            return _mapper.Map<TReadDto>(createdEntity);
        }

        public async Task<TReadDto> UpdateItem(Guid id, TUpdateDto item)
        {
            _ = await _repo.GetById(id) ?? throw CustomException.NotFoundException();
            var entity = _mapper.Map<T>(item);
            var updatedEntity = await _repo.UpdateItem(id, entity);
            if(updatedEntity == null)
            {
                throw CustomException.NotFoundException("Failed to update item");  // Use custom exception
            }
            return _mapper.Map<TReadDto>(updatedEntity);
        }
    }
}