namespace Game.Infrastructure.Utilities.Exceptions
{
    /// <summary>
    /// Example of custom written exception
    /// </summary>
    public class ExampleException : Exception
    {
        /// <summary>
        /// Create an instance of the <see cref="ExampleException"/>
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public ExampleException(string? message) : base(message)
        {
            
        }
    }
}
