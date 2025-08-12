namespace Game.Infrastructure.Utilities.ErrorHandling
{
    public sealed class Error
    {
        public string Message { get; private set; }
        public string Code { get; private set; }

        public Error(string code, string message)
        {
            Message = code;
            Code = message;
        }

        public static readonly Error None = new Error(string.Empty, string.Empty);
        public static readonly Error NullValue = new Error("Error.NullVale", "Value is null");
    }
}
