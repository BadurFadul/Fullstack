using WebApi.Business.Src.Shared;

namespace WebApi.Test.src.Service.Tests
{
    public class IPasswordServiceTest
    {
         [Fact]
        public void HashPassword_ValidInput_ReturnsHashedPasswordAndSalt()
        {
            // Arrange
            const string originalPassword = "myPassword";
            byte[] salt;
            string hashedPassword;

            // Act
            PasswordService.HashPassword(originalPassword, out hashedPassword, out salt);

            // Assert
            Assert.NotNull(salt);
            Assert.NotNull(hashedPassword);
        }

        [Fact]
        public void VerifyPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange
            const string originalPassword = "myPassword";
            byte[] salt;
            string hashedPassword;
            PasswordService.HashPassword(originalPassword, out hashedPassword, out salt);

            // Act
            bool result = PasswordService.VerifyPassword(originalPassword, hashedPassword, salt);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_IncorrectPassword_ReturnsFalse()
        {
            // Arrange
            const string originalPassword = "myPassword";
            byte[] salt;
            string hashedPassword;
            PasswordService.HashPassword(originalPassword, out hashedPassword, out salt);

            // Act
            bool result = PasswordService.VerifyPassword("wrongPassword", hashedPassword, salt);

            // Assert
            Assert.False(result);
        }
    }
}