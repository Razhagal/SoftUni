namespace SIS.MvcFramework.Attributes.Validation
{
    public class PasswordSisAttribute : ValidationSisAttribute
    {
        private readonly int minLength;

        public PasswordSisAttribute(int minLength, string errorMessage)
            : base(errorMessage)
        {
            this.minLength = minLength;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = (string)Convert.ChangeType(value, typeof(string));
            if (valueAsString.Length < minLength)
            {
                return false;
            }

            return true;
        }
    }
}
