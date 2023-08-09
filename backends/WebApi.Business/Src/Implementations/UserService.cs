
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;

namespace WebApi.Business.Src.Implementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<UserReadDto> UpdatePassword(string id, string password)
        {
            var foundUser =await _userRepo.GetById(id);
            if (foundUser == null)
            {
                throw new InvalidOperationException("User not found");
            }
           return _mapper.Map<UserReadDto> (await _userRepo.UpdatePassword(foundUser, password));
        }
    }
}