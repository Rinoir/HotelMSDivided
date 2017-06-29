using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMSDivided.WEB.Models;
using HotelMSDivided.WEB.HashChecker;
using HotelMSDivided.BLL.Interfaces;
using HotelMSDivided.BLL.DTO;
using AutoMapper;

namespace HotelMSDivided.WEB.Controllers
{
    public class OrdersRegistrationsController : Controller
    {
        private IOrdersRegistrationsService ordersService;

        public OrdersRegistrationsController(IOrdersRegistrationsService context)
        {
            ordersService = context;
        }

        // GET: OrdersRegistrations
        public ActionResult Index()
        {
            var ordersRegistration = ordersService.GetOrders();
            return View(ordersRegistration.ToList());
        }

        // GET: OrdersRegistrations/Create
        public ActionResult Create(int roomNumber)
        {
            string profileName = Request.Cookies["Login"].Value;

            if (!ordersService.IsExists(profileName))
            {
                var order = new OrdersRegistrationDTO()
                {
                    GuestMail = profileName,
                    RoomNumber = roomNumber,
                    BookingDate = DateTime.Now,
                    ArrivalDate = DateTime.Now,
                    LeavingDate = DateTime.Now,
                    PaymentMethodCode = 1,
                    OrderStatus = 1
                };

                ordersService.Create(order);

                return RedirectToAction("Edit", new { login = profileName });
            }

            return RedirectToAction("Index", "HotelRooms");
        }

        // GET: OrdersRegistrations/Edit/5
        public ActionResult Edit(string login)
        {
            if (login == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = ordersService.GetOrder(login);
            if (order != null)
            {
                ViewBag.PaymentMethodCode = new SelectList(ordersService.GetPaymentMethods(), "PaymentMethodCode", "PaymentMethodName", order.PaymentMethodCode);
                return View(order);
            }

            return RedirectToAction("Index", "HotelRooms");
        }

        // POST: OrdersRegistrations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GuestMail,RoomNumber,BookingDate,ArrivalDate,LeavingDate,PaymentMethodCode,OrderStatus")] OrdersRegistrationDTO ordersRegistration)
        {
            if (ModelState.IsValid)
            {
                ordersRegistration.OrderStatus = 2;
                ordersService.Update(ordersRegistration);
                return RedirectToAction("Index", "HotelRooms");
            }

            return RedirectToAction("Edit", new { login = ordersRegistration.GuestMail });
        }

        //public ActionResult Confirm(int id)
        //{
        //    var order = db.OrdersRegistration.Find(id);

        //    var registration = new HotelsRoomRegistration()
        //    {
        //        GuestMail = order.GuestMail,
        //        StaffMail = Request.Cookies["Login"].Value,
        //        BookedRoomNumber = order.RoomNumber,
        //        BookingDate = order.BookingDate,
        //        ArrivalDate = order.ArrivalDate,
        //        LeavingDate = order.LeavingDate,
        //        PaymentMethodCode = order.PaymentMethodCode,
        //        OrderStatus = 3
        //    };

        //    db.HotelsRoomRegistration.Add(registration);
        //    db.OrdersRegistration.Remove(order);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //// GET: OrdersRegistrations/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrdersRegistration ordersRegistration = db.OrdersRegistration.Find(id);
        //    if (ordersRegistration == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    db.OrdersRegistration.Remove(ordersRegistration);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ordersService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
