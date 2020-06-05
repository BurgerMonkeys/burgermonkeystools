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


        [Theory(DisplayName = "Test url validator with valid url")]
        [InlineData("https://www.example.com")]
        [InlineData("http://www.example.com")]
        [InlineData("www.example.com")]
        [InlineData("example.com")]
        [InlineData("http://blog.example.com")]
        [InlineData("http://www.example.com/product")]
        [InlineData("http://www.example.com/products?id=1&page=2")]
        [InlineData("http://www.example.com#up")]
        [InlineData("http://www.site.com:8008")]
        public void IsUrlValidTest(string url)
        {
            Assert.True(url.IsUrl());
        }

        [Theory(DisplayName = "Test url validator with invalid url")]
        [InlineData("http://invalid.com/perl.cgi?key= | http://web-site.com/cgi-bin/perl.cgi?key1=value1&key2")]
        public void IsUrlInvalidTest(string url)
        {
            Assert.False(url.IsUrl());
        }

        [Theory(DisplayName = "Test ContainsAny")]
        [InlineData("Test contains any", new string[] { "any", "test" },  true)]
        [InlineData("Test contains any", new string[] { "options", "22" }, false)]
        public void ContainsAnyTest(string stringValue, string[] options, bool result)
        {
            var itemResult = stringValue.ContainsAny(options);
            Assert.Equal(itemResult, result);
        }
    }
}