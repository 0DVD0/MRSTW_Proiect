using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.BaseEntities;

namespace WebsiteGym.Web.Models
{
    public class CoachViewModel
    {
        public int CoachId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name is not valid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Surame is not valid")]
        public string Surname { get; set; }


        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Speciality is required")]
        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

        public List<Coach> Coaches { get; set; }

    }
}