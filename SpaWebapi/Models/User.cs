using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpaWebapi.Models
{
    public class User : IdentityUser
    {
        public string Email { get; set; }
    }

    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual decimal Amount { get; set; }

        public virtual User User { get; set; }
    }
}