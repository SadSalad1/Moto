using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;

namespace MotoGP.Controllers
{
    public class ShopController :Controller
    {
        private readonly GPContext _context;

        public ShopController(GPContext context)
        {
            _context = context;
        }
        public IActionResult OrderTicket()
        {
            ViewData["Countries"] =
                new SelectList(_context.Countries.OrderBy(r => r.Name), "CountryID", "Name");

            ViewData["Races"] =
                new List<Race>(_context.Races.OrderBy(r => r.Name));
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderTicket([Bind("OrderID,Name,Email,Address,CountryID,RaceID,Number")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.OrderDate = System.DateTime.Now;
                ticket.Paid = false;

                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new {id = ticket.TicketID});
            }
            return View(ticket);
        }
        public IActionResult ConfirmOrder(int id)
        {
            int BannerNr = 3;
            ViewData["BannerNr"] = BannerNr;
            var ticket = _context.Tickets.Include(t => t.Race)
                .FirstOrDefault(t => t.TicketID == id);
            return View(ticket);
        }
    }
}
