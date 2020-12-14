using System.Web.Mvc;

namespace Shopping.Areas.Area_DeliveryAddress
{
    public class Area_DeliveryAddressAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Area_DeliveryAddress";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Area_DeliveryAddress_default",
                "Area_DeliveryAddress/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}