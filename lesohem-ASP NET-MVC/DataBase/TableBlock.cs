using System;
using System.Collections.Generic;

namespace lesohem_ASP_NET_MVC.DataBase
{
    public partial class TableBlock
    {
        public TableBlock()
        {
            TableContents = new HashSet<TableContent>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TableContent> TableContents { get; set; }
    }
}
