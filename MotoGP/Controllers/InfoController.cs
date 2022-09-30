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
            ViewData["BannerNr"] = 0;
            return View(races.ToList());
        }
        public IActionResult ShowRace(int id)
        {
            ViewData["BannerNr"] = 0;
            var race = _context.Races.FirstOrDefault(r => r.RaceID == id);
            return View(race);
        }
        public IActionResult ListRiders()
        {
            ViewData["BannerNr"] = 1;
            var riders = _context.Riders.OrderBy(r => r.Number);
            return View(riders.ToList());

        }
    }
}
