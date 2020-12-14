using System.Web.Mvc;

namespace Shopping.Areas.Area_Favorites
{
    public class Area_FavoritesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Area_Favorites";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Area_Favorites_default",
                "Area_Favorites/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}