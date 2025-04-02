using eUseControl.Domain.Entities.BaseEntities;
using eUseControl.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace eUseControl.Domain.Entities.User
{
     public class UDBTable : DBEntity
     {
          [Required]
          [Display(Name = "User Name")]
          [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
          public string Name { get; set; }
          [Required]
          [Display(Name = "User Email")]
          [StringLength(50)]
          public string Email { get; set; }
          [Required]
          [Display(Name = "User Password")]
          [StringLength(50, MinimumLength = 10, ErrorMessage = "Password is too short")]
          public string Password { get; set; }
          [DataType(DataType.Date)]
          public DateTime LoginDateTime { get; set; }

          public string Role { get; set; }

     }

}