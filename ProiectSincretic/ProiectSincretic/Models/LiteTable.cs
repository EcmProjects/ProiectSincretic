using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectSincretic.Models
{
    public class LiteTable
    {
        [SQLite.PrimaryKey]
        public string IdObject { get; set; }
        public string RecordId { get; set; }

        public int ObjectType { get; set; }
        public string ObjectSource { get; set; }

      
    }
}
