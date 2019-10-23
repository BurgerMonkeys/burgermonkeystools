using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BurgerMonkeys.Tools.Test
{
    public class AngleTest
    {
        [Theory(DisplayName = "Test to check the angle converter(decimal)")]
        [InlineData("90°0'0")]
        [InlineData("180°00'00")]
        [InlineData("0°0'0")]
        public void AngleToDecimal(string angle)
        {
            var p = angle.AngleToDecimal();
        }

        [Fact]
        public void AngleWithEmptyString()
        {
            var angle = string.Empty;
            Assert.Throws<ArgumentException>(() =>
            {
                angle.AngleToDecimal();
            });
        }

        [Theory(DisplayName = "Test to check the angle converter(string)")]
        [InlineData("90°0'0")]
        [InlineData("180°00'00")]
        [InlineData("0°0'0")]
        public void AngleToString(string angle)
        {
            var p = angle.AngleToString();
        }
    }
}
