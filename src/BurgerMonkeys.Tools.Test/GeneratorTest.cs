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
    }
}
