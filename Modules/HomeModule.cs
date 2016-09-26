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

      Get["/clients"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["client.cshtml", AllClients];
      };

      Get["/stylists"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["stylist.cshtml", AllStylists];
      };

      Get["/stylists/new"] = _ => {
        return View["stylists_form.cshtml"];
      };

      Post["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };

      Get["/clients/new"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["clients_form.cshtml"];
      };

      Post["/clients/new"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-phone"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml"];
      };
    }
  }
}
