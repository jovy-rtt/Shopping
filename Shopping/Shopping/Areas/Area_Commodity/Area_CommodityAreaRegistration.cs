using System.Web.Mvc;

namespace Shopping.Areas.Area_Commodity
{
    public class Area_CommodityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Area_Commodity";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Area_Commodity_default",
                "Area_Commodity/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}