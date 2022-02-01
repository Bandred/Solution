using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Helpers
{
    public class ResponseHelper<T>
    {
        public Guid EventId { get; private set; }
        public T Result { get; private set; }
        public bool Success { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }


        public static ResponseHelper<T> AddResponse(T result, bool success, int statusCode, string message, Guid? eventId = null)
        {
            if (eventId == null)
            {
                return new ResponseHelper<T>()
                {
                    EventId = Guid.NewGuid(),
                    Result = result,
                    Success = success,
                    StatusCode = statusCode,
                    Message = message
                };
            }

            return new ResponseHelper<T>()
            {
                EventId = eventId.Value,
                Result = result,
                Success = success,
                StatusCode = statusCode,
                Message = message
            };

        }
    }
}
