namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            else if (input == "")
            {
                throw new ArgumentException($"{nameof(input)} cannot be empty.", nameof(input));
            }

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
