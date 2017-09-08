using CourseProject.Models;
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
            if (id>0 && id<5)
            {
                List<string> info = getInfo(id);
                ViewBag.TourId = info[0];
                ViewBag.TourHours = info[1];
                ViewBag.LeavingTime = info[2];
                ViewBag.TourDay = info[3];
                ViewBag.Places = info[4];
                ViewBag.PriceBefore18 = info[5];
                ViewBag.PriceAfter18 = info[6];
                ViewBag.Slider = info[7];
                return View();
            }
            else throw new HttpException(404, "");
        }

        [HttpGet]
        public ActionResult Reservation(int id)
        {
                ViewBag.TourId = id;
                return View();
        }
        [HttpPost]
        public ActionResult Reservation(User user)
        {

            if (ModelState.IsValid) 
            {
                string TourId = user.TourId;
                string Name = user.Name;
                string Surname = user.Surname;
                string Phone = user.Phone;
                string Mail = user.Mail;
                SendUserInfo(Name, Surname, Mail, Phone, TourId);
                return Content("Спасибо за бронирование!");
            }
            return View("Reservation", user);
        }
        public List<string> getInfo(int id)
        {
            string connectionString = "Data Source=" + Server.MapPath("~") + @"\App_Data\Tours.db";
            List<string> infoAboutTour = new List<string>();   
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
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                infoAboutTour.Add(reader[i].ToString());
                            }
                        }
                    }
                }
                con.Close();
            }
            return infoAboutTour;
        }
        public void SendUserInfo(string name, string surname, string mail, string phone, string id)
        {
            string connectionString = "Data Source=" + Server.MapPath("~") + @"\App_Data\Tours.db";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO 'UserInfo' (Name, Surname, Phone, Mail, TourId)"
            + "VALUES (@Name, @Surname, @Phone, @Mail, @TourId)", con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Mail", mail);
            cmd.Parameters.AddWithValue("@TourId", id);
                cmd.ExecuteNonQuery();
            con.Close();
            }

        }

    }
}