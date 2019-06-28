using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Filters
{
    public class UserHelperAttribute : IActionFilter
    {
        private readonly LoginHelper _loginHelper;

        public UserHelperAttribute(LoginHelper loginHelper)
        {
            _loginHelper = loginHelper;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext..UserHelper = _loginHelper.UserHelper;
        }
    }
}
