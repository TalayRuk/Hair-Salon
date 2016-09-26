using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using HairSalon;



namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["index.cshtml", AllStylists];
      };

    }
  }
}
