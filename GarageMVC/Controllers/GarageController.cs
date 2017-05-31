﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GarageMVC.Repository;
using GarageMVC.Models;

namespace GarageMVC.Controllers
{
    public class GarageController : Controller
    {
        GarageRepository garage = new GarageRepository();
        // GET: Garage
        [HttpGet]
        public ActionResult Index(string Search="")
        {
            //Update the ParkPrice to current price
            garage.UpdateParkPrice();
            return View(garage.Search(Search));
        }

        // GET: Garage/Details/5
        public ActionResult Details(int id)
        {
            return View(garage.GetVehicle(id));
        }

        // GET: Garage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garage/Create
        [HttpPost]
        public ActionResult Create(Models.Vehicle vehicle)
        {
            garage.Add(vehicle);

            return RedirectToAction("Index");
        }

        // GET: Garage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Garage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Garage/Delete/5
        public ActionResult Delete(int id)
        {
            return View(garage.Remove(id));
        }


        // POST: Garage/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
            
        //}
    }
}
