using Xunit;

namespace BurgerMonkeys.Tools.Test
{
    public class ValidatorTest
    {
        [Theory(DisplayName = "Test email validator with valid email")]
        [InlineData("email@teste.com")]
        [InlineData("email@teste.com.br")]
        public void IsEmailValidTest(string email)
        {
            Assert.True(email.IsEmail());
        }

        [Theory(DisplayName = "Test email validator with invalid email")]
        [InlineData("email")]
        [InlineData("email@teste")]
        public void IsEmailInvalidTest(string email)
        {
            Assert.False(email.IsEmail());
        }
    }
}
