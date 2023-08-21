using Moq;
using WebApi.Business.Src.Dtos;
using WebApi.Business.Src.Shared;
using WebApi.Domain.Src.Abstractions;
using WebApi.Domain.Src.Entities;

using Xunit;

namespace WebApi.Test.src.Service.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task VerifyCredentials_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepo>();
            var authService = new AuthService(userRepoMock.Object);

            var id = new Guid();
            var userEmail = "test@example.com";
            var userPassword = "password123";
            var userSalt = new byte[32]; // Example salt value
            var user = new User
            {
                Id = id,
                Email = userEmail,
                Password = "hashedPassword",
                Salt = userSalt,
                //Role = "Admin",
                DateOfBirth = new DateOnly(2000, 1, 1)
            };

            userRepoMock.Setup(repo => repo.FindOneByEmail(userEmail)).ReturnsAsync(user);
            PasswordService.HashPassword(userPassword, out _, out userSalt);
            userRepoMock.Setup(repo => repo.FindOneByEmail("nonexistent@example.com")).ReturnsAsync((User)null);

            var credentials = new UserCredentialDto
            {
                Email = userEmail,
                Password = userPassword
            };

            // Act
            var token = await authService.VerifyCredentials(credentials);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
    }
}