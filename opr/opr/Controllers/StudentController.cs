using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using opr.Models;
namespace opr.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {            
        //{
        //    Models.ClassEntities db = new ClassEntities();
        //    var mod = db.SchoolTables.Select(c => new { c.school_id, c.school_name }).ToList();
        //    SelectList selectList = new SelectList(mod, "school_id", "school_name", 3);

        //    ViewBag.dataForDropDown = selectList;

        //    var mods = db.ClassTables.Select(c => new { c.class_id, c.class_name }).ToList();
        //    SelectList selectLists = new SelectList(mods, "class_id", "class_name");
        //    ViewBag.dataForDropDowns = selectLists;
           
            return View();
    }
        public ActionResult AddStudent()
        {
            Models.oprEntities dt = new oprEntities();
            List<Models.StudentTable> model = new List<StudentTable>();

            model = dt.StudentTables.ToList();
            ViewBag.UserId = User.Identity.GetUserId();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddStudent(opr.Models.StudentTable model)
        {
            oprEntities db = new oprEntities();


            db.StudentTables.Add(model);

            db.SaveChanges();
            return View();
        }

    }
}