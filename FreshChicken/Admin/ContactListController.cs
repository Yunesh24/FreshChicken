using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreshChicken.Models;

namespace FreshChicken.Admin
{
    public class ContactListController : Controller
    {
        // GET: ContactList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveContactList(ContactListModel model)
        {
            try
            {
                return Json(new { message = (new ContactListModel().SaveContactList(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAddList()
        {
            try
            {
                return Json(new { model = (new ContactListModel().GetAddList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EditData(int Id)
        {
            try
            {
                return Json(new { model = (new ContactListModel().EditData(Id)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deleteRecord(int Id)
        {
            try
            {
                return Json(new { model = (new ContactListModel().deleteRecord(Id)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}