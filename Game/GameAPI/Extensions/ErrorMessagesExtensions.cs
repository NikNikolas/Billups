using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Extensions
{
    public static class ErrorMessagesExtensions
    {
        public static List<string> GetErrorMessages(this ActionContext context)
        {
            var errorMessages = new List<string>();
            if (context.ModelState.Count == 1)
            {
                var key = context.ModelState.Keys.FirstOrDefault()?.Replace("$.", string.Empty);

                if (key != "")
                {
                    errorMessages.Add($"Field {key} contains an invalid value");
                }
                else
                {
                    errorMessages.Add($"Request is invalid, header parameters might have invalid values");
                }
            }
            else
            {
                foreach (var item in context.ModelState)
                {
                    if (item.Value.ValidationState == ModelValidationState.Invalid)
                    {
                        if ((item.Key == "") || (item.Key == "$"))
                        {
                            errorMessages.Add($"Body is missing in request");
                            break;
                        }
                        else if (item.Key.Contains("$."))
                        {
                            var key = item.Key?.Replace("$.", string.Empty);
                            var errors = item.Value.Errors;
                            if ((errors?.Count ?? 0) > 0)
                            {
                                if (key != "")
                                {
                                    errorMessages.Add($"Field {key} contains an invalid value");
                                }
                                else
                                {
                                    errorMessages.Add($"Body is missing in request");
                                }
                            }
                        }
                        else
                        {
                            errorMessages.Add(item.Value.Errors.FirstOrDefault().ErrorMessage);
                        }
                    }
                }
            }

            return errorMessages;
        }
    }
}
