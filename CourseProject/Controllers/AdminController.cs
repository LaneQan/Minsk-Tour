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
            ViewBag.ReservedTourInfoList = getReservedInfo();
            return View();
        }

        public List<ReservedTourInfo> getReservedInfo()
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