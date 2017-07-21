using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "AccountHolder,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string name)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var task = new Task();
                        task.Description = name;

                        db.Tasks.Add(task);
                        db.SaveChanges();

                        return Json(new { id = task.Id }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            }

            return new HttpUnauthorizedResult();
        }

        [Authorize(Roles = "AccountHolder,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(string id)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var task = new Task();
                        task.Id = id;

                        db.Tasks.Remove(task);
                        db.SaveChanges();

                        return Json(new { id = task.Id }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            }

            return new HttpUnauthorizedResult();
        }
    }

    
}