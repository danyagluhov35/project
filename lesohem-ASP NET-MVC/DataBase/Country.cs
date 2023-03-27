﻿using System;
using System.Collections.Generic;

namespace lesohem_ASP_NET_MVC.DataBase
{
    public partial class Country
    {
        public Country()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
