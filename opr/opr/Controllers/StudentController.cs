using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using opr.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace opr.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult  AddStudent()
        {
            ViewBag.userID = User.Identity.GetUserId();
            ViewBag.name = User.Identity.Name;
            ViewBag.date = DateTime.Now;
            return View();
        }
        public ActionResult AddStudent(Student_Table studtbl)
        {
            oprEntities studdb = new oprEntities();
            studdb.Student_Table.Add(studtbl);
            studdb.SaveChanges();
            return View();
        }
    }
}