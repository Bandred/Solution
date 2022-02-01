using System;

namespace CrossCutting.Helpers
{
    public class ErrorHelper
    {
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }

        public static ErrorHelper AddError(Exception ex)
        {
            return new ErrorHelper()
            {
                Message = string.IsNullOrWhiteSpace(ex.Message) ? "" : ex.Message,
                InnerException = (ex.InnerException) == null ? "" : ex.InnerException.InnerException.Message,
                StackTrace = string.IsNullOrWhiteSpace(ex.StackTrace) ? "" : ex.StackTrace
            };
        }
    }
}
