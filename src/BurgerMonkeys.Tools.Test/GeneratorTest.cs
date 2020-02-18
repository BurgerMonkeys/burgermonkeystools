using System;
using Xunit;

namespace BurgerMonkeys.Tools.Test
{
    public class GeneratorTest
    {
        [Fact(DisplayName = "Test generator string guid")]
        public void GetGuidTest()
        {
            var guid = Generator.GetGuid();
            Assert.NotNull(guid);
            Assert.Equal(36, guid.Length);
        }

        [Theory(DisplayName = "Test generator randon string id with valid length")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        public void GetIdWithValidLengthTest(int length)
        {
            var id = Generator.GetId(length);
            Assert.NotNull(id);
            Assert.Equal(length, id.Length);
        }

        [Theory(DisplayName = "Test generator randon string id with invalid length")]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-5)]
        [InlineData(0)]
        public void GetIdWithInvalidLengthTest(int length)
        {
            void action() => Generator.GetId(length);
            Assert.Throws<ArgumentException>(action);
        }

        [Theory(DisplayName = "Test generator name initials with valid names")]
        [InlineData("John Wick", "JW")]
        [InlineData("Keanu Reeves", "KR")]
        [InlineData("Scarlett Johansson", "SJ")]
        [InlineData("Emilia Clarke", "EC")]
        public void GetNameInitialsValidTest(string name, string expectedInitials)
        {
            var initials = Generator.GetNameInitials(name);
            Assert.True(expectedInitials == initials);
        }

        [Theory(DisplayName = "Test generator name initials with invalid names")]
        [InlineData(null)]
        [InlineData("")]
        public void GetNameInitialsInvalidTest(string name)
        {
            void action() => Generator.GetNameInitials(name);
            Assert.Throws<ArgumentException>(action);
        }
    }
}
