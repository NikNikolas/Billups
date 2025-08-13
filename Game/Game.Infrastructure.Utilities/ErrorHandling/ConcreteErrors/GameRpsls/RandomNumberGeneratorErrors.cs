namespace Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls
{
    /// <summary>
    /// Class for defining custom error class related with generate Random number method
    /// </summary>
    public static class RandomNumberGeneratorErrors
    {
        public const string CodeToManyRequests = "RandomNumberGenerator.ToManyRequests";
        public const string CodeInvalidValue = "RandomNumberGenerator.InvalidValue";
        public const string CodeServiceTimeout = "RandomNumberGenerator.ServiceTimeout";
        public const string CodeServiceError = "RandomNumberGenerator.ServiceError";

        public static Error RandomNumberInvalidValue() => new Error(CodeInvalidValue, "Invalid value returned from third party service");
        public static Error RandomNumberServiceTimeout() => new Error(CodeServiceTimeout, "Timeout occurred in communication with third party service");
        public static Error RandomNumberServiceError() => new Error(CodeServiceError, "Error occurred in communication with third party service");
        public static Error RandomNumberToManyRequests() => new Error(CodeToManyRequests, "To many requests sent");
    }
}
