using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace BusinessLayer.Attributes
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //LogFactory.GetLogger().Error("Get all Fruitstar " + ex.Message + Environment.NewLine + ex.StackTrace);
        }

    }
}
