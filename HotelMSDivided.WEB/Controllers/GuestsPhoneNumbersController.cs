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
    public class GuestsPhoneNumbersController : Controller
    {
        private IGuestsPhoneNumbersService phonesService;

        public GuestsPhoneNumbersController(IGuestsPhoneNumbersService context)
        {
            phonesService = context;
        }

        public ActionResult Create()
        {
            ViewBag.PhoneNumberTypeCode = new SelectList(phonesService.GetNumbersTypes(), "PhoneNumberTypeCode", "PhoneNumberTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GuestMail,PhoneNumberTypeCode,PhoneNumber")] GuestsPhoneNumbersDTO phone, string login)
        {
            if (login == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            phone.GuestMail = login;

            phonesService.Create(phone);

            return RedirectToAction("Details", "HotelGuests", new { id = login });
        }

        // GET: GuestsPhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var phone = phonesService.GetPhoneNumber(id.Value);

            if (phone == null)
            {
                return HttpNotFound();
            }

            return View(phone);
        }

        // POST: GuestsPhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            phonesService.Delete(id.Value);
            return RedirectToAction("Details", "HotelGuests", new { id = Request.Cookies["Login"].Value });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                phonesService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}