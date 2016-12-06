using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsCRUD.Models;
using System.Web.Http;

namespace StudentsCRUD.Controllers
{
    public class RazorViewController : Controller
    {

        static IStudentRepository repository = new StudentRepository();
        public ActionResult Index()
        {

            return RedirectToAction("View");

        }

        public ActionResult View()
        {

            return View(repository.GetAll());

        }


        public ActionResult Create()
        {
 
            return View("Create");

        }

        public ActionResult CreateStudent(Student item)
        {
            repository.Add(item);
            return RedirectToAction("View");

        }


        public ActionResult GetStudent(int id)
        {
            return View("Update", repository.Get(id));

        }


        public ActionResult Update(int id, Student item)
        {
            item.id = id;
            repository.Update(item);
            return RedirectToAction("View");

        }
        public ActionResult Delete(int id)
        {
            repository.DeleteStudent(id);
            return RedirectToAction("View");

        }

    }
}
