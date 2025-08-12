namespace Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls
{
    /// <summary>
    /// Class for defining custom error class related with play game method
    /// </summary>
    public static class PlayGameErrors
    {
        public static Error PlayGameNullRequest() => new Error("ValidationError.PlayGame.NullRequest", "Request object is null");
        public static Error PlayGameInvalidValueRequest() => new Error("ValidationError.PlayGame.InvalidValueRequest", "Value of submitted parameter is invalid");
    }
}
