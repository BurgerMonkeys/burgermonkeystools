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
    }
}
