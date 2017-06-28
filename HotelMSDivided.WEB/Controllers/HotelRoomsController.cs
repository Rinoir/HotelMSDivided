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
    public class HotelRoomsController : Controller
    {
        private IHotelRoomsService roomService;

        public HotelRoomsController(IHotelRoomsService service)
        {
            roomService = service;
        }

        // GET: HotelRooms
        public ActionResult Index()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HotelRoomsDTO, HotelRoomsViewModel>().ReverseMap();
                cfg.CreateMap<RoomClassesDTO, RoomClassesViewModel>().ReverseMap();                
            });
            var hotelRoomsDTO = roomService.GetHotelRooms();
            var hotelRooms = new List<HotelRoomsViewModel>();
            foreach (var item in hotelRoomsDTO)
            {
                hotelRooms.Add(Mapper.Map<HotelRoomsDTO, HotelRoomsViewModel>(item));
            }
            return View(hotelRooms.ToList());
        }

        // GET: HotelRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HotelRoomsDTO, HotelRoomsViewModel>().ReverseMap();
                cfg.CreateMap<RoomClassesDTO, RoomClassesViewModel>().ReverseMap();
            });
            var hotelRooms = Mapper.Map<HotelRoomsDTO, HotelRoomsViewModel>(roomService.GetHotelRoom(id));
            if (hotelRooms == null)
            {
                return HttpNotFound();
            }
            return View(hotelRooms);
        }

        //// GET: HotelRooms/Create
        public ActionResult Create()
        {
            
            ViewBag.RoomClassCode = new SelectList(roomService.GetRoomClasses(), "RoomClassCode", "RoomClassName");
            return View();
        }

        //// POST: HotelRooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomNumber,RoomClassCode,Floor,DayCost,RoomsAmount")] HotelRoomsViewModel hotelRooms)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<HotelRoomsViewModel, HotelRoomsDTO>().ReverseMap();
                    cfg.CreateMap<RoomClassesViewModel, RoomClassesDTO>().ReverseMap();
                });
                var hotelRoomsDTO = Mapper.Map<HotelRoomsViewModel, HotelRoomsDTO>(hotelRooms);
                roomService.Create(hotelRoomsDTO);
                return RedirectToAction("Index");
            }

            ViewBag.RoomClassCode = new SelectList(roomService.GetRoomClasses(), "RoomClassCode", "RoomClassName", hotelRooms.RoomClassCode);
            return View(hotelRooms);
        }

        /////////////////////////////NOT YET READY///////////////////////////
        //// GET: HotelRooms/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HotelRooms hotelRooms = db.HotelRooms.Find(id);
        //    if (hotelRooms == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.RoomClassCode = new SelectList(db.RoomClasses, "RoomClassCode", "RoomClassName", hotelRooms.RoomClassCode);
        //    return View(hotelRooms);
        //}

        /////////////////////////////NOT YET READY///////////////////////////
        //// POST: HotelRooms/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RoomNumber,RoomClassCode,Floor,DayCost,RoomsAmount")] HotelRooms hotelRooms)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(hotelRooms).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.RoomClassCode = new SelectList(db.RoomClasses, "RoomClassCode", "RoomClassName", hotelRooms.RoomClassCode);
        //    return View(hotelRooms);
        //}

        /////////////////////////////NOT YET READY///////////////////////////
        //// GET: HotelRooms/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HotelRooms hotelRooms = db.HotelRooms.Find(id);
        //    if (hotelRooms == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hotelRooms);
        //}

        /////////////////////////////NOT YET READY///////////////////////////
        //// POST: HotelRooms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    HotelRooms hotelRooms = db.HotelRooms.Find(id);
        //    db.HotelRooms.Remove(hotelRooms);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                roomService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}