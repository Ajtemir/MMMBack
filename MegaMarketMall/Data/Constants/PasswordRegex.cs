namespace MegaMarketMall.Data.Constants
{
    public static class PasswordRegex
    {
        public const string Regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$";
        public const string RegexErrorMessage = "Password consists at least 1 uppercase character, 1 lowercase character,1 digit and 8 characters";
    }
}