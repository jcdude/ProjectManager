using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class FolderController : Controller
    {
        // GET: Folder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string name)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var folder = new Folder();
                        folder.Description = name;

                        db.Folders.Add(folder);
                        db.SaveChanges();

                        return Json(new { id = folder.Id }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            }

            return new HttpUnauthorizedResult();
        }

        public ActionResult Delete(string id)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var folder = new Folder();
                        folder.Id = id;

                        db.Folders.Remove(folder);
                        db.SaveChanges();

                        return Json(new { id = folder.Id }, JsonRequestBehavior.AllowGet);
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