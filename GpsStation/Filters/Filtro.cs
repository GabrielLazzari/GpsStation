using Microsoft.AspNetCore.Mvc.Filters;

namespace Ftec.ProjetosWeb.GPStation.MVC.Filters
{
    public class Filtro : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
