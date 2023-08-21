using AutoMapper;
using Moq;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Dtos;
using WebApi.Business.Src.Implementations;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;
using WebApi.Domain.Src.Shared;

namespace WebApi.Test.src
{
    public class IUserServiceTest
    {
        private readonly Mock<IUserRepo> _userRepo;
        private readonly IUserService _userService;
        private readonly Mock<IMapper> _mockMapper;

        public IUserServiceTest()
        {
            _userRepo = new Mock<IUserRepo>();
            _mockMapper = new Mock<IMapper>();
            _userService = new UserService(_userRepo.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task GetAll_ReturnsAllUsers ()
        {
            // Arrange 
            var users = new List<User> { new User {}, new User()};
            var userReadDtos = new List<UserReadDto> { new UserReadDto(), new UserReadDto()};
            var queryOptions = new Options();

            _userRepo.Setup(repo => repo.GetAll(queryOptions)).ReturnsAsync(users);
            _mockMapper.Setup(m => m.Map<IEnumerable<UserReadDto>>(users)).Returns(userReadDtos);

            // Act
            var result = await _userService.GetAll(queryOptions);

            // Assert
            Assert.Equal(userReadDtos, result);
        }

        [Fact]
        public async Task GetById_ReturnsById ()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var user = new User();
            var userReadDto = new UserReadDto();

            _userRepo.Setup(repo => repo.GetById(id)).ReturnsAsync(user);
            _mockMapper.Setup(m => m.Map<UserReadDto>(user)).Returns(userReadDto);

            // Act 
            var result = await _userService.GetById(id);

            // Assert
            Assert.Equal(userReadDto, result);
        }
        
        [Fact]
        public async Task UpdatePassworD_ReturnsNewPassworD ()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var user = new User();
            var userReadDto = new UserReadDto();
            var newPassword = "newPassword";

            _userRepo.Setup(repo => repo.GetById(id)).ReturnsAsync(user);
            _userRepo.Setup(repo => repo.UpdatePassword(user)).ReturnsAsync(user);
            _mockMapper.Setup(m => m.Map<UserReadDto>(user)).Returns(userReadDto);

            // Act
            var result = await _userService.UpdatePassword(id, newPassword);

            // Assert
            Assert.Equal(userReadDto,result);
        }

        [Fact]
        public async Task PostUser_ReturnsNewUser()
        {
            // Arrange
            var userCreateDto = new UserCreateDto { Password = "password" };
            var user = new User();
            var userReadDto = new UserReadDto();

            _userRepo.Setup(repo => repo.postItem(user)).ReturnsAsync(user);
            _mockMapper.Setup(m => m.Map<UserReadDto>(user)).Returns(userReadDto);

            //Act
            var result = await _userService.postItem(userCreateDto);

            //Assert
            Assert.Equal(userReadDto,result);
            Assert.NotNull(user.Password); // Ensure password is hashed
            Assert.NotNull(user.Salt);
        }

        [Fact]
        public async Task CreateAdmin_RetursAdmin()
        {
            // Arrange
            var userCreateDto = new UserCreateDto { Password = "adminPassword" };
            var user = new User();
            var userReadDto = new UserReadDto();

            _userRepo.Setup(u => u.CreateAdmin(user)).ReturnsAsync(user);
            _userRepo.Setup(repo => repo.CreateAdmin(user)).ReturnsAsync(user);
            _mockMapper.Setup(mapper => mapper.Map<UserReadDto>(user)).Returns(userReadDto);

            // Act
            var result = await _userService.CreateAdmin(userCreateDto);

            // Assert
            Assert.Equal(userReadDto, result);
            Assert.NotNull(user.Password); // Ensure password is hashed
            Assert.NotNull(user.Salt);     // Ensure salt is generated
        }

        [Fact]
        public async Task UpdateUser_UpdatesAndReturnsUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId, FirstName = "John" };
            var updatedUser = new User { Id = userId, FirstName = "John Doe" };
            var userUpdateDto = new UserUpdateDto { FirstName = "John Doe" };
            var userReadDto = new UserReadDto { Id = userId, FirstName = "John Doe" };

            _userRepo.Setup(repo => repo.GetById(userId)).ReturnsAsync(user);
            _userRepo.Setup(repo => repo.UpdateItem(userId, It.IsAny<User>())).ReturnsAsync(updatedUser);
            _mockMapper.Setup(m => m.Map<UserReadDto>(updatedUser)).Returns(userReadDto);

            // Act
            var result = await _userService.UpdateItem(userId, userUpdateDto);

            // Assert
            Assert.Equal(userReadDto.FirstName, result.FirstName);
        }

        [Fact]
        public async Task DeleteUser_ReturnsTrueIfDeleted()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId, FirstName = "John" };

            _userRepo.Setup(repo => repo.GetById(userId)).ReturnsAsync(user);
            _userRepo.Setup(repo => repo.DeleteItem(It.IsAny<User>())).ReturnsAsync(true);

            // Act
            var result = await _userService.DeleteItem(userId);

            // Assert
            Assert.True(result);
        }    
    }
}