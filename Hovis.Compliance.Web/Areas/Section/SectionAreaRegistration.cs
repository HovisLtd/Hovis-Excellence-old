using System.Web.Mvc;

namespace Hovis.Compliance.Web.Areas.Section
{
    public class SectionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Section";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Section_default",
                "Section/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}