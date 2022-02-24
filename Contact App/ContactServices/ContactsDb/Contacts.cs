using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactServices.ContactsDb
{
    public class Contacts
    {
        public string ContactId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }  
        public DateTime Marriage_Anniversary { get; set; }
        public string? Notes { get; set; }
    }
}
