using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Contracts.CreateCardHolder
{
    public class CardHolder
    {
        public Address Address { get; set; }
        public IEnumerable<int> Agreements { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public Identification Identification { get; set; }
        public Income Income { get; set; }
        public string Last_Name { get; set; }
        public string Mobile { get; set; }
    }
}
