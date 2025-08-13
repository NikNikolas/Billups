namespace Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls
{
    /// <summary>
    /// Class for defining custom error class related with play game method
    /// </summary>
    public static class PlayGameErrors
    {
        public const string CodeNullRequest = "ValidationError.PlayGame.NullRequest";
        public const string CodeInvalidValueRequest = "ValidationError.PlayGame.InvalidValueRequest";

        public static Error PlayGameNullRequest() => new Error(CodeNullRequest, "Request object is null");
        public static Error PlayGameInvalidValueRequest() => new Error(CodeInvalidValueRequest, "Value of submitted parameter is invalid");
    }
}
