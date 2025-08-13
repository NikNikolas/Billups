using System.Runtime.CompilerServices;

namespace Game.Infrastructure.Utilities.Helpers
{
    public static class LogMessageBuilder
    {
        public static string GetStartedMethodMessage([CallerMemberName] string memberName = "")
        {
            return $"Method {memberName} is invoked";
        }
        public static string GetStartedMethodMessage(string message, [CallerMemberName] string memberName = "")
        {
            return $"Method {memberName} is invoked with parameters: {message}";
        }

        public static string GetFinishedMethodMessage([CallerMemberName] string memberName = "")
        {
            return $"Method {memberName} is finished";
        }

        public static string GetFinishedMethodMessage(string message, [CallerMemberName] string memberName = "")
        {
            return $"Method {memberName} is finished with result: {message}";
        }

        public static string GetHttpRequestSucceededMessage(int statusCode,string response,[CallerMemberName] string memberName = "")
        {
            return $"In Method {memberName} http client successfully completed request with status code {statusCode} and response body {response}";
        }

        public static string GetErrorMessage(string errorMessage, [CallerMemberName] string memberName = "")
        {
            return $"In Method {memberName} an error occurred: {errorMessage}";
        }

        public static string GetNotHandledExceptionMessage(Exception exception, [CallerMemberName] string memberName = "")
        {
            return $"Non handled exception was thrown and handled by method {memberName}. Exception: {exception}";
        }

        public static string GetValidationErrorMessage(string errorMessage, [CallerMemberName] string memberName = "")
        {
            return $"In Method {memberName} an validation error occurred: {errorMessage}";
        }

        public static string GetNullValidationErrorMessage(string property, [CallerMemberName] string memberName = "")
        {
            return $"In Method {memberName} an validation error occurred. Property {property} has invalid value - NULL";
        }

        public static string GetNotOkStatusCodeMessage(int statusCode,[CallerMemberName] string memberName = "")
        {
            return $"Method {memberName} is finished with Http Status code {statusCode}";
        }
    }
}
