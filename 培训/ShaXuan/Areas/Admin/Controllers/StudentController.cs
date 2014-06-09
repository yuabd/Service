using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Core.Models;
using Hammer.Core.Services;
using Hammer.Common.Models;

namespace ShaXuan.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        private StudentService db = new StudentService();
        //
        // GET: /Admin/Student/

        public ActionResult Index(int? page)
        {
            var list = db.GetStudentList().ToList();
            var model = new Paginated<Student>(list, page ?? 1, 15);

            return View(model);
        }

        public ActionResult Add()
        {
            var student = new Student();

            return View(student);
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                db.InsertStudent(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var model = db.GetStudentByID(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.UpdateStudent(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Delete(int id)
        {
            db.DeleteStudent(id);

            return RedirectToAction("Index");
        }
    }
}
