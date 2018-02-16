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

            oprEntities studDb = new oprEntities();
            List<Student_Table> listOfStudent = new List<Student_Table>();

           var list=     studDb.Student_Table.ToList();

            return View(list);
        }
        public ActionResult  AddStudent()
        {
            ViewBag.userID = User.Identity.GetUserId();
            ViewBag.name = User.Identity.Name;
            ViewBag.date = DateTime.Now;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student_Table studtbl)
        {
            oprEntities studdb = new oprEntities();
            studdb.Student_Table.Add(studtbl);
            studdb.SaveChanges();
            return View();
        }
        public ActionResult DeleteStudent(int Id)
        {
            oprEntities deletedb = new oprEntities();
            Student_Table delete = deletedb.Student_Table.Find(Id);
            deletedb.Student_Table.Remove(delete);
            deletedb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditStudent(int Id)
        {
            oprEntities editdb = new oprEntities();
            Student_Table editstudent = editdb.Student_Table.Find(Id);
            return View(editstudent);
        }
        [HttpPost]
        public ActionResult EditStudent(Student_Table stutable)
        {
            oprEntities editdb = new oprEntities();

            editdb.Entry(stutable).State = EntityState.Modified;
            try
            {
                editdb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }

            ModelState.AddModelError("", "Data Cannot edit ");
            return View(editdb);
        }
    }
}