using Microsoft.AspNet.Identity;
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
        
        [Authorize(Roles = "AccountHolder,Admin")]
        public ActionResult Add(string description)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    using (var db = new ProjectManagerEntities())
                    {
                        var folder = new Folder();
                        var folderLinkUser = new LinkUserToFolder();

                        folder.Id = Guid.NewGuid().ToString();
                        folder.Description = description;
                        folder.DateCreated = DateTime.Now;

                        folderLinkUser.Id = Guid.NewGuid().ToString();
                        folderLinkUser.FolderId = folder.Id;
                        folderLinkUser.UserId = User.Identity.GetUserId();
                        folderLinkUser.DateCreated = DateTime.Now;

                        folder.LinkUserToFolders.Add(folderLinkUser);

                        db.Folders.Add(folder);
                        db.SaveChanges();

                        return Json(new { id = folder.Id, desc = folder.Description }, JsonRequestBehavior.AllowGet);
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