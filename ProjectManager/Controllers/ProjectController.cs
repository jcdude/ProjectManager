using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string name)
        {
            if(Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var project = new Project();
                        project.Description = name;

                        db.Projects.Add(project);
                        db.SaveChanges();

                        return Json(new { id = project.Id }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch(Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }               
                
            }
            
            return new HttpUnauthorizedResult();
        }

        public ActionResult Remove(string id)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var project = new Project();
                        project.Id = id;

                        db.Projects.Remove(project);
                        db.SaveChanges();

                        return Json(new { id = project.Id }, JsonRequestBehavior.AllowGet);
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