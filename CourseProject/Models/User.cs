using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProject.Models
{
    public class User
    {
        [Required(ErrorMessage = "Не введено имя")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Имя может содержать символы А-я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не введена фамилия")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Фамилия может содержать символы А-я")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не введен телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не введен e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный e-mail адрес")]
        public string Mail { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string TourId { get; set; }
    }
}