namespace EditorTemplateDemo.Filters
{
    using System.Web.Mvc;
    using Data;
    using Heroic.Web.IoC;

    public class TransactionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = StructureMapContainerPerRequestModule.Container.GetInstance<ApplicationDbContext>();
            context.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var instance = StructureMapContainerPerRequestModule.Container.GetInstance<ApplicationDbContext>();
            instance.CloseTransaction(filterContext.Exception);
        }
    }
}