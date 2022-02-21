using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsHW.Model
{
    public class Contact : IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        [Required(ErrorMessage = "Идентификатор пользователя не установлен")]
        public int Id { get; set; }

        [StringLength (30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNamber { get; set; }


        public string ContactImage { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserID { get; set; }
    }
}
