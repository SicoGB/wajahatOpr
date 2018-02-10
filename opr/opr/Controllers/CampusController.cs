using opr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace opr.Controllers
{
    [Authorize]
    public class CampusController : Controller
    {
        // GET: Campus
        public ActionResult Index()
        {
            oprEntities camdb = new oprEntities();
            List<Campus_Table> listOfCampus = new List<Campus_Table>();
            var list = camdb.Campus_Table.ToList();

            return View(list);
        }
        public ActionResult AddCampus()
        {
            ViewBag.userName = User.Identity.Name;
            ViewBag.idcam = User.Identity.GetUserId();
            ViewBag.date = DateTime.Now;
            return View();
        }
        [HttpPost]
        public ActionResult AddCampus(Campus_Table tabl)
        {
           
            oprEntities camdb = new oprEntities();
            camdb.Campus_Table.Add(tabl);
            camdb.SaveChanges();
          
            return View();
        }
        public  ActionResult DeleteCampus(int Id)
        {
            oprEntities camdb = new oprEntities();
            Campus_Table deletecam = camdb.Campus_Table.Find(Id);
            camdb.Campus_Table.Remove(deletecam);
            camdb.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult EditCampus(int Id)
        {
            ViewBag.userName = User.Identity.Name;
            ViewBag.idcam = User.Identity.GetUserId();
            ViewBag.date = DateTime.Now;

            oprEntities camdb = new oprEntities();
            Campus_Table camdata = camdb.Campus_Table.Find(Id);

            return View(camdata);
        }
        [HttpPost]
        public ActionResult EditCampus(Campus_Table camtbl)
        {
            oprEntities camdb = new oprEntities();


            camdb.Entry(camtbl).State = EntityState.Modified;
            
            try
            {
                camdb.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {

            }
            ModelState.AddModelError("","Unable to Save Changes made to the Entity :(");

            return View(camtbl);
        }
    }
}