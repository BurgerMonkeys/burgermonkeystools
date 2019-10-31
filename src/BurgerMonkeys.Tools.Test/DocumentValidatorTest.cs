using Xunit;

namespace BurgerMonkeys.Tools.Test
{
    public class DocumentValidatorTest
    {
        [Theory(DisplayName = "Test validation cpf with valid string")]
        [InlineData("405.158.680-43")]
        [InlineData("120.075.410-76")]
        [InlineData("531.178.870-40")]
        [InlineData("114.582.340-88")]
        [InlineData("817.727.400-71")]
        [InlineData("29836487026")]
        [InlineData("08070228024")]
        [InlineData("26650737062")]
        [InlineData("34247541021")]
        [InlineData("06792882011")]
        public void IsValidCPFValidTest(string cpf)
        {
            var isValid = cpf.IsValidCPF();
            Assert.True(isValid);
        }

        [Theory(DisplayName = "Test validation cpf with invalid string")]
        [InlineData("405.158.610-43")]
        [InlineData("120.075.410-46")]
        [InlineData("531.178.870-45")]
        [InlineData("114.58.340-88")]
        [InlineData("817.7a7.400-71")]
        [InlineData("29836187026")]
        [InlineData("08070328024")]
        [InlineData("26650t37062")]
        [InlineData("3424as41021")]
        [InlineData("00000000000")]
        public void IsValidCPFInvalidTest(string cpf)
        {
            var isValid = cpf.IsValidCPF();
            Assert.False(isValid);
        }

        [Theory(DisplayName = "Test validation cnpj with valid string")]
        [InlineData("18.336.694/0001-06")]
        [InlineData("74.882.620/0001-38")]
        [InlineData("62.085.667/0001-91")]
        [InlineData("39.554.298/0001-17")]
        [InlineData("58.005.323/0001-58")]
        [InlineData("63062965000129")]
        [InlineData("25320683000195")]
        [InlineData("38831078000120")]
        [InlineData("96850035000199")]
        [InlineData("88210827000170")]
        public void IsValidCNPJValidTest(string cnpj)
        {
            var isValid = cnpj.IsValidCNPJ();
            Assert.True(isValid);
        }

        [Theory(DisplayName = "Test validation cnpj with invalid string")]
        [InlineData("18.136.694/0001-06")]
        [InlineData("74.e82.620/0001-38")]
        [InlineData("62.385.667/0001-91")]
        [InlineData("39.54.298/0001-17")]
        [InlineData("58.065.323/0001-58")]
        [InlineData("630as965000129")]
        [InlineData("25344683000195")]
        [InlineData("38078000120")]
        [InlineData("00000000000000")]
        [InlineData("asdfasdfad")]
        public void IsValidCNPJInvalidTest(string cnpj)
        {
            var isValid = cnpj.IsValidCNPJ();
            Assert.False(isValid);
        }
    }
}
