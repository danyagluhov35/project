﻿using System;
using System.Collections.Generic;

namespace lesohem_ASP_NET_MVC.DataBase
{
    public partial class SocMedium
    {
        public int Id { get; set; }
        public string? Mname { get; set; }
        public string? Link { get; set; }
        public int? PersonId { get; set; }

        public virtual User? Person { get; set; }
    }
}
