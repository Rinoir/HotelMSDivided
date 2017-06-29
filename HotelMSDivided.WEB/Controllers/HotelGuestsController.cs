using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMSDivided.WEB.Models;
using HotelMSDivided.BLL.Interfaces;
using HotelMSDivided.BLL.DTO;
using AutoMapper;

namespace HotelMSDivided.WEB.Controllers
{
    public class HotelGuestsController : Controller
    {
        private IHotelGuestsService guestService;

        public HotelGuestsController(IHotelGuestsService context)
        {
            guestService = context;
        }

        //// GET: HotelGuests
        public ActionResult Index()
        {
            return View(guestService.GetHotelGuests());
        }

        // GET: HotelGuests/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hotelGuest = guestService.GetHotelGuest(id);
            if (hotelGuest == null)
            {
                return HttpNotFound();
            }

            return View(hotelGuest);
        }
                
        // GET: HotelGuests/Create
        public ActionResult Create()
        {
            ViewBag.PhoneNumberTypeCode = new SelectList(guestService.GetNumbersTypes(), "PhoneNumberTypeCode", "PhoneNumberTypeName");
            return View();
        }

        // POST: HotelGuests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestMail,Surname,Name,Patronymic,PassportSerialNumber,PassportNumber,PhoneNumberTypeCode,PhoneNumber")] GuestModel guest)
        {
            if (ModelState.IsValid)
            {
                guestService.Create(guest);

                SignIn(guest.GuestMail);
                
                return RedirectToAction("Index", "HotelRooms");
            }
            
            return View(guest);
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string login)
        {

            if (guestService.IsExists(login))
            {
                var cookie = new HttpCookie("Login");
                cookie.Expires = DateTime.Now.AddHours(1);
                cookie.Value = login;
                Response.SetCookie(cookie);

                cookie = new HttpCookie("Status");
                cookie.Expires = DateTime.Now.AddHours(1);
                cookie.Value = "Guest";
                Response.SetCookie(cookie);
            }

            return RedirectToAction("Index", "HotelRooms");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                guestService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
