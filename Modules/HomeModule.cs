using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using BestRestaurants;



namespace BestRestaurants
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

    }
  }
}
