using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult ToursList()
        {
            if (Session["AdminLogin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult ReservedList()
        {
            ViewBag.ReservedTourInfoList = GetReservedInfo();
            return PartialView();
        }
        public ActionResult TestView()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["AdminLogin"] == null)
                return View();
            else return RedirectToAction("ToursList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLogin objAdmin)
        {
            if (ModelState.IsValid)
            {
                    if (objAdmin.Login=="admin" && objAdmin.Password=="admin")
                    {
                        Session["AdminLogin"] = objAdmin.Login;
                        return RedirectToAction("ToursList");
                    }
            }

            return View(objAdmin);
        }

        public ActionResult Exit()
        {
            Session["AdminLogin"] = null;
            return RedirectToAction("Login");
        }

        public List<ReservedTourInfo> GetReservedInfo()
        {
            string connectionString = "Data Source=" + Server.MapPath("~") + @"\App_Data\Tours.db";
            List<ReservedTourInfo> userInfo = new List<ReservedTourInfo>();
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string req = "SELECT * FROM UserInfo";
                using (SQLiteCommand cmd = new SQLiteCommand(req, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservedTourInfo info = new ReservedTourInfo();
                            info.Name = reader[0].ToString();
                            info.Surname = reader[1].ToString();
                            info.Phone = reader[2].ToString();
                            info.Mail = reader[3].ToString();
                            info.Id = Convert.ToInt32(reader[4]);
                            userInfo.Add(info);
                        }
                    }
                }
                con.Close();
            }
            return userInfo;
        }
    }
}