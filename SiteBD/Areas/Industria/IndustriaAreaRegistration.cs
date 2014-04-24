using System.Web.Mvc;

namespace SiteBD.Areas.Industria
{
    public class IndustriaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Industria";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Industria_default",
                "Industria/{controller}/{action}/{id}",
                new { action = "Index",controler="Industria", id = UrlParameter.Optional }
            );
        }
    }
}