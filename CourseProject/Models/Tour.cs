using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int TourHours { get; set; } // 2 часа
        public string LeavingTime { get; set; } // 10:00
        public string TourDay { get; set; } // суббота
        public string Places { get; set; } // Площадь \n Библиотека
        public int PriceBefore18 { get; set; } // 10
        public int PriceAfter18 { get; set; } // 20
        public string SliderImages { get; set; }
    }
}