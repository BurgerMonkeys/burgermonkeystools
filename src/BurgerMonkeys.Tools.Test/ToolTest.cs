using System;
using Xunit;

namespace BurgerMonkeys.Tools.Test
{
    public class ToolTest
    {
        [Theory(DisplayName = "Test GetContrastColor method")]
        [InlineData("#50C7F3", "#000000")]
        [InlineData("50C7F3", "#000000")]
        [InlineData("#8CC74F", "#000000")]
        [InlineData("8CC74F", "#000000")]
        [InlineData("#F9D711", "#000000")]
        [InlineData("F9D711", "#000000")]
        [InlineData("#5E5196", "#FFFFFF")]
        [InlineData("5E5196", "#FFFFFF")]
        [InlineData("#0C5390", "#FFFFFF")]
        [InlineData("0C5390", "#FFFFFF")]
        [InlineData("#C40A0B", "#FFFFFF")]
        [InlineData("C40A0B", "#FFFFFF")]
        public void GetNameInitialsValidTest(string color, string contrast)
        {
            var generated = color.GetContrastColor();
            Assert.True(contrast == generated);
        }

        [Theory(DisplayName = "Test repeat with invalid count")]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-5)]
        [InlineData(0)]
        public void RepeatWithInvalidCount(int count)
        {
            void action() => "test".Repeat(count);
            Assert.Throws<ArgumentException>(action);
        }

        [Theory(DisplayName = "Test repeat with valid parameters")]
        [InlineData("test", "testtest", 2)]
        [InlineData("a", "aaaa", 4)]
        public void RepeatWithValid(string item, string result, int count)
        {
            var itemResult = item.Repeat(count);
            Assert.True(result == itemResult);
        }

        [Theory(DisplayName = "Test IsNullOrWhiteSpace")]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData("123", false)]
        public void IsNullOrWhiteSpaceTest(string stringValue, bool result)
        {
            var methodResult = stringValue.IsNullOrWhiteSpace();
            Assert.Equal(result, methodResult);
        }

        [Theory(DisplayName = "Test IsNotNullOrWhiteSpace")]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("123", true)]
        public void IsNotNullOrWhiteSpaceTest(string stringValue, bool result)
        {
            var methodResult = stringValue.IsNotNullOrWhiteSpace();
            Assert.Equal(result, methodResult);
        }
    }
}
