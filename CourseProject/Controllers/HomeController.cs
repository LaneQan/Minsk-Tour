using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Tour(int id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                string connectionString = "Data Source=" + Server.MapPath("~") + @"\App_Data\Tours.db";
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();

                    string req = "SELECT * FROM TourInfo WHERE ID=" + id + ";";

                    using (SQLiteCommand cmd = new SQLiteCommand(req, con))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ViewBag.TourHours = reader["TourHours"];
                                ViewBag.LeavingTime = reader["LeavingTime"];
                                ViewBag.TourDay = reader["TourDay"];
                                ViewBag.Places = reader["Places"];
                                ViewBag.PriceBefore18 = reader["PriceBefore18"];
                                ViewBag.PriceAfter18 = reader["PriceAfter18"];
                            }
                        }
                    }

                    con.Close();
                }
                return View();
            }
            else if (id == 4)
            {
                return View("About");
            }
            else throw new HttpException(404, "");
        }
        public ActionResult About()
        {
            return View();
        }

    }
}