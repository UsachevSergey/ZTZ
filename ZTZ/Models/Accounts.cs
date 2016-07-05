namespace ZTZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
         public string Name { get; set; }

        [Required]
        [StringLength(50)]
         [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
         public string Password { get; set; }
    }

    //public class Register : Accounts
    //{
    //    [Required]
    //    [StringLength(50)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Повторите пароль")]
    //    [Compare ("Password",ErrorMessage ="Пароли не совпадают")]
    //    public string ConfirmPassword { get; set; }

    //}
}
