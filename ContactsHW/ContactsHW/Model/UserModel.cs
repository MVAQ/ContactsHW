using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsHW.Model
{
    internal class UserModel : IEntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Login { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }
    }
}