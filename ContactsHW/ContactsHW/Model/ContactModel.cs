using SQLite;
using System;

namespace ContactsHW.Model
{
    public class ContactModel : IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNamber { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserID { get; set; }

    }
}
