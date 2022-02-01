using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.Helpers
{
    public class ModelStateResponseHelper
    {
        public static IList<string> ResponseInvalidModel(ModelStateDictionary modelState)
        {
            var response = (from property in modelState.Keys
                            from error in modelState[property].Errors
                            select $"{property}: {error.ErrorMessage}").ToList();

            return response;
        }
    }
}
