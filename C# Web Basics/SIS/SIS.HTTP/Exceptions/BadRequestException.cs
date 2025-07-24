namespace SIS.HTTP.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        private const string DefaultExceptionMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : base(DefaultExceptionMessage)
        { }

        public BadRequestException(string message)
            : base(message)
        { }

        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
