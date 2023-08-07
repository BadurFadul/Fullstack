
using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;

namespace WebApi.Business.Src.Implementations
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public UserDto UpdatePassword(string id, string password)
        {
            var foundUser = _userRepo.GetById(id);
            if (foundUser == null)
            {
                throw new InvalidOperationException("User not found");
            }
           return _mapper.Map<UserDto> (_userRepo.UpdatePassword(foundUser, password));
        }
    }
}