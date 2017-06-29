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
    public class HotelStaffsController : Controller
    {
        private IHotelStaffsService staffService;

        public HotelStaffsController(IHotelStaffsService context)
        {
            staffService = context;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string login, string answer)
        {
            var md5 = new Checker(answer);
            if (md5.VerifyMd5Hash() &&
                staffService.IsExists(login))
            {
                    var cookie = new HttpCookie("Login");
                    cookie.Expires = DateTime.Now.AddHours(1);
                    cookie.Value = login;
                    Response.SetCookie(cookie);

                    cookie = new HttpCookie("Status");
                    cookie.Expires = DateTime.Now.AddHours(1);
                    cookie.Value = "Employee";
                    Response.SetCookie(cookie);
            }           

            return RedirectToAction("Index", "HotelRooms");
        }

        // GET: HotelStaffs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = staffService.GetHotelEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                staffService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}