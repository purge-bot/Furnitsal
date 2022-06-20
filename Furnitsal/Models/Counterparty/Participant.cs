using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models.Counterparty
{
    public abstract class Participant
    {
        public string Address { get; set; }
        public string Company { get; set; }
        public string FullName { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }
    }
}
