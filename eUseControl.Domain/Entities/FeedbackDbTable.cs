using eUseControl.Domain.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities
{
    public class FeedbackDbTable : BaseEntity
    {
          [Required(ErrorMessage = "Username is required!")]
          public string UserName { get; set; }
          [Required(ErrorMessage = "Email is required")]
          public string Email {  get; set; }
          [Required(ErrorMessage = "Message can not be empty")]
          public string FeedbackMessage { get; set; }
    }
}
