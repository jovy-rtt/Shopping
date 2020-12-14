using System.Web.Mvc;

namespace Shopping.Areas.Area_Bankcard
{
    public class Area_BankcardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Area_Bankcard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Area_Bankcard_default",
                "Area_Bankcard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}