namespace Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls
{
    /// <summary>
    /// Class for defining custom error class related with generate Random number method
    /// </summary>
    public static class RandomNumberGeneratorErrors
    {
        public static Error RandomNumberInvalidValue() => new Error("RandomNumberGenerator.InvalidValue", "Invalid value returned from third party service");
        public static Error RandomNumberServiceTimeout() => new Error("RandomNumberGenerator.ServiceTimeout", "Timeout occurred in communication with third party service");
        public static Error RandomNumberServiceError() => new Error("RandomNumberGenerator.ServiceError", "Error occurred in communication with third party service");
    }
}
