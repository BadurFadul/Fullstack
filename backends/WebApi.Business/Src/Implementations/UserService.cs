using AutoMapper;
using WebApi.Business.Src.Dtos;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Shared;

namespace WebApi.Business.Src.Implementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }
        public async Task<UserReadDto> UpdatePassword(Guid id, string password)
        {
            var foundUser =await _userRepo.GetById(id) ?? throw new InvalidOperationException("User not found");
            PasswordService.HashPassword(password, out var hashedPassword, out var salt);
            foundUser.Password = hashedPassword;
            foundUser.Salt = salt;
            return _mapper.Map<UserReadDto> (await _userRepo.UpdatePassword(foundUser));
        }

        public override async Task<UserReadDto> postItem(UserCreateDto item)
        {
            var entity = _mapper.Map<User>(item);
            PasswordService.HashPassword(item.Password, out var hashedPassword, out var salt);
            entity.Password = hashedPassword;
            entity.Salt = salt;
            var created = await _userRepo.postItem(entity);
            return _mapper.Map<UserReadDto>(created);
        }

        public async Task<UserReadDto> CreateAdmin(UserCreateDto user)
        {
            var entity = _mapper.Map<User>(user);
            PasswordService.HashPassword(user.Password, out var hashedPassword, out var salt);
            if(hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            entity.Password = hashedPassword;
            entity.Salt = salt;
            var created = await _userRepo.CreateAdmin(entity);
            return _mapper.Map<UserReadDto>(created);
        }
    }
}