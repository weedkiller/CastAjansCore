using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CastAjansCore.WebUI.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "Error" };
            var modelDataProvider = new EmptyModelMetadataProvider();
            result.ViewData = new ViewDataDictionary(modelDataProvider, context.ModelState)
            {
                { "HandleException", context.Exception }
            };
            context.Result = result;
            context.ExceptionHandled = true;


        }
    }
}
