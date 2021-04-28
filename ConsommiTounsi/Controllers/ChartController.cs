using ConsommiTounsi.Models;
using ConsommiTounsi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class ChartController : Controller
    {

        ChartService chartService = new ChartService();
        // GET: Chart
        public ActionResult Index()
        {

            ViewBag.CountEvent = chartService.countEvent();
            ViewBag.CountEventCollAmount = chartService.countEventCollAmount();
            ViewBag.countAVGEventCollAmount = chartService.countAVGEventCollAmount();
            ViewBag.countParticipations = chartService.countParticipations();
            ViewBag.countDonations = chartService.countDonations();
            ViewBag.displaybestEventsByViews = chartService.displaybestEventsByViews();
            ViewBag.displayEventsByCollAmount = chartService.displayEventsByCollAmount();
            ViewBag.getEventsToday = chartService.getEventsToday();
            ViewBag.getDonationMoyenYear = chartService.getDonationMoyenYear(2021);
            int i = 0;
            List<Object> list = new List<Object>(); 
            foreach (Object[] country in ViewBag.getDonationMoyenYear)
{
                var Name = country[i];
                System.Diagnostics.Debug.Write("hii" + country[i]);
                list.Add(country[i]);
                i++;
               

            }

            ViewBag.data = list;




            return View();
        }

        // GET: Chart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chart/Edit/5
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

        // GET: Chart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
