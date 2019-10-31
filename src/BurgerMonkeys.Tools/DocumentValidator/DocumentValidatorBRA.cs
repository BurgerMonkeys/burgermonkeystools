using System;
namespace BurgerMonkeys.Tools
{
    public static class DocumentValidator
    {
        /// <summary>
        /// Method to validation the string is a valid CPF document number
        /// </summary>
        /// <param name="cpf">String to valitation</param>
        /// <returns>If the string is a valid CPF document number</returns>
        public static bool IsValidCPF(this string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            if (!cpf.IsMatch(RegexConstants.Cpf))
                return false;

            cpf = cpf.OnlyNumbers();

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            var multDig1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var numbers = cpf.Substring(0, 9);
            var numbersSumDig1 = 0;

            for (int i = 0; i < 9; i++)
                numbersSumDig1 += int.Parse(numbers[i].ToString()) * (multDig1[i]);

            int restDivision = numbersSumDig1 % 11;
            if (restDivision < 2)
                restDivision = 0;
            else
                restDivision = 11 - restDivision;

            var verifyingDigit = restDivision.ToString();
            numbers += verifyingDigit;

            var multDig2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int numbersSumDig2 = 0;
            for (int i = 0; i < 10; i++)
                numbersSumDig2 += int.Parse(numbers[i].ToString()) * multDig2[i];
            restDivision = numbersSumDig2 % 11;
            if (restDivision < 2)
                restDivision = 0;
            else
                restDivision = 11 - restDivision;

            verifyingDigit += restDivision.ToString();
            return cpf.EndsWith(verifyingDigit, StringComparison.Ordinal);
        }

        /// <summary>
        /// Method to validation the string is a valid CNPJ document number
        /// </summary>
        /// <param name="cnpj">String to valitation</param>
        /// <returns>If the string is a valid CNPJ document number</returns>
        public static bool IsValidCNPJ(this string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            if (!cnpj.IsMatch(RegexConstants.Cnpj))
                return false;

            cnpj = cnpj.OnlyNumbers();
            if (cnpj.Length != 14)
                return false;

            if (new string(cnpj[0], cnpj.Length) == cnpj)
                return false;

            var multDig1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multDig2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var sumDig = 0;
            var sumDig2 = 0;

            for (int i = 0; i < cnpj.Length; i++)
            {
                var digit = cnpj[i].ToString().ToInt();
                if (i < 12)
                {
                    sumDig += digit * multDig1[i];
                    sumDig2 += digit * multDig2[i];
                }
                else if (i == 12)
                {
                    var dv1 = (sumDig % 11);
                    dv1 = dv1 < 2 ? 0 : 11 - dv1;
                    if (digit != dv1)
                        return false;

                    sumDig2 += dv1 * multDig2[12];
                }
                else if (i == 13)
                {
                    var dv2 = (sumDig2 % 11);
                    dv2 = dv2 < 2 ? 0 : 11 - dv2;
                    if (digit != dv2)
                        return false;
                }
            }

            return true;
        }
    }
}
