namespace SIS.HTTP.Exceptions
{
    [Serializable]
    public class InternalServerErrorException : Exception
    {
        private const string DefaultExceptionMessage = "The Server has encountered an error";

        public InternalServerErrorException()
            : base(DefaultExceptionMessage)
        { }

        public InternalServerErrorException(string message)
            : base(message)
        { }

        public InternalServerErrorException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
