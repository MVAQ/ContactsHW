using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ContactsHW.Model
{
    public class User : IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, Required(ErrorMessage = "Не указан логин пользователя")]
        [StringLength(16, MinimumLength =4, ErrorMessage ="Логин больше 16 или меньше 4 символов!")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]$", ErrorMessage = "Логин должен начинаться с буквы")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Имя больше 16 или меньше 4 символов!")]
        public string UserName { get; set; }

        [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль должен быть не менее 8 и не более 16 символов!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]$", 
            ErrorMessage = "Пароль должен содержать минимум одну заглавную букву, одну строчную букву и одну цифру.")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public DateTime CreateDate { get; set; }
    }
}