using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shop.Filters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //Catch Error
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Some Exception Throw";
            //context.Result = contentResult;

            ViewResult viewResult= new ViewResult();
            viewResult.ViewName = "Error";
            context.Result=viewResult;
        }
    }
}
