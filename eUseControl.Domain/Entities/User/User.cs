using eUseControl.Domain.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities.User
{
    public class User : BaseEntity
     {
          public string Name { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public DateTime LoginDateTime { get; set; }
     }

    class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
    }
}