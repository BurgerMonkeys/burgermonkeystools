namespace BurgerMonkeys.Tools
{
    public static class RegexConstants
    {
        public const string Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string Url = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
        public const string Cpf = @"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$";
        public const string Cnpj = @"^\d{2}\.?\d{3}\.?\d{3}\/?\d{4}\-?\d{2}$";
        public const string BrazilZipCode = @"^\d{5}-\d{3}$";
    }
}
