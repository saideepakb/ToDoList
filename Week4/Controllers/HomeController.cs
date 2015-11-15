using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week4.Models;
using Newtonsoft.Json;
using System.Net;

namespace Week4.Controllers
{
    public class HomeController : Controller
    {

        ToDoItemsDBContext db = new ToDoItemsDBContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Display()
        {
            var items = db.ToDoItems.OrderBy(x => x.DateAdded).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(ToDoItem request)
        {
            if (ModelState.IsValid)
            {
                string taskName = request.Item;
                ToDoItem item = new ToDoItem(taskName);

                db.ToDoItems.Add(item);
                db.SaveChanges();
                
                return Json(item);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                int Id = Int32.Parse(id);
                ToDoItem item = db.ToDoItems.FirstOrDefault(x => x.Id == Id);
                db.ToDoItems.Remove(item);
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult MarkComplete(string id)
        {
            if (ModelState.IsValid)
            {
                int Id = Int32.Parse(id);
                db.ToDoItems.FirstOrDefault(x => x.Id == Id).IsCompleted = true;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}