using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;
using System.Xml.Linq;

namespace MotoGP.Controllers
{
    public class InfoController:Controller
    {
        public IActionResult ListRaces()
        {
            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            return View();
        }

        public IActionResult BuildMap()
        {
            List<Race> races = new List<Race>();
            races.Add(new Race(1, 517, 19, "Assen"));
            races.Add(new Race(2, 859, 249, "Losail Circuit"));
            races.Add(new Race(3, 194, 428, "Autódromo Termas de Río Hondo"));
            ViewData["Races"] = races;
            ViewData["BannerNr"] = 0;
            return View();
        }
    }
}
