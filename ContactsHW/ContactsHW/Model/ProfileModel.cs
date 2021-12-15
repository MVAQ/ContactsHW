﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsHW.Model
{
    internal class ProfileModel : IEntityBase
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get;set;}
        public string NikName { get;set;}
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
