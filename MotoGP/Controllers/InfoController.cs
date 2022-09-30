using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;
using MotoGP.Data;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace MotoGP.Controllers
{
    public class InfoController:Controller
    {
        private readonly GPContext _context;

        public InfoController(GPContext context)
        {
            _context = context;
        }
        public IActionResult ListRaces()
        {
            var races = _context.Races.OrderBy(r => r.Date);
            int BannerNr = 0;
            ViewData["BannerNr"] = BannerNr;
            return View(races.ToList());
        }

        public IActionResult BuildMap()
        {
            var races = _context.Races.OrderBy(r => r.Name);
            ViewData["Races"] = races;
            ViewData["BannerNr"] = 0;
            return View(races.ToList());
        }
    }
}
