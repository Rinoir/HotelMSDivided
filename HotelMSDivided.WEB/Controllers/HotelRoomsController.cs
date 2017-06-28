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
        
        // GET: HotelRooms/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.RoomClassCode = new SelectList(roomService.GetRoomClasses(), "RoomClassCode", "RoomClassName", hotelRooms.RoomClassCode);
            return View(hotelRooms);
        }
        
        //// POST: HotelRooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomNumber,RoomClassCode,Floor,DayCost,RoomsAmount")] HotelRoomsViewModel hotelRooms)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<HotelRoomsViewModel, HotelRoomsDTO>().ReverseMap();
                    cfg.CreateMap<RoomClassesViewModel, RoomClassesDTO>().ReverseMap();
                });
                var hotelRoomsDTO = Mapper.Map<HotelRoomsViewModel, HotelRoomsDTO>(hotelRooms);
                roomService.Update(hotelRoomsDTO);
                return RedirectToAction("Details", new { id = hotelRoomsDTO.RoomNumber });
            }
            ViewBag.RoomClassCode = new SelectList(roomService.GetRoomClasses(), "RoomClassCode", "RoomClassName", hotelRooms.RoomClassCode);
            return View(hotelRooms);
        }

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