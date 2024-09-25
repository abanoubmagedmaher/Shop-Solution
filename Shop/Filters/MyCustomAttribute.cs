using Microsoft.AspNetCore.Mvc.Filters;

namespace Shop.Filters
{
    public class MyCustomAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Excute When Action Start 
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Excute When Action End 
        }


    }
}
